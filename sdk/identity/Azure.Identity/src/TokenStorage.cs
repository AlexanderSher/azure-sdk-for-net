// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// X
    /// </summary>
    public abstract class TokenStorage
    {
        /// <summary>
        /// X
        /// </summary>
        /// <param name="tokenCache"></param>
        /// <param name="cancellationToken"></param>
        public abstract void Register(TokenCache tokenCache, CancellationToken cancellationToken);

        /// <summary>
        /// X
        /// </summary>
        /// <param name="tokenCache"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task RegisterAsync(TokenCache tokenCache, CancellationToken cancellationToken);
    }
}
