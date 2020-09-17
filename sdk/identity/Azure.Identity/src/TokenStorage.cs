// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// Token storage base class
    /// </summary>
    public abstract class TokenStorage
    {
        /// <summary>
        /// Registers cache with storage
        /// </summary>
        /// <param name="tokenCache"></param>
        /// <param name="cancellationToken"></param>
        public abstract void Register(TokenCache tokenCache, CancellationToken cancellationToken);

        /// <summary>
        /// Registers cache with storage
        /// </summary>
        /// <param name="tokenCache"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task RegisterAsync(TokenCache tokenCache, CancellationToken cancellationToken);
    }
}
