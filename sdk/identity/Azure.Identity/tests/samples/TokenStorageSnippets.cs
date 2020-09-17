// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Azure;

namespace Azure.Identity.Samples
{
    public class TokenStorageSnippets
    {
        public void Identity_TokenStorage_PersistentDefault()
        {
            #region Snippet:Identity_TokenStorage_PersistentDefault
            var credential = new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions { TokenStorage = new PersistentTokenStorage() });
            #endregion
        }

        public void Identity_TokenStorage_PersistentNamed()
        {
            #region Snippet:Identity_TokenStorage_PersistentNamed
            var tokenStorage = new PersistentTokenStorage(new PersistentTokenStorageOptions { Name = "my_application_name" });

            var credential = new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions { TokenStorage = tokenStorage });
            #endregion
        }

        public void Identity_TokenCache_PersistentUnencrypted()
        {
            #region Snippet:Identity_TokenStorage_PersistentUnencrypted
            var tokenStorage = new PersistentTokenStorage(new PersistentTokenStorageOptions { AllowUnencryptedStorage = true });

            var credential = new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions { TokenStorage =  tokenStorage});
            #endregion
        }

        private const string TokenCachePath = "./tokencache.bin";

        #region Snippet:Identity_TokenCache_CustomPersistence_Usage
        public static void Identity_TokenStorage_CustomPersistence()
        {
            var tokenStorage = new CustomTokenStorage();
            var credential = new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions { TokenStorage = tokenStorage });
        }

        public class CustomTokenStorage : TokenStorage
        {
            public override void Register(TokenCache tokenCache, CancellationToken cancellationToken)
            {
                tokenCache.SetCacheChanged(WriteFromCacheToFile);
                tokenCache.SetBeforeCacheCreated(WriteFromFileToCache);
            }

            public override Task RegisterAsync(TokenCache tokenCache, CancellationToken cancellationToken)
            {
                tokenCache.SetCacheChangedAsync(WriteFromCacheToFileAsync);
                tokenCache.SetBeforeCacheCreatedAsync(WriteFromFileToCacheAsync);
                return Task.CompletedTask;
            }

            private void WriteFromCacheToFile(TokenCache tokenCache, byte[] data)
            {
                using var cacheStream = new FileStream(TokenCachePath, FileMode.Create, FileAccess.Write);
                cacheStream.Write(data, 0, data.Length);
            }

            private byte[] WriteFromFileToCache(TokenCache tokenCache)
            {
                using var cacheStream = new FileStream(TokenCachePath, FileMode.OpenOrCreate, FileAccess.Read);
                var data = new byte[cacheStream.Length - cacheStream.Position];
                cacheStream.Read(data, 0, data.Length);
                return data;
            }

            private async Task WriteFromCacheToFileAsync(TokenCache tokenCache, byte[] data)
            {
                using var cacheStream = new FileStream(TokenCachePath, FileMode.Create, FileAccess.Write);
                await cacheStream.WriteAsync(data, 0, data.Length).ConfigureAwait(false);
            }

            private async Task<byte[]> WriteFromFileToCacheAsync(TokenCache tokenCache)
            {
                using var cacheStream = new FileStream(TokenCachePath, FileMode.OpenOrCreate, FileAccess.Read);
                var data = new byte[cacheStream.Length - cacheStream.Position];
                await cacheStream.ReadAsync(data, 0, data.Length).ConfigureAwait(false);
                return data;
            }
        }
        #endregion
    }
}
