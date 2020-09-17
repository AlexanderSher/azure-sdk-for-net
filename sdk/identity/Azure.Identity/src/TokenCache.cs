// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    /// <summary>
    /// X
    /// </summary>
    public class TokenCache
    {
        internal ITokenCache Cache { get; }

        internal TokenCache(ITokenCache tokenCache)
        {
            Cache = tokenCache;
        }

        public void SetCacheData(byte[] data)
        {
            Cache.SetBeforeAccess(args => args.TokenCache.DeserializeMsalV3(data, shouldClearExistingCache: true));
        }

        /// <summary>
        /// X
        /// </summary>
        /// <param name="onCacheChanged"></param>
        public void SetCacheChanged(Action<TokenCache, byte[]> onCacheChanged) =>
            Cache.SetAfterAccess(args =>
            {
                if (args.HasStateChanged)
                {
                    onCacheChanged(this, args.TokenCache.SerializeMsalV3());
                }
            });

        /// <summary>
        /// Set
        /// </summary>
        /// <param name="getCacheData"></param>
        public void SetBeforeCacheCreated(Func<TokenCache, byte[]> getCacheData)
            => Cache.SetBeforeAccess(args => args.TokenCache.DeserializeMsalV3(getCacheData(this), shouldClearExistingCache: true));

        /// <summary>
        /// X
        /// </summary>
        /// <param name="onCacheChangedAsync"></param>
        public void SetCacheChangedAsync(Func<TokenCache, byte[], Task> onCacheChangedAsync) =>
            Cache.SetAfterAccessAsync(async args =>
            {
                if (args.HasStateChanged)
                {
                    await onCacheChangedAsync(this, args.TokenCache.SerializeMsalV3()).ConfigureAwait(false);
                }
            });

        /// <summary>
        /// X
        /// </summary>
        /// <param name="getCacheDataAsync"></param>
        public void SetBeforeCacheCreatedAsync(Func<TokenCache, Task<byte[]>> getCacheDataAsync)
            => Cache.SetBeforeAccessAsync(async args => args.TokenCache.DeserializeMsalV3(await getCacheDataAsync(this).ConfigureAwait(false), shouldClearExistingCache: true));
    }
}
