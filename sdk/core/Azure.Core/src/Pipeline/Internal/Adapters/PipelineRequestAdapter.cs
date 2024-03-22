// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.Pipeline.Adapters
{
    internal class PipelineRequestAdapter : PipelineRequest
    {
        private readonly Request _request;
        private readonly RequestHeadersAdapter _headers;

        public PipelineRequestAdapter(Request request)
        {
            _request = request;
            _headers = new RequestHeadersAdapter(request);
        }

        protected override string MethodCore
        {
            get => _request.Method.Method;
            set => _request.Method = RequestMethod.Parse(value);
        }

        protected override Uri? UriCore
        {
            get => _request.Uri.ToUri();
            set
            {
                if (value is null)
                {
                    _request.Uri = new RequestUriBuilder();
                }
                else
                {
                    _request.Uri.Reset(value);
                }
            }
        }

        protected override PipelineRequestHeaders HeadersCore => _headers;

        protected override BinaryContent? ContentCore
        {
            get => _request.Content;
            set => _request.Content = value switch
            {
                RequestContent requestContent => requestContent,
                not null => new BinaryContentAdapter(value),
                null => null
            };
        }

        public override void Dispose() => _request.Dispose();

        private sealed class RequestHeadersAdapter : PipelineRequestHeaders
        {
            private readonly Request _request;

            public RequestHeadersAdapter(Request request)
            {
                _request = request;
            }

            public override void Add(string name, string value)
                => _request.AddHeader(name, value);

            public override bool Remove(string name)
                => _request.RemoveHeader(name);

            public override void Set(string name, string value)
                => _request.SetHeader(name, value);

            public override IEnumerator<KeyValuePair<string, string>> GetEnumerator()
                => _request.EnumerateHeaders().Select(header => new KeyValuePair<string, string>(header.Name, header.Value)).GetEnumerator();

            public override bool TryGetValue(string name, out string? value)
                => _request.TryGetHeader(name, out value);

            public override bool TryGetValues(string name, out IEnumerable<string>? values)
                => _request.TryGetHeaderValues(name, out values);
        }
    }
}
