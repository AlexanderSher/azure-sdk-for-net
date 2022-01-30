// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The secrets of Storage Account Local User. </summary>
    public partial class LocalUserRegeneratePasswordResult
    {
        /// <summary> Initializes a new instance of LocalUserRegeneratePasswordResult. </summary>
        internal LocalUserRegeneratePasswordResult()
        {
        }

        /// <summary> Initializes a new instance of LocalUserRegeneratePasswordResult. </summary>
        /// <param name="sshPassword"> Auto generated password by the server for SSH authentication if hasSshPassword is set to true on the creation of local user. </param>
        internal LocalUserRegeneratePasswordResult(string sshPassword)
        {
            SshPassword = sshPassword;
        }

        /// <summary> Auto generated password by the server for SSH authentication if hasSshPassword is set to true on the creation of local user. </summary>
        public string SshPassword { get; }
    }
}
