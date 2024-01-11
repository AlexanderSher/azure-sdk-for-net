// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.SecurityCenter
{
    /// <summary>
    /// A class representing a collection of <see cref="SecurityWorkspaceSettingResource"/> and their operations.
    /// Each <see cref="SecurityWorkspaceSettingResource"/> in the collection will belong to the same instance of <see cref="SubscriptionResource"/>.
    /// To get a <see cref="SecurityWorkspaceSettingCollection"/> instance call the GetSecurityWorkspaceSettings method from an instance of <see cref="SubscriptionResource"/>.
    /// </summary>
    public partial class SecurityWorkspaceSettingCollection : ArmCollection, IEnumerable<SecurityWorkspaceSettingResource>, IAsyncEnumerable<SecurityWorkspaceSettingResource>
    {
        private readonly ClientDiagnostics _securityWorkspaceSettingWorkspaceSettingsClientDiagnostics;
        private readonly WorkspaceSettingsRestOperations _securityWorkspaceSettingWorkspaceSettingsRestClient;

        /// <summary> Initializes a new instance of the <see cref="SecurityWorkspaceSettingCollection"/> class for mocking. </summary>
        protected SecurityWorkspaceSettingCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SecurityWorkspaceSettingCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SecurityWorkspaceSettingCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _securityWorkspaceSettingWorkspaceSettingsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.SecurityCenter", SecurityWorkspaceSettingResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SecurityWorkspaceSettingResource.ResourceType, out string securityWorkspaceSettingWorkspaceSettingsApiVersion);
            _securityWorkspaceSettingWorkspaceSettingsRestClient = new WorkspaceSettingsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, securityWorkspaceSettingWorkspaceSettingsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SubscriptionResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SubscriptionResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// creating settings about where we should store your security data and logs
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Security/workspaceSettings/{workspaceSettingName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkspaceSettings_Create</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-08-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SecurityWorkspaceSettingResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="workspaceSettingName"> Name of the security setting. </param>
        /// <param name="data"> Security data setting object. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="workspaceSettingName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="workspaceSettingName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<SecurityWorkspaceSettingResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string workspaceSettingName, SecurityWorkspaceSettingData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(workspaceSettingName, nameof(workspaceSettingName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _securityWorkspaceSettingWorkspaceSettingsClientDiagnostics.CreateScope("SecurityWorkspaceSettingCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _securityWorkspaceSettingWorkspaceSettingsRestClient.CreateAsync(Id.SubscriptionId, workspaceSettingName, data, cancellationToken).ConfigureAwait(false);
                var operation = new SecurityCenterArmOperation<SecurityWorkspaceSettingResource>(Response.FromValue(new SecurityWorkspaceSettingResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// creating settings about where we should store your security data and logs
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Security/workspaceSettings/{workspaceSettingName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkspaceSettings_Create</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-08-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SecurityWorkspaceSettingResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="workspaceSettingName"> Name of the security setting. </param>
        /// <param name="data"> Security data setting object. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="workspaceSettingName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="workspaceSettingName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<SecurityWorkspaceSettingResource> CreateOrUpdate(WaitUntil waitUntil, string workspaceSettingName, SecurityWorkspaceSettingData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(workspaceSettingName, nameof(workspaceSettingName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _securityWorkspaceSettingWorkspaceSettingsClientDiagnostics.CreateScope("SecurityWorkspaceSettingCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _securityWorkspaceSettingWorkspaceSettingsRestClient.Create(Id.SubscriptionId, workspaceSettingName, data, cancellationToken);
                var operation = new SecurityCenterArmOperation<SecurityWorkspaceSettingResource>(Response.FromValue(new SecurityWorkspaceSettingResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Settings about where we should store your security data and logs. If the result is empty, it means that no custom-workspace configuration was set
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Security/workspaceSettings/{workspaceSettingName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkspaceSettings_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-08-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SecurityWorkspaceSettingResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="workspaceSettingName"> Name of the security setting. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="workspaceSettingName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="workspaceSettingName"/> is null. </exception>
        public virtual async Task<Response<SecurityWorkspaceSettingResource>> GetAsync(string workspaceSettingName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(workspaceSettingName, nameof(workspaceSettingName));

            using var scope = _securityWorkspaceSettingWorkspaceSettingsClientDiagnostics.CreateScope("SecurityWorkspaceSettingCollection.Get");
            scope.Start();
            try
            {
                var response = await _securityWorkspaceSettingWorkspaceSettingsRestClient.GetAsync(Id.SubscriptionId, workspaceSettingName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SecurityWorkspaceSettingResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Settings about where we should store your security data and logs. If the result is empty, it means that no custom-workspace configuration was set
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Security/workspaceSettings/{workspaceSettingName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkspaceSettings_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-08-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SecurityWorkspaceSettingResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="workspaceSettingName"> Name of the security setting. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="workspaceSettingName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="workspaceSettingName"/> is null. </exception>
        public virtual Response<SecurityWorkspaceSettingResource> Get(string workspaceSettingName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(workspaceSettingName, nameof(workspaceSettingName));

            using var scope = _securityWorkspaceSettingWorkspaceSettingsClientDiagnostics.CreateScope("SecurityWorkspaceSettingCollection.Get");
            scope.Start();
            try
            {
                var response = _securityWorkspaceSettingWorkspaceSettingsRestClient.Get(Id.SubscriptionId, workspaceSettingName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SecurityWorkspaceSettingResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Settings about where we should store your security data and logs. If the result is empty, it means that no custom-workspace configuration was set
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Security/workspaceSettings</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkspaceSettings_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-08-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SecurityWorkspaceSettingResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SecurityWorkspaceSettingResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SecurityWorkspaceSettingResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _securityWorkspaceSettingWorkspaceSettingsRestClient.CreateListRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _securityWorkspaceSettingWorkspaceSettingsRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new SecurityWorkspaceSettingResource(Client, SecurityWorkspaceSettingData.DeserializeSecurityWorkspaceSettingData(e)), _securityWorkspaceSettingWorkspaceSettingsClientDiagnostics, Pipeline, "SecurityWorkspaceSettingCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Settings about where we should store your security data and logs. If the result is empty, it means that no custom-workspace configuration was set
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Security/workspaceSettings</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkspaceSettings_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-08-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SecurityWorkspaceSettingResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SecurityWorkspaceSettingResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SecurityWorkspaceSettingResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _securityWorkspaceSettingWorkspaceSettingsRestClient.CreateListRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _securityWorkspaceSettingWorkspaceSettingsRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new SecurityWorkspaceSettingResource(Client, SecurityWorkspaceSettingData.DeserializeSecurityWorkspaceSettingData(e)), _securityWorkspaceSettingWorkspaceSettingsClientDiagnostics, Pipeline, "SecurityWorkspaceSettingCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Security/workspaceSettings/{workspaceSettingName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkspaceSettings_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-08-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SecurityWorkspaceSettingResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="workspaceSettingName"> Name of the security setting. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="workspaceSettingName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="workspaceSettingName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string workspaceSettingName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(workspaceSettingName, nameof(workspaceSettingName));

            using var scope = _securityWorkspaceSettingWorkspaceSettingsClientDiagnostics.CreateScope("SecurityWorkspaceSettingCollection.Exists");
            scope.Start();
            try
            {
                var response = await _securityWorkspaceSettingWorkspaceSettingsRestClient.GetAsync(Id.SubscriptionId, workspaceSettingName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Security/workspaceSettings/{workspaceSettingName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkspaceSettings_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-08-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SecurityWorkspaceSettingResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="workspaceSettingName"> Name of the security setting. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="workspaceSettingName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="workspaceSettingName"/> is null. </exception>
        public virtual Response<bool> Exists(string workspaceSettingName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(workspaceSettingName, nameof(workspaceSettingName));

            using var scope = _securityWorkspaceSettingWorkspaceSettingsClientDiagnostics.CreateScope("SecurityWorkspaceSettingCollection.Exists");
            scope.Start();
            try
            {
                var response = _securityWorkspaceSettingWorkspaceSettingsRestClient.Get(Id.SubscriptionId, workspaceSettingName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Security/workspaceSettings/{workspaceSettingName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkspaceSettings_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-08-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SecurityWorkspaceSettingResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="workspaceSettingName"> Name of the security setting. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="workspaceSettingName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="workspaceSettingName"/> is null. </exception>
        public virtual async Task<NullableResponse<SecurityWorkspaceSettingResource>> GetIfExistsAsync(string workspaceSettingName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(workspaceSettingName, nameof(workspaceSettingName));

            using var scope = _securityWorkspaceSettingWorkspaceSettingsClientDiagnostics.CreateScope("SecurityWorkspaceSettingCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _securityWorkspaceSettingWorkspaceSettingsRestClient.GetAsync(Id.SubscriptionId, workspaceSettingName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<SecurityWorkspaceSettingResource>(response.GetRawResponse());
                return Response.FromValue(new SecurityWorkspaceSettingResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Security/workspaceSettings/{workspaceSettingName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkspaceSettings_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-08-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SecurityWorkspaceSettingResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="workspaceSettingName"> Name of the security setting. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="workspaceSettingName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="workspaceSettingName"/> is null. </exception>
        public virtual NullableResponse<SecurityWorkspaceSettingResource> GetIfExists(string workspaceSettingName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(workspaceSettingName, nameof(workspaceSettingName));

            using var scope = _securityWorkspaceSettingWorkspaceSettingsClientDiagnostics.CreateScope("SecurityWorkspaceSettingCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _securityWorkspaceSettingWorkspaceSettingsRestClient.Get(Id.SubscriptionId, workspaceSettingName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<SecurityWorkspaceSettingResource>(response.GetRawResponse());
                return Response.FromValue(new SecurityWorkspaceSettingResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SecurityWorkspaceSettingResource> IEnumerable<SecurityWorkspaceSettingResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SecurityWorkspaceSettingResource> IAsyncEnumerable<SecurityWorkspaceSettingResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
