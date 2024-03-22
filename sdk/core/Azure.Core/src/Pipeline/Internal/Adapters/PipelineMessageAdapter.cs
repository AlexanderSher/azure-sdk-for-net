// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;

namespace Azure.Core.Pipeline.Adapters
{
    internal class PipelineMessageAdapter : PipelineMessage
    {
        private readonly HttpMessage _azureCoreMessage;
        protected internal PipelineMessageAdapter(HttpMessage azureCorePipeline)
            : base(new PipelineRequestAdapter(azureCorePipeline.Request))
        {
            _azureCoreMessage = azureCorePipeline;
        }

        public static HttpMessage GetHttpMessage(PipelineMessage message, string? errorMessage = default)
        {
            if (message is not PipelineMessageAdapter pipelineMessageAdapter)
            {
                throw new InvalidOperationException($"Invalid type for PipelineMessage: '{message.GetType()}'. {errorMessage}");
            }

            return pipelineMessageAdapter._azureCoreMessage;
        }

        public void SetResponse(Response? value)
        {
            Response = value is null ? null : new PipelineResponseAdapter(value);
        }
    }
}
