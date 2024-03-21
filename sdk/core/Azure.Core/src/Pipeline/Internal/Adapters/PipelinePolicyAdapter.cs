// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline.Adapters
{
    internal class PipelinePolicyAdapter : HttpPipelinePolicy
    {
        private readonly PipelinePolicy _policy;

        public PipelinePolicyAdapter(PipelinePolicy policy)
        {
            _policy = policy;
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            => await ProcessSyncOrAsync(message, pipeline, true).ConfigureAwait(false);

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            => ProcessSyncOrAsync(message, pipeline, false).EnsureCompleted();

        private async ValueTask ProcessSyncOrAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            var policyPipeline = new PipelinePolicy[] { new HttpPipelinePolicyCallback(message, pipeline) };
            try
            {
                if (async)
                {
                    await _policy.ProcessAsync(message.PipelineMessage, policyPipeline, -1).ConfigureAwait(false);
                }
                else
                {
                    _policy.Process(message.PipelineMessage, policyPipeline, -1);
                }
            }
            catch (ClientResultException e)
            {
                if (!message.HasResponse)
                {
                    throw new RequestFailedException(e.Message, e.InnerException);
                }

                if (async)
                {
                    //await RequestFailedException.CreateAsync(message.Response, innerException: e.InnerException).ConfigureAwait(false);
                    throw new RequestFailedException(message.Response, e.InnerException);
                }
                else
                {
                    throw new RequestFailedException(message.Response, e.InnerException);
                }
            }
        }

        private class HttpPipelinePolicyCallback : PipelinePolicy
        {
            private readonly HttpMessage _message;
            private readonly ReadOnlyMemory<HttpPipelinePolicy> _pipeline;

            public HttpPipelinePolicyCallback(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                _message = message;
                _pipeline = pipeline;
            }

            public override ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
            {
                return _pipeline.Span[0].ProcessAsync(_message, _pipeline.Slice(1));
            }

            public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
            {
                _pipeline.Span[0].Process(_message, _pipeline.Slice(1));
            }
        }
    }
}
