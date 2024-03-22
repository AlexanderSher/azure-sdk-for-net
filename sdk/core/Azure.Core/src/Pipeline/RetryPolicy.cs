// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline.Adapters;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Represents a policy that can be overriden to customize whether a request will be retried and how long to wait before retrying.
    /// </summary>
    public class RetryPolicy : HttpPipelinePolicy
    {
        private readonly int _maxRetries;

        /// <summary>
        /// Gets the delay to use for computing the interval between retry attempts.
        /// </summary>
        private readonly DelayStrategy _delayStrategy;

        private readonly PipelinePolicyAdapter _clientModelPolicy;

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryPolicy"/> class.
        /// </summary>
        /// <param name="maxRetries">The maximum number of retries to attempt.</param>
        /// <param name="delayStrategy">The delay to use for computing the interval between retry attempts.</param>
        public RetryPolicy(int maxRetries = RetryOptions.DefaultMaxRetries, DelayStrategy? delayStrategy = default)
        {
            _maxRetries = maxRetries;
            _delayStrategy = delayStrategy ?? DelayStrategy.CreateExponentialDelayStrategy();
            _clientModelPolicy = new PipelinePolicyAdapter(new CustomClientRetryPolicy(maxRetries, _delayStrategy, this));
        }

        /// <summary>
        /// This method can be overriden to take full control over the retry policy. If this is overriden and the base method isn't called,
        /// it is the implementer's responsibility to populate the <see cref="HttpMessage.ProcessingContext"/> property.
        /// This method will only be called for async methods.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> this policy would be applied to.</param>
        /// <param name="pipeline">The set of <see cref="HttpPipelinePolicy"/> to execute after current one.</param>
        /// <returns>The <see cref="ValueTask"/> representing the asynchronous operation.</returns>
        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return _clientModelPolicy.ProcessAsync(message, pipeline);
        }

        /// <summary>
        /// This method can be overriden to take full control over the retry policy. If this is overriden and the base method isn't called,
        /// it is the implementer's responsibility to populate the <see cref="HttpMessage.ProcessingContext"/> property.
        /// This method will only be called for sync methods.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> this policy would be applied to.</param>
        /// <param name="pipeline">The set of <see cref="HttpPipelinePolicy"/> to execute after current one.</param>
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            _clientModelPolicy.Process(message, pipeline);
        }

        internal virtual async Task WaitAsync(TimeSpan time, CancellationToken cancellationToken)
        {
            await Task.Delay(time, cancellationToken).ConfigureAwait(false);
        }

        internal virtual void Wait(TimeSpan time, CancellationToken cancellationToken)
        {
            cancellationToken.WaitHandle.WaitOne(time);
        }

        /// <summary>
        /// This method can be overriden to control whether a request should be retried. It will be called for any response where
        /// <see cref="Response.IsError"/> is true, or if an exception is thrown from any subsequent pipeline policies or the transport.
        /// This method will only be called for sync methods.
        /// </summary>
        /// <param name="message">The message containing the request and response.</param>
        /// <param name="exception">The exception that occurred, if any, which can be used to determine if a retry should occur.</param>
        /// <returns>Whether or not to retry.</returns>
        protected internal virtual bool ShouldRetry(HttpMessage message, Exception? exception) => ShouldRetryInternal(message, exception);

        /// <summary>
        /// This method can be overriden to control whether a request should be retried.  It will be called for any response where
        /// <see cref="Response.IsError"/> is true, or if an exception is thrown from any subsequent pipeline policies or the transport.
        /// This method will only be called for async methods.
        /// </summary>
        /// <param name="message">The message containing the request and response.</param>
        /// <param name="exception">The exception that occurred, if any, which can be used to determine if a retry should occur.</param>
        /// <returns>Whether or not to retry.</returns>
        protected internal virtual ValueTask<bool> ShouldRetryAsync(HttpMessage message, Exception? exception) => new(ShouldRetryInternal(message, exception));

        private bool ShouldRetryInternal(HttpMessage message, Exception? exception)
        {
            if (message.RetryNumber < _maxRetries)
            {
                if (exception != null)
                {
                    return message.ResponseClassifier.IsRetriable(message, exception);
                }

                // Response.IsError is true if we get here
                return message.ResponseClassifier.IsRetriableResponse(message);
            }

            // out of retries
            return false;
        }

        /// <summary>
        /// This method can be overriden to control how long to delay before retrying. This method will only be called for sync methods.
        /// </summary>
        /// <param name="message">The message containing the request and response.</param>
        /// <param name="retryAfter">The Retry-After header value, if any, returned from the service.</param>
        /// <returns>The amount of time to delay before retrying.</returns>
        internal TimeSpan GetNextDelay(HttpMessage message, TimeSpan? retryAfter) => GetNextDelayInternal(message);

        /// <summary>
        /// This method can be overriden to control how long to delay before retrying. This method will only be called for async methods.
        /// </summary>
        /// <param name="message">The message containing the request and response.</param>
        /// <param name="retryAfter">The Retry-After header value, if any, returned from the service.</param>
        /// <returns>The amount of time to delay before retrying.</returns>
        internal ValueTask<TimeSpan> GetNextDelayAsync(HttpMessage message, TimeSpan? retryAfter) => new(GetNextDelayInternal(message));

        /// <summary>
        /// This method can be overridden to introduce logic before each request attempt is sent. This will run even for the first attempt.
        /// This method will only be called for sync methods.
        /// </summary>
        /// <param name="message">The message containing the request and response.</param>
        protected internal virtual void OnSendingRequest(HttpMessage message)
        {
        }

        /// <summary>
        /// This method can be overriden to introduce logic that runs before the request is sent. This will run even for the first attempt.
        /// This method will only be called for async methods.
        /// </summary>
        /// <param name="message">The message containing the request and response.</param>
        protected internal virtual ValueTask OnSendingRequestAsync(HttpMessage message) => default;

        /// <summary>
        /// This method can be overridden to introduce logic that runs after the request is sent through the pipeline and control is returned to the retry
        /// policy. This method will only be called for sync methods.
        /// </summary>
        /// <param name="message">The message containing the request and response.</param>
        protected internal virtual void OnRequestSent(HttpMessage message)
        {
        }

        /// <summary>
        /// This method can be overridden to introduce logic that runs after the request is sent through the pipeline and control is returned to the retry
        /// policy. This method will only be called for async methods.
        /// </summary>
        /// <param name="message">The message containing the request and response.</param>
        protected internal virtual ValueTask OnRequestSentAsync(HttpMessage message) => default;

        private TimeSpan GetNextDelayInternal(HttpMessage message)
        {
            return _delayStrategy.GetNextDelay(
                message.HasResponse ? message.Response : default,
                message.RetryNumber + 1);
        }

        private class CustomClientRetryPolicy : ClientRetryPolicy
        {
            private readonly DelayStrategy _delayStrategy;
            private readonly RetryPolicy _azureCorePolicy;

            public CustomClientRetryPolicy(int maxRetries, DelayStrategy delayStrategy, RetryPolicy azureCorePolicy) : base(maxRetries)
            {
                _delayStrategy = delayStrategy;
                _azureCorePolicy = azureCorePolicy;
            }

            protected override void OnSendingRequest(PipelineMessage message)
            {
                message.SetProperty(typeof(BeforeTimestamp), Stopwatch.GetTimestamp());
                _azureCorePolicy.OnSendingRequest(PipelineMessageAdapter.GetHttpMessage(message));
            }

            protected override async ValueTask OnSendingRequestAsync(PipelineMessage message)
            {
                message.SetProperty(typeof(BeforeTimestamp), Stopwatch.GetTimestamp());
                await _azureCorePolicy.OnSendingRequestAsync(PipelineMessageAdapter.GetHttpMessage(message)).ConfigureAwait(false);
            }

            protected override ValueTask OnRequestSentAsync(PipelineMessage message)
                => OnRequestSentSyncOrAsync(message, true);

            protected override void OnRequestSent(PipelineMessage message)
                => OnRequestSentSyncOrAsync(message, false).EnsureCompleted();

            private async ValueTask OnRequestSentSyncOrAsync(PipelineMessage message, bool async)
            {
                var httpMessage = PipelineMessageAdapter.GetHttpMessage(message);
                if (async)
                {
                    await _azureCorePolicy.OnRequestSentAsync(httpMessage).ConfigureAwait(false);
                }
                else
                {
                    _azureCorePolicy.OnRequestSent(httpMessage);
                }

                if (!message.TryGetProperty(typeof(BeforeTimestamp), out object? beforeTimestamp) ||
                    beforeTimestamp is not long before)
                {
                    Debug.Fail("'BeforeTimestamp' was not set on message by RetryPolicy.");
                    return;
                }

                long after = Stopwatch.GetTimestamp();
                double elapsed = (after - before) / (double)Stopwatch.Frequency;

                message.SetProperty(typeof(ElapsedTime), elapsed);
            }

            protected override bool ShouldRetry(PipelineMessage message, Exception? exception)
                => _azureCorePolicy.ShouldRetry(PipelineMessageAdapter.GetHttpMessage(message), exception);

            protected override async ValueTask<bool> ShouldRetryAsync(PipelineMessage message, Exception? exception)
                => await _azureCorePolicy.ShouldRetryAsync(PipelineMessageAdapter.GetHttpMessage(message), exception).ConfigureAwait(false);

            protected override void OnTryComplete(PipelineMessage message)
            {
                HttpMessage httpMessage = PipelineMessageAdapter.GetHttpMessage(message);
                httpMessage.RetryNumber++;

                if (!message.TryGetProperty(typeof(ElapsedTime), out object? elapsedTime) ||
                    elapsedTime is not double elapsed)
                {
                    Debug.Fail("'ElapsedTime' was not set on message by RetryPolicy.");
                    return;
                }

                // This logic can move into System.ClientModel's ClientRetryPolicy
                // once we enable EventSource logging there.
                AzureCoreEventSource.Singleton.RequestRetrying(httpMessage.Request.ClientRequestId, httpMessage.RetryNumber, elapsed);

                // Reset stopwatch values
                message.SetProperty(typeof(BeforeTimestamp), null);
                message.SetProperty(typeof(ElapsedTime), null);
            }

            protected override TimeSpan GetNextDelay(PipelineMessage message, int tryCount)
            {
                HttpMessage httpMessage = PipelineMessageAdapter.GetHttpMessage(message);
                Debug.Assert(tryCount == httpMessage.RetryNumber);

                Response? response = httpMessage.HasResponse ? httpMessage.Response : default;
                return _delayStrategy.GetNextDelay(response, tryCount + 1);
            }

            protected override async Task WaitAsync(TimeSpan time, CancellationToken cancellationToken)
                => await _azureCorePolicy.WaitAsync(time, cancellationToken).ConfigureAwait(false);

            protected override void Wait(TimeSpan time, CancellationToken cancellationToken)
                => _azureCorePolicy.Wait(time, cancellationToken);

            private class BeforeTimestamp { }

            private class ElapsedTime { }
        }
    }
}
