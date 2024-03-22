// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline.Adapters;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// An <see cref="HttpPipelineTransport"/> implementation that uses <see cref="HttpClient"/> as the transport.
    /// </summary>
    public partial class HttpClientTransport : HttpPipelineTransport, IDisposable
    {
        internal const string MessageForServerCertificateCallback = "MessageForServerCertificateCallback";

        /// <summary>
        /// A shared instance of <see cref="HttpClientTransport"/> with default parameters.
        /// </summary>
        public static readonly HttpClientTransport Shared = new HttpClientTransport();

        private readonly PipelinePolicyAdapter _transport;

        // The transport's private HttpClient is internal because it is used by tests.
        internal HttpClient Client { get; }

        /// <summary>
        /// Creates a new <see cref="HttpClientTransport"/> instance using default configuration.
        /// </summary>
        public HttpClientTransport() : this(CreateDefaultClient())
        { }

        /// <summary>
        /// Creates a new <see cref="HttpClientTransport"/> instance using default configuration.
        /// </summary>
        /// <param name="options">The <see cref="HttpPipelineTransportOptions"/> that to configure the behavior of the transport.</param>
        internal HttpClientTransport(HttpPipelineTransportOptions? options = null) : this(CreateDefaultClient(options))
        { }

        /// <summary>
        /// Creates a new instance of <see cref="HttpClientTransport"/> using the provided client instance.
        /// </summary>
        /// <param name="messageHandler">The instance of <see cref="HttpMessageHandler"/> to use.</param>
        public HttpClientTransport(HttpMessageHandler messageHandler)
            : this(new HttpClient(messageHandler))
        {
        }

        /// <summary>
        /// Creates a new instance of <see cref="HttpClientTransport"/> using the provided client instance.
        /// </summary>
        /// <param name="client">The instance of <see cref="HttpClient"/> to use.</param>
        public HttpClientTransport(HttpClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
            _transport = new PipelinePolicyAdapter(new AzureCoreHttpPipelineTransport(client));
        }

        /// <inheritdoc />
        public sealed override Request CreateRequest()
            => new HttpClientTransportRequest();

        /// <inheritdoc />
        public override void Process(HttpMessage message)
            => _transport.Process(message, ReadOnlyMemory<HttpPipelinePolicy>.Empty);

        /// <inheritdoc />
        public override ValueTask ProcessAsync(HttpMessage message)
            => _transport.ProcessAsync(message, ReadOnlyMemory<HttpPipelinePolicy>.Empty);

        private static HttpClient CreateDefaultClient(HttpPipelineTransportOptions? options = null)
        {
            var httpMessageHandler = CreateDefaultHandler(options);
            SetProxySettings(httpMessageHandler);
            ServicePointHelpers.SetLimits(httpMessageHandler);

            return new HttpClient(httpMessageHandler)
            {
                // Timeouts are handled by the pipeline
                Timeout = Timeout.InfiniteTimeSpan,
            };
        }

        private static HttpMessageHandler CreateDefaultHandler(HttpPipelineTransportOptions? options = null)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Create("BROWSER")))
            {
                // UseCookies is not supported on "browser"
                return new HttpClientHandler();
            }

#if NETCOREAPP
            return ApplyOptionsToHandler(new SocketsHttpHandler { AllowAutoRedirect = false, UseCookies = UseCookies() }, options);
#else
            return ApplyOptionsToHandler(new HttpClientHandler { AllowAutoRedirect = false, UseCookies = UseCookies() }, options);
#endif
        }

        private static void SetProxySettings(HttpMessageHandler messageHandler)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Create("BROWSER")))
            {
                return;
            }

            if (HttpEnvironmentProxy.TryCreate(out IWebProxy webProxy))
            {
                switch (messageHandler)
                {
#if NETCOREAPP
                    case SocketsHttpHandler socketsHttpHandler:
                        socketsHttpHandler.Proxy = webProxy;
                        break;
#endif
                    case HttpClientHandler httpClientHandler:
                        httpClientHandler.Proxy = webProxy;
                        break;
                    default:
                        Debug.Assert(false, "Unknown handler type");
                        break;
                }
            }
        }

#if NETCOREAPP
        private static SocketsHttpHandler ApplyOptionsToHandler(SocketsHttpHandler httpHandler, HttpPipelineTransportOptions? options)
        {
            if (options == null || RuntimeInformation.IsOSPlatform(OSPlatform.Create("BROWSER")))
            {
                return httpHandler;
            }

#pragma warning disable CA1416 // 'X509Certificate2' is unsupported on 'browser'
            // ServerCertificateCustomValidationCallback
            if (options.ServerCertificateCustomValidationCallback != null)
            {
                httpHandler.SslOptions.RemoteCertificateValidationCallback = (_, certificate, x509Chain, sslPolicyErrors) =>
                    options.ServerCertificateCustomValidationCallback(
                        new ServerCertificateCustomValidationArgs(
                            certificate is { } ? new X509Certificate2(certificate) : null,
                            x509Chain,
                            sslPolicyErrors));
            }
            // Set ClientCertificates
            foreach (var cert in options.ClientCertificates)
            {
                httpHandler.SslOptions ??= new System.Net.Security.SslClientAuthenticationOptions();
                httpHandler.SslOptions.ClientCertificates ??= new X509CertificateCollection();
                httpHandler.SslOptions.ClientCertificates!.Add(cert);
            }
#pragma warning restore CA1416 // 'X509Certificate2' is unsupported on 'browser'
            return httpHandler;
        }
#else
        private static HttpClientHandler ApplyOptionsToHandler(HttpClientHandler httpHandler, HttpPipelineTransportOptions? options)
        {
            if (options == null || RuntimeInformation.IsOSPlatform(OSPlatform.Create("BROWSER")))
            {
                return httpHandler;
            }

            // ServerCertificateCustomValidationCallback
            if (options.ServerCertificateCustomValidationCallback != null)
            {
                httpHandler.ServerCertificateCustomValidationCallback = (_, certificate2, x509Chain, sslPolicyErrors) =>
                {
                    return options.ServerCertificateCustomValidationCallback(
                        new ServerCertificateCustomValidationArgs(certificate2, x509Chain, sslPolicyErrors));
                };
            }
            // Set ClientCertificates
            foreach (var cert in options.ClientCertificates)
            {
                httpHandler.ClientCertificates.Add(cert);
            }
            return httpHandler;
        }
#endif

        private static bool UseCookies() => AppContextSwitchHelper.GetConfigValue(
            "Azure.Core.Pipeline.HttpClientTransport.EnableCookies",
            "AZURE_CORE_HTTPCLIENT_ENABLE_COOKIES");

        /// <summary>
        /// Disposes the underlying <see cref="HttpClient"/>.
        /// </summary>
        public void Dispose()
        {
            if (this != Shared)
            {
                Client.Dispose();
            }

            GC.SuppressFinalize(this);
        }

        private static void SetPropertiesOrOptions<T>(HttpRequestMessage httpRequest, string name, T value)
        {
#if NET5_0_OR_GREATER
            httpRequest.Options.Set(new HttpRequestOptionsKey<T>(name), value);
#else
            httpRequest.Properties[name] = value;
#endif
        }

        /// <summary>
        /// Adds Azure.Core features to the System.ClientModel HttpClient-based
        /// transport.
        ///
        /// This type inherits from System.ClientModel's
        /// <see cref="HttpClientPipelineTransport"/> and overrides its
        /// extensibility points for
        /// <see cref="OnSendingRequest(PipelineMessage, HttpRequestMessage)"/>
        /// and <see cref="OnReceivedResponse(PipelineMessage, HttpResponseMessage)"/>
        /// to add features specific to Azure, such as
        /// <see cref="Request.ClientRequestId"/>.
        /// </summary>
        private class AzureCoreHttpPipelineTransport : HttpClientPipelineTransport
        {
            public AzureCoreHttpPipelineTransport(HttpClient client) : base(client)
            {
            }

            protected override PipelineMessage CreateMessageCore()
                => throw new InvalidOperationException($"{nameof(AzureCoreHttpPipelineTransport)} instance is private to {nameof(HttpClientTransport)}, {nameof(CreateMessageCore)} is not expected to be called");

            /// <inheritdoc />
            protected override void OnSendingRequest(PipelineMessage message, HttpRequestMessage httpRequest)
            {
                var httpMessage = PipelineMessageAdapter.GetHttpMessage(message, "The provided message was created by a different transport.");
                SetPropertiesOrOptions(httpRequest, MessageForServerCertificateCallback, httpMessage);
                AddPropertiesForBlazor(httpRequest);
                httpMessage.ClearResponse();
            }

            /// <inheritdoc />
            protected override void OnReceivedResponse(PipelineMessage message, HttpResponseMessage httpResponse)
            {
                var httpMessage = PipelineMessageAdapter.GetHttpMessage(message, "The provided message was created by a different transport.");
                var clientRequestId = httpMessage.Request.ClientRequestId;
                var pipelineResponse = message.Response!;
                httpMessage.Response = new HttpClientTransportResponse(clientRequestId, httpResponse, null);
            }

            private static void AddPropertiesForBlazor(HttpRequestMessage currentRequest)
            {
                // Disable response caching and enable streaming in Blazor apps
                // see https://github.com/dotnet/aspnetcore/blob/3143d9550014006080bb0def5b5c96608b025a13/src/Components/WebAssembly/WebAssembly/src/Http/WebAssemblyHttpRequestMessageExtensions.cs
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Create("BROWSER")))
                {
                    SetPropertiesOrOptions(currentRequest, "WebAssemblyFetchOptions", new Dictionary<string, object> { { "cache", "no-store" } });
                    SetPropertiesOrOptions(currentRequest, "WebAssemblyEnableStreamingResponse", true);
                }
            }
        }
    }
}
