// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    /// <summary>
    /// Token cache
    /// </summary>
    public class TokenCache
    {
        private readonly object _syncObj = new object();

        internal ITokenCache Cache { get; }

        internal TokenCache(ITokenCache tokenCache)
        {
            Cache = tokenCache;
        }

        /// <summary>
        /// Resets token cache next time it is used
        /// </summary>
        /// <param name="data"></param>
        public void Reset(byte[] data)
        {
            lock (_syncObj)
            {
                Cache.SetBeforeAccess(OnResetCallback);
            }

            void OnResetCallback(TokenCacheNotificationArgs args)
            {
                lock (_syncObj)
                {
                    Cache.SetBeforeAccess(a => { });
                }
                args.TokenCache.DeserializeMsalV3(data, shouldClearExistingCache: true);
            }
        }

        /// <summary>
        /// Sets a delegate to be called when cache changes
        /// </summary>
        /// <param name="onCacheChanged"></param>
        public void SetOnCacheChanged(Action<byte[]> onCacheChanged)
        {
            lock (_syncObj)
            {
                Cache.SetAfterAccess(OnCacheChangedCallback);
            }

            void OnCacheChangedCallback(TokenCacheNotificationArgs args)
            {
                if (args.HasStateChanged)
                {
                    onCacheChanged(args.TokenCache.SerializeMsalV3());
                }
            }
        }

        /// <summary>
        /// Sets a delegate to be called when cache changes
        /// </summary>
        /// <param name="onCacheChangedAsync"></param>
        public void SetOnCacheChangedAsync(Func<byte[], Task> onCacheChangedAsync)
        {
            lock (_syncObj)
            {
                Cache.SetAfterAccessAsync(OnCacheChangedCallback);
            }

            async Task OnCacheChangedCallback(TokenCacheNotificationArgs args)
            {
                if (args.HasStateChanged)
                {
                    await onCacheChangedAsync(args.TokenCache.SerializeMsalV3()).ConfigureAwait(false);
                }
            }
        }
    }
}
