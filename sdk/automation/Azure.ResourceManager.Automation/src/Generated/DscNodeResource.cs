// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Automation.Models;

namespace Azure.ResourceManager.Automation
{
    /// <summary>
    /// A Class representing a DscNode along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="DscNodeResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetDscNodeResource method.
    /// Otherwise you can get one from its parent resource <see cref="AutomationAccountResource"/> using the GetDscNode method.
    /// </summary>
    public partial class DscNodeResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="DscNodeResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="automationAccountName"> The automationAccountName. </param>
        /// <param name="nodeId"> The nodeId. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string nodeId)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodes/{nodeId}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _dscNodeClientDiagnostics;
        private readonly DscNodeRestOperations _dscNodeRestClient;
        private readonly ClientDiagnostics _nodeReportsClientDiagnostics;
        private readonly NodeReportsRestOperations _nodeReportsRestClient;
        private readonly DscNodeData _data;

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Automation/automationAccounts/nodes";

        /// <summary> Initializes a new instance of the <see cref="DscNodeResource"/> class for mocking. </summary>
        protected DscNodeResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="DscNodeResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal DscNodeResource(ArmClient client, DscNodeData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="DscNodeResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal DscNodeResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _dscNodeClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Automation", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string dscNodeApiVersion);
            _dscNodeRestClient = new DscNodeRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, dscNodeApiVersion);
            _nodeReportsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Automation", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _nodeReportsRestClient = new NodeReportsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual DscNodeData Data
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
        /// Retrieve the dsc node identified by node id.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodes/{nodeId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DscNode_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-01-13-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DscNodeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DscNodeResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _dscNodeClientDiagnostics.CreateScope("DscNodeResource.Get");
            scope.Start();
            try
            {
                var response = await _dscNodeRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DscNodeResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieve the dsc node identified by node id.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodes/{nodeId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DscNode_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-01-13-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DscNodeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DscNodeResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _dscNodeClientDiagnostics.CreateScope("DscNodeResource.Get");
            scope.Start();
            try
            {
                var response = _dscNodeRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DscNodeResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete the dsc node identified by node id.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodes/{nodeId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DscNode_Delete</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-01-13-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DscNodeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _dscNodeClientDiagnostics.CreateScope("DscNodeResource.Delete");
            scope.Start();
            try
            {
                var response = await _dscNodeRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new AutomationArmOperation(response);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete the dsc node identified by node id.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodes/{nodeId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DscNode_Delete</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-01-13-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DscNodeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _dscNodeClientDiagnostics.CreateScope("DscNodeResource.Delete");
            scope.Start();
            try
            {
                var response = _dscNodeRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new AutomationArmOperation(response);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Update the dsc node.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodes/{nodeId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DscNode_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-01-13-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DscNodeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> Parameters supplied to the update dsc node. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual async Task<Response<DscNodeResource>> UpdateAsync(DscNodePatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using var scope = _dscNodeClientDiagnostics.CreateScope("DscNodeResource.Update");
            scope.Start();
            try
            {
                var response = await _dscNodeRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, patch, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new DscNodeResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Update the dsc node.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodes/{nodeId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DscNode_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-01-13-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DscNodeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> Parameters supplied to the update dsc node. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual Response<DscNodeResource> Update(DscNodePatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using var scope = _dscNodeClientDiagnostics.CreateScope("DscNodeResource.Update");
            scope.Start();
            try
            {
                var response = _dscNodeRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, patch, cancellationToken);
                return Response.FromValue(new DscNodeResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieve the Dsc node report list by node id.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodes/{nodeId}/reports</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NodeReports_ListByNode</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-01-13-preview</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DscNodeReport"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DscNodeReport> GetNodeReportsByNodeAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _nodeReportsRestClient.CreateListByNodeRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _nodeReportsRestClient.CreateListByNodeNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, DscNodeReport.DeserializeDscNodeReport, _nodeReportsClientDiagnostics, Pipeline, "DscNodeResource.GetNodeReportsByNode", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Retrieve the Dsc node report list by node id.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodes/{nodeId}/reports</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NodeReports_ListByNode</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-01-13-preview</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DscNodeReport"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DscNodeReport> GetNodeReportsByNode(string filter = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _nodeReportsRestClient.CreateListByNodeRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _nodeReportsRestClient.CreateListByNodeNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, DscNodeReport.DeserializeDscNodeReport, _nodeReportsClientDiagnostics, Pipeline, "DscNodeResource.GetNodeReportsByNode", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Retrieve the Dsc node report data by node id and report id.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodes/{nodeId}/reports/{reportId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NodeReports_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-01-13-preview</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="reportId"> The report id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="reportId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="reportId"/> is null. </exception>
        public virtual async Task<Response<DscNodeReport>> GetNodeReportAsync(string reportId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(reportId, nameof(reportId));

            using var scope = _nodeReportsClientDiagnostics.CreateScope("DscNodeResource.GetNodeReport");
            scope.Start();
            try
            {
                var response = await _nodeReportsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, reportId, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieve the Dsc node report data by node id and report id.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodes/{nodeId}/reports/{reportId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NodeReports_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-01-13-preview</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="reportId"> The report id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="reportId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="reportId"/> is null. </exception>
        public virtual Response<DscNodeReport> GetNodeReport(string reportId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(reportId, nameof(reportId));

            using var scope = _nodeReportsClientDiagnostics.CreateScope("DscNodeResource.GetNodeReport");
            scope.Start();
            try
            {
                var response = _nodeReportsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, reportId, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieve the Dsc node reports by node id and report id.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodes/{nodeId}/reports/{reportId}/content</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NodeReports_GetContent</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-01-13-preview</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="reportId"> The report id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="reportId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="reportId"/> is null. </exception>
        public virtual async Task<Response<BinaryData>> GetContentNodeReportAsync(string reportId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(reportId, nameof(reportId));

            using var scope = _nodeReportsClientDiagnostics.CreateScope("DscNodeResource.GetContentNodeReport");
            scope.Start();
            try
            {
                var response = await _nodeReportsRestClient.GetContentAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, reportId, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieve the Dsc node reports by node id and report id.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodes/{nodeId}/reports/{reportId}/content</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NodeReports_GetContent</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-01-13-preview</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="reportId"> The report id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="reportId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="reportId"/> is null. </exception>
        public virtual Response<BinaryData> GetContentNodeReport(string reportId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(reportId, nameof(reportId));

            using var scope = _nodeReportsClientDiagnostics.CreateScope("DscNodeResource.GetContentNodeReport");
            scope.Start();
            try
            {
                var response = _nodeReportsRestClient.GetContent(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, reportId, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
