// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensions.Msal;

namespace Azure.Identity
{
    internal abstract class MsalClientBase<TClient> where TClient : IClientApplicationBase
    {
        private readonly AsyncLockWithValue<TClient> _clientAsyncLock;

        /// <summary>
        /// For mocking purposes only.
        /// </summary>
        protected MsalClientBase()
        {
        }

        protected MsalClientBase(CredentialPipeline pipeline, string tenantId, string clientId, ITokenCacheOptions cacheOptions)
        {
            Pipeline = pipeline;

            TenantId = tenantId;

            ClientId = clientId;

            TokenStorage = cacheOptions?.TokenStorage;

            _clientAsyncLock = new AsyncLockWithValue<TClient>();
        }

        internal string TenantId { get; }

        internal string ClientId { get; }

        internal TokenStorage TokenStorage { get; }

        protected CredentialPipeline Pipeline { get; }

        protected abstract ValueTask<TClient> CreateClientAsync(bool async, CancellationToken cancellationToken);

        protected async ValueTask<TClient> GetClientAsync(bool async, CancellationToken cancellationToken)
        {
            using var asyncLock = await _clientAsyncLock.GetLockOrValueAsync(async, cancellationToken).ConfigureAwait(false);
            if (asyncLock.HasValue)
            {
                return asyncLock.Value;
            }

            var client = await CreateClientAsync(async, cancellationToken).ConfigureAwait(false);

            if (TokenStorage != default)
            {
                if (async)
                {
                    await TokenStorage.RegisterAsync(new TokenCache(client.UserTokenCache), cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    TokenStorage.Register(new TokenCache(client.UserTokenCache), cancellationToken);
                }
            }

            asyncLock.SetValue(client);
            return client;
        }

        private static async ValueTask<MsalCacheHelper> CreateCacheHelper(StorageCreationProperties storageProperties, bool async)
        {
            return async
                ? await MsalCacheHelper.CreateAsync(storageProperties).ConfigureAwait(false)
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
                : MsalCacheHelper.CreateAsync(storageProperties).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
        }
    }
}
