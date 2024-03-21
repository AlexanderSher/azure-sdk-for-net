// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline.Adapters
{
    internal sealed class BinaryContentAdapter : RequestContent
    {
        private readonly BinaryContent _content;

        public BinaryContentAdapter(BinaryContent content)
        {
            _content = content;
        }

        public override void Dispose() => _content.Dispose();
        public override bool TryComputeLength(out long length) => _content.TryComputeLength(out length);
        public override void WriteTo(Stream stream, CancellationToken cancellationToken) => _content.WriteTo(stream, cancellationToken);
        public override async Task WriteToAsync(Stream stream, CancellationToken cancellationToken) => await _content.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);
    }
}
