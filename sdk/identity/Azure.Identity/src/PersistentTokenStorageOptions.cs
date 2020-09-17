// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity
{
    /// <summary>
    /// Options controlling the storage of the <see cref="PersistentTokenStorage"/>.
    /// </summary>
    public class PersistentTokenStorageOptions
    {
        /// <summary>
        /// Name uniquely identifying the <see cref="PersistentTokenStorage"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// If set to true the token cache may be persisted as an unencrypted file if no OS level user encryption is available. When set to false the <see cref="PersistentTokenStorage"/>
        /// will throw a <see cref="CredentialUnavailableException"/> in the event no OS level user encryption is available.
        /// </summary>
        public bool AllowUnencryptedStorage { get; set; }
    }
}
