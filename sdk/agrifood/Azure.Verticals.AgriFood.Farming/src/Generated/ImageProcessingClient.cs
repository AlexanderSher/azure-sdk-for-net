// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Verticals.AgriFood.Farming
{
    /// <summary> The ImageProcessing service client. </summary>
    public partial class ImageProcessingClient
    {
        private static readonly string[] AuthorizationScopes = new string[] { "https://farmbeats.azure.net/.default" };
        private readonly TokenCredential _tokenCredential;
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of ImageProcessingClient for mocking. </summary>
        protected ImageProcessingClient()
        {
        }

        /// <summary> Initializes a new instance of ImageProcessingClient. </summary>
        /// <param name="endpoint"> The endpoint of your FarmBeats resource (protocol and hostname, for example: https://{resourceName}.farmbeats.azure.net). </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public ImageProcessingClient(Uri endpoint, TokenCredential credential, FarmBeatsClientOptions options = null)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }
            options ??= new FarmBeatsClientOptions();

            _clientDiagnostics = new ClientDiagnostics(options);
            _tokenCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary> Get ImageProcessing Rasterize job&apos;s details. </summary>
        /// <param name="jobId"> ID of the job. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   farmerId: string,
        ///   shapefileAttachmentId: string,
        ///   shapefileColumnNames: [string],
        ///   id: string,
        ///   status: string,
        ///   durationInSeconds: number,
        ///   message: string,
        ///   createdDateTime: string (ISO 8601 Format),
        ///   lastActionDateTime: string (ISO 8601 Format),
        ///   startTime: string (ISO 8601 Format),
        ///   endTime: string (ISO 8601 Format),
        ///   name: string,
        ///   description: string,
        ///   properties: Dictionary&lt;string, AnyObject&gt;
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual async Task<Response> GetRasterizeJobAsync(string jobId, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("ImageProcessingClient.GetRasterizeJob");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetRasterizeJobRequest(jobId, context);
                return await _pipeline.ProcessMessageAsync(message, _clientDiagnostics, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get ImageProcessing Rasterize job&apos;s details. </summary>
        /// <param name="jobId"> ID of the job. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   farmerId: string,
        ///   shapefileAttachmentId: string,
        ///   shapefileColumnNames: [string],
        ///   id: string,
        ///   status: string,
        ///   durationInSeconds: number,
        ///   message: string,
        ///   createdDateTime: string (ISO 8601 Format),
        ///   lastActionDateTime: string (ISO 8601 Format),
        ///   startTime: string (ISO 8601 Format),
        ///   endTime: string (ISO 8601 Format),
        ///   name: string,
        ///   description: string,
        ///   properties: Dictionary&lt;string, AnyObject&gt;
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Response GetRasterizeJob(string jobId, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("ImageProcessingClient.GetRasterizeJob");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetRasterizeJobRequest(jobId, context);
                return _pipeline.ProcessMessage(message, _clientDiagnostics, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create a ImageProcessing Rasterize job. </summary>
        /// <param name="waitForCompletion"> true if the method should wait to return until the long-running operation has completed on the service; false if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="jobId"> JobId provided by user. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   farmerId: string (required),
        ///   shapefileAttachmentId: string (required),
        ///   shapefileColumnNames: [string] (required),
        ///   id: string,
        ///   status: string,
        ///   durationInSeconds: number,
        ///   message: string,
        ///   createdDateTime: string (ISO 8601 Format),
        ///   lastActionDateTime: string (ISO 8601 Format),
        ///   startTime: string (ISO 8601 Format),
        ///   endTime: string (ISO 8601 Format),
        ///   name: string,
        ///   description: string,
        ///   properties: Dictionary&lt;string, AnyObject&gt;
        /// }
        /// </code>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   farmerId: string,
        ///   shapefileAttachmentId: string,
        ///   shapefileColumnNames: [string],
        ///   id: string,
        ///   status: string,
        ///   durationInSeconds: number,
        ///   message: string,
        ///   createdDateTime: string (ISO 8601 Format),
        ///   lastActionDateTime: string (ISO 8601 Format),
        ///   startTime: string (ISO 8601 Format),
        ///   endTime: string (ISO 8601 Format),
        ///   name: string,
        ///   description: string,
        ///   properties: Dictionary&lt;string, AnyObject&gt;
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual async Task<Operation<BinaryData>> CreateRasterizeJobAsync(bool waitForCompletion, string jobId, RequestContent content, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("ImageProcessingClient.CreateRasterizeJob");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateRasterizeJobRequest(jobId, content, context);
                return await LowLevelOperationHelpers.ProcessMessageAsync(_pipeline, message, _clientDiagnostics, "ImageProcessingClient.CreateRasterizeJob", OperationFinalStateVia.Location, context, waitForCompletion).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create a ImageProcessing Rasterize job. </summary>
        /// <param name="waitForCompletion"> true if the method should wait to return until the long-running operation has completed on the service; false if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="jobId"> JobId provided by user. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   farmerId: string (required),
        ///   shapefileAttachmentId: string (required),
        ///   shapefileColumnNames: [string] (required),
        ///   id: string,
        ///   status: string,
        ///   durationInSeconds: number,
        ///   message: string,
        ///   createdDateTime: string (ISO 8601 Format),
        ///   lastActionDateTime: string (ISO 8601 Format),
        ///   startTime: string (ISO 8601 Format),
        ///   endTime: string (ISO 8601 Format),
        ///   name: string,
        ///   description: string,
        ///   properties: Dictionary&lt;string, AnyObject&gt;
        /// }
        /// </code>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   farmerId: string,
        ///   shapefileAttachmentId: string,
        ///   shapefileColumnNames: [string],
        ///   id: string,
        ///   status: string,
        ///   durationInSeconds: number,
        ///   message: string,
        ///   createdDateTime: string (ISO 8601 Format),
        ///   lastActionDateTime: string (ISO 8601 Format),
        ///   startTime: string (ISO 8601 Format),
        ///   endTime: string (ISO 8601 Format),
        ///   name: string,
        ///   description: string,
        ///   properties: Dictionary&lt;string, AnyObject&gt;
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Operation<BinaryData> CreateRasterizeJob(bool waitForCompletion, string jobId, RequestContent content, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("ImageProcessingClient.CreateRasterizeJob");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateRasterizeJobRequest(jobId, content, context);
                return LowLevelOperationHelpers.ProcessMessage(_pipeline, message, _clientDiagnostics, "ImageProcessingClient.CreateRasterizeJob", OperationFinalStateVia.Location, context, waitForCompletion);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateCreateRasterizeJobRequest(string jobId, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/image-processing/rasterize/", false);
            uri.AppendPath(jobId, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            message.ResponseClassifier = ResponseClassifier202.Instance;
            return message;
        }

        internal HttpMessage CreateGetRasterizeJobRequest(string jobId, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/image-processing/rasterize/", false);
            uri.AppendPath(jobId, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }

        private sealed class ResponseClassifier202 : ResponseClassifier
        {
            private static ResponseClassifier _instance;
            public static ResponseClassifier Instance => _instance ??= new ResponseClassifier202();
            public override bool IsErrorResponse(HttpMessage message)
            {
                return message.Response.Status switch
                {
                    202 => false,
                    _ => true
                };
            }
        }
        private sealed class ResponseClassifier200 : ResponseClassifier
        {
            private static ResponseClassifier _instance;
            public static ResponseClassifier Instance => _instance ??= new ResponseClassifier200();
            public override bool IsErrorResponse(HttpMessage message)
            {
                return message.Response.Status switch
                {
                    200 => false,
                    _ => true
                };
            }
        }
    }
}
