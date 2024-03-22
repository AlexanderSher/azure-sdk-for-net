// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline.Adapters
{
    internal class PipelineResponseAdapter : PipelineResponse
    {
        private readonly Response _response;

        public PipelineResponseAdapter(Response response)
        {
            _response = response;
            HeadersCore = new ResponseHeadersAdapter(response);
        }

        public override int Status => _response.Status;
        public override string ReasonPhrase => _response.ReasonPhrase;
        public override bool IsError => _response.IsError;

        protected override PipelineResponseHeaders HeadersCore { get; }

        public override Stream? ContentStream
        {
            get => _response.ContentStream;
            set => _response.ContentStream = value;
        }

        public override BinaryData Content => _response.Content;
        public override BinaryData BufferContent(CancellationToken cancellationToken = default)
            => _response.BufferContent(cancellationToken);

        public override ValueTask<BinaryData> BufferContentAsync(CancellationToken cancellationToken = default)
            => _response.BufferContentAsync(cancellationToken);

        public override void Dispose()
            => _response.Dispose();

        private sealed class ResponseHeadersAdapter : PipelineResponseHeaders
        {
            private readonly Response _response;

            public ResponseHeadersAdapter(Response response)
            {
                _response = response;
            }

            public override IEnumerator<KeyValuePair<string, string>> GetEnumerator()
                => _response.EnumerateHeaders().Select(header => new KeyValuePair<string, string>(header.Name, header.Value)).GetEnumerator();

            public override bool TryGetValue(string name, out string? value)
                => _response.TryGetHeader(name, out value);

            public override bool TryGetValues(string name, out IEnumerable<string>? values)
                => _response.TryGetHeaderValues(name, out values);
        }
    }
}
