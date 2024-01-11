// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Synapse.Models;

namespace Azure.ResourceManager.Synapse
{
    /// <summary>
    /// A Class representing a SynapseServerSecurityAlertPolicy along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="SynapseServerSecurityAlertPolicyResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetSynapseServerSecurityAlertPolicyResource method.
    /// Otherwise you can get one from its parent resource <see cref="SynapseWorkspaceResource"/> using the GetSynapseServerSecurityAlertPolicy method.
    /// </summary>
    public partial class SynapseServerSecurityAlertPolicyResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="SynapseServerSecurityAlertPolicyResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="workspaceName"> The workspaceName. </param>
        /// <param name="securityAlertPolicyName"> The securityAlertPolicyName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, SqlServerSecurityAlertPolicyName securityAlertPolicyName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/securityAlertPolicies/{securityAlertPolicyName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _synapseServerSecurityAlertPolicyWorkspaceManagedSqlServerSecurityAlertPolicyClientDiagnostics;
        private readonly WorkspaceManagedSqlServerSecurityAlertPolicyRestOperations _synapseServerSecurityAlertPolicyWorkspaceManagedSqlServerSecurityAlertPolicyRestClient;
        private readonly SynapseServerSecurityAlertPolicyData _data;

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Synapse/workspaces/securityAlertPolicies";

        /// <summary> Initializes a new instance of the <see cref="SynapseServerSecurityAlertPolicyResource"/> class for mocking. </summary>
        protected SynapseServerSecurityAlertPolicyResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SynapseServerSecurityAlertPolicyResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal SynapseServerSecurityAlertPolicyResource(ArmClient client, SynapseServerSecurityAlertPolicyData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="SynapseServerSecurityAlertPolicyResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SynapseServerSecurityAlertPolicyResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _synapseServerSecurityAlertPolicyWorkspaceManagedSqlServerSecurityAlertPolicyClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Synapse", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string synapseServerSecurityAlertPolicyWorkspaceManagedSqlServerSecurityAlertPolicyApiVersion);
            _synapseServerSecurityAlertPolicyWorkspaceManagedSqlServerSecurityAlertPolicyRestClient = new WorkspaceManagedSqlServerSecurityAlertPolicyRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, synapseServerSecurityAlertPolicyWorkspaceManagedSqlServerSecurityAlertPolicyApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual SynapseServerSecurityAlertPolicyData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Get a workspace managed sql server's security alert policy.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/securityAlertPolicies/{securityAlertPolicyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkspaceManagedSqlServerSecurityAlertPolicy_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SynapseServerSecurityAlertPolicyResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SynapseServerSecurityAlertPolicyResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _synapseServerSecurityAlertPolicyWorkspaceManagedSqlServerSecurityAlertPolicyClientDiagnostics.CreateScope("SynapseServerSecurityAlertPolicyResource.Get");
            scope.Start();
            try
            {
                var response = await _synapseServerSecurityAlertPolicyWorkspaceManagedSqlServerSecurityAlertPolicyRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SynapseServerSecurityAlertPolicyResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a workspace managed sql server's security alert policy.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/securityAlertPolicies/{securityAlertPolicyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkspaceManagedSqlServerSecurityAlertPolicy_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SynapseServerSecurityAlertPolicyResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SynapseServerSecurityAlertPolicyResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _synapseServerSecurityAlertPolicyWorkspaceManagedSqlServerSecurityAlertPolicyClientDiagnostics.CreateScope("SynapseServerSecurityAlertPolicyResource.Get");
            scope.Start();
            try
            {
                var response = _synapseServerSecurityAlertPolicyWorkspaceManagedSqlServerSecurityAlertPolicyRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SynapseServerSecurityAlertPolicyResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create or Update a workspace managed sql server's threat detection policy.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/securityAlertPolicies/{securityAlertPolicyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkspaceManagedSqlServerSecurityAlertPolicy_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SynapseServerSecurityAlertPolicyResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The workspace managed sql server security alert policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<SynapseServerSecurityAlertPolicyResource>> UpdateAsync(WaitUntil waitUntil, SynapseServerSecurityAlertPolicyData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _synapseServerSecurityAlertPolicyWorkspaceManagedSqlServerSecurityAlertPolicyClientDiagnostics.CreateScope("SynapseServerSecurityAlertPolicyResource.Update");
            scope.Start();
            try
            {
                var response = await _synapseServerSecurityAlertPolicyWorkspaceManagedSqlServerSecurityAlertPolicyRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data, cancellationToken).ConfigureAwait(false);
                var operation = new SynapseArmOperation<SynapseServerSecurityAlertPolicyResource>(new SynapseServerSecurityAlertPolicyOperationSource(Client), _synapseServerSecurityAlertPolicyWorkspaceManagedSqlServerSecurityAlertPolicyClientDiagnostics, Pipeline, _synapseServerSecurityAlertPolicyWorkspaceManagedSqlServerSecurityAlertPolicyRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data).Request, response, OperationFinalStateVia.Location);
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
        /// Create or Update a workspace managed sql server's threat detection policy.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/securityAlertPolicies/{securityAlertPolicyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkspaceManagedSqlServerSecurityAlertPolicy_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SynapseServerSecurityAlertPolicyResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The workspace managed sql server security alert policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<SynapseServerSecurityAlertPolicyResource> Update(WaitUntil waitUntil, SynapseServerSecurityAlertPolicyData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _synapseServerSecurityAlertPolicyWorkspaceManagedSqlServerSecurityAlertPolicyClientDiagnostics.CreateScope("SynapseServerSecurityAlertPolicyResource.Update");
            scope.Start();
            try
            {
                var response = _synapseServerSecurityAlertPolicyWorkspaceManagedSqlServerSecurityAlertPolicyRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data, cancellationToken);
                var operation = new SynapseArmOperation<SynapseServerSecurityAlertPolicyResource>(new SynapseServerSecurityAlertPolicyOperationSource(Client), _synapseServerSecurityAlertPolicyWorkspaceManagedSqlServerSecurityAlertPolicyClientDiagnostics, Pipeline, _synapseServerSecurityAlertPolicyWorkspaceManagedSqlServerSecurityAlertPolicyRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data).Request, response, OperationFinalStateVia.Location);
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
    }
}
