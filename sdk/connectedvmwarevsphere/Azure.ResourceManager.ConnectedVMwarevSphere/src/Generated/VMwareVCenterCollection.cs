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

namespace Azure.ResourceManager.ConnectedVMwarevSphere
{
    /// <summary>
    /// A class representing a collection of <see cref="VMwareVCenterResource"/> and their operations.
    /// Each <see cref="VMwareVCenterResource"/> in the collection will belong to the same instance of <see cref="ResourceGroupResource"/>.
    /// To get a <see cref="VMwareVCenterCollection"/> instance call the GetVMwareVCenters method from an instance of <see cref="ResourceGroupResource"/>.
    /// </summary>
    public partial class VMwareVCenterCollection : ArmCollection, IEnumerable<VMwareVCenterResource>, IAsyncEnumerable<VMwareVCenterResource>
    {
        private readonly ClientDiagnostics _vMwareVCenterVCentersClientDiagnostics;
        private readonly VCentersRestOperations _vMwareVCenterVCentersRestClient;

        /// <summary> Initializes a new instance of the <see cref="VMwareVCenterCollection"/> class for mocking. </summary>
        protected VMwareVCenterCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="VMwareVCenterCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal VMwareVCenterCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _vMwareVCenterVCentersClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.ConnectedVMwarevSphere", VMwareVCenterResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(VMwareVCenterResource.ResourceType, out string vMwareVCenterVCentersApiVersion);
            _vMwareVCenterVCentersRestClient = new VCentersRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, vMwareVCenterVCentersApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroupResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroupResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create Or Update vCenter.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/vcenters/{vcenterName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VCenters_Create</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-10-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="VMwareVCenterResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vcenterName"> Name of the vCenter. </param>
        /// <param name="data"> Request payload. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vcenterName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vcenterName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<VMwareVCenterResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string vcenterName, VMwareVCenterData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vcenterName, nameof(vcenterName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _vMwareVCenterVCentersClientDiagnostics.CreateScope("VMwareVCenterCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _vMwareVCenterVCentersRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, vcenterName, data, cancellationToken).ConfigureAwait(false);
                var operation = new ConnectedVMwarevSphereArmOperation<VMwareVCenterResource>(new VMwareVCenterOperationSource(Client), _vMwareVCenterVCentersClientDiagnostics, Pipeline, _vMwareVCenterVCentersRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, vcenterName, data).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Create Or Update vCenter.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/vcenters/{vcenterName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VCenters_Create</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-10-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="VMwareVCenterResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vcenterName"> Name of the vCenter. </param>
        /// <param name="data"> Request payload. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vcenterName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vcenterName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<VMwareVCenterResource> CreateOrUpdate(WaitUntil waitUntil, string vcenterName, VMwareVCenterData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vcenterName, nameof(vcenterName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _vMwareVCenterVCentersClientDiagnostics.CreateScope("VMwareVCenterCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _vMwareVCenterVCentersRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, vcenterName, data, cancellationToken);
                var operation = new ConnectedVMwarevSphereArmOperation<VMwareVCenterResource>(new VMwareVCenterOperationSource(Client), _vMwareVCenterVCentersClientDiagnostics, Pipeline, _vMwareVCenterVCentersRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, vcenterName, data).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Implements vCenter GET method.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/vcenters/{vcenterName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VCenters_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-10-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="VMwareVCenterResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="vcenterName"> Name of the vCenter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vcenterName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vcenterName"/> is null. </exception>
        public virtual async Task<Response<VMwareVCenterResource>> GetAsync(string vcenterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vcenterName, nameof(vcenterName));

            using var scope = _vMwareVCenterVCentersClientDiagnostics.CreateScope("VMwareVCenterCollection.Get");
            scope.Start();
            try
            {
                var response = await _vMwareVCenterVCentersRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, vcenterName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VMwareVCenterResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Implements vCenter GET method.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/vcenters/{vcenterName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VCenters_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-10-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="VMwareVCenterResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="vcenterName"> Name of the vCenter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vcenterName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vcenterName"/> is null. </exception>
        public virtual Response<VMwareVCenterResource> Get(string vcenterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vcenterName, nameof(vcenterName));

            using var scope = _vMwareVCenterVCentersClientDiagnostics.CreateScope("VMwareVCenterCollection.Get");
            scope.Start();
            try
            {
                var response = _vMwareVCenterVCentersRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, vcenterName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VMwareVCenterResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List of vCenters in a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/vcenters</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VCenters_ListByResourceGroup</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-10-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="VMwareVCenterResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VMwareVCenterResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VMwareVCenterResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _vMwareVCenterVCentersRestClient.CreateListByResourceGroupRequest(Id.SubscriptionId, Id.ResourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _vMwareVCenterVCentersRestClient.CreateListByResourceGroupNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new VMwareVCenterResource(Client, VMwareVCenterData.DeserializeVMwareVCenterData(e)), _vMwareVCenterVCentersClientDiagnostics, Pipeline, "VMwareVCenterCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// List of vCenters in a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/vcenters</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VCenters_ListByResourceGroup</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-10-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="VMwareVCenterResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VMwareVCenterResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VMwareVCenterResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _vMwareVCenterVCentersRestClient.CreateListByResourceGroupRequest(Id.SubscriptionId, Id.ResourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _vMwareVCenterVCentersRestClient.CreateListByResourceGroupNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new VMwareVCenterResource(Client, VMwareVCenterData.DeserializeVMwareVCenterData(e)), _vMwareVCenterVCentersClientDiagnostics, Pipeline, "VMwareVCenterCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/vcenters/{vcenterName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VCenters_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-10-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="VMwareVCenterResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="vcenterName"> Name of the vCenter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vcenterName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vcenterName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string vcenterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vcenterName, nameof(vcenterName));

            using var scope = _vMwareVCenterVCentersClientDiagnostics.CreateScope("VMwareVCenterCollection.Exists");
            scope.Start();
            try
            {
                var response = await _vMwareVCenterVCentersRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, vcenterName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/vcenters/{vcenterName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VCenters_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-10-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="VMwareVCenterResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="vcenterName"> Name of the vCenter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vcenterName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vcenterName"/> is null. </exception>
        public virtual Response<bool> Exists(string vcenterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vcenterName, nameof(vcenterName));

            using var scope = _vMwareVCenterVCentersClientDiagnostics.CreateScope("VMwareVCenterCollection.Exists");
            scope.Start();
            try
            {
                var response = _vMwareVCenterVCentersRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, vcenterName, cancellationToken: cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/vcenters/{vcenterName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VCenters_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-10-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="VMwareVCenterResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="vcenterName"> Name of the vCenter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vcenterName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vcenterName"/> is null. </exception>
        public virtual async Task<NullableResponse<VMwareVCenterResource>> GetIfExistsAsync(string vcenterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vcenterName, nameof(vcenterName));

            using var scope = _vMwareVCenterVCentersClientDiagnostics.CreateScope("VMwareVCenterCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _vMwareVCenterVCentersRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, vcenterName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<VMwareVCenterResource>(response.GetRawResponse());
                return Response.FromValue(new VMwareVCenterResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/vcenters/{vcenterName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VCenters_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-10-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="VMwareVCenterResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="vcenterName"> Name of the vCenter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vcenterName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vcenterName"/> is null. </exception>
        public virtual NullableResponse<VMwareVCenterResource> GetIfExists(string vcenterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vcenterName, nameof(vcenterName));

            using var scope = _vMwareVCenterVCentersClientDiagnostics.CreateScope("VMwareVCenterCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _vMwareVCenterVCentersRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, vcenterName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<VMwareVCenterResource>(response.GetRawResponse());
                return Response.FromValue(new VMwareVCenterResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<VMwareVCenterResource> IEnumerable<VMwareVCenterResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<VMwareVCenterResource> IAsyncEnumerable<VMwareVCenterResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
