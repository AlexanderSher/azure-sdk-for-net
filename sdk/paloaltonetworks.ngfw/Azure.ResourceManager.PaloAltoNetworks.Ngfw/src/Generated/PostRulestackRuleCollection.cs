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

namespace Azure.ResourceManager.PaloAltoNetworks.Ngfw
{
    /// <summary>
    /// A class representing a collection of <see cref="PostRulestackRuleResource"/> and their operations.
    /// Each <see cref="PostRulestackRuleResource"/> in the collection will belong to the same instance of <see cref="GlobalRulestackResource"/>.
    /// To get a <see cref="PostRulestackRuleCollection"/> instance call the GetPostRulestackRules method from an instance of <see cref="GlobalRulestackResource"/>.
    /// </summary>
    public partial class PostRulestackRuleCollection : ArmCollection, IEnumerable<PostRulestackRuleResource>, IAsyncEnumerable<PostRulestackRuleResource>
    {
        private readonly ClientDiagnostics _postRulestackRulePostRulesClientDiagnostics;
        private readonly PostRulesRestOperations _postRulestackRulePostRulesRestClient;

        /// <summary> Initializes a new instance of the <see cref="PostRulestackRuleCollection"/> class for mocking. </summary>
        protected PostRulestackRuleCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="PostRulestackRuleCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal PostRulestackRuleCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _postRulestackRulePostRulesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.PaloAltoNetworks.Ngfw", PostRulestackRuleResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(PostRulestackRuleResource.ResourceType, out string postRulestackRulePostRulesApiVersion);
            _postRulestackRulePostRulesRestClient = new PostRulesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, postRulestackRulePostRulesApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != GlobalRulestackResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, GlobalRulestackResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create a PostRulesResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/PaloAltoNetworks.Cloudngfw/globalRulestacks/{globalRulestackName}/postRules/{priority}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PostRules_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PostRulestackRuleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="priority"> Post Rule priority. </param>
        /// <param name="data"> Resource create parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="priority"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="priority"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<PostRulestackRuleResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string priority, PostRulestackRuleData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(priority, nameof(priority));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _postRulestackRulePostRulesClientDiagnostics.CreateScope("PostRulestackRuleCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _postRulestackRulePostRulesRestClient.CreateOrUpdateAsync(Id.Name, priority, data, cancellationToken).ConfigureAwait(false);
                var operation = new NgfwArmOperation<PostRulestackRuleResource>(new PostRulestackRuleOperationSource(Client), _postRulestackRulePostRulesClientDiagnostics, Pipeline, _postRulestackRulePostRulesRestClient.CreateCreateOrUpdateRequest(Id.Name, priority, data).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Create a PostRulesResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/PaloAltoNetworks.Cloudngfw/globalRulestacks/{globalRulestackName}/postRules/{priority}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PostRules_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PostRulestackRuleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="priority"> Post Rule priority. </param>
        /// <param name="data"> Resource create parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="priority"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="priority"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<PostRulestackRuleResource> CreateOrUpdate(WaitUntil waitUntil, string priority, PostRulestackRuleData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(priority, nameof(priority));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _postRulestackRulePostRulesClientDiagnostics.CreateScope("PostRulestackRuleCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _postRulestackRulePostRulesRestClient.CreateOrUpdate(Id.Name, priority, data, cancellationToken);
                var operation = new NgfwArmOperation<PostRulestackRuleResource>(new PostRulestackRuleOperationSource(Client), _postRulestackRulePostRulesClientDiagnostics, Pipeline, _postRulestackRulePostRulesRestClient.CreateCreateOrUpdateRequest(Id.Name, priority, data).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Get a PostRulesResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/PaloAltoNetworks.Cloudngfw/globalRulestacks/{globalRulestackName}/postRules/{priority}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PostRules_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PostRulestackRuleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="priority"> Post Rule priority. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="priority"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="priority"/> is null. </exception>
        public virtual async Task<Response<PostRulestackRuleResource>> GetAsync(string priority, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(priority, nameof(priority));

            using var scope = _postRulestackRulePostRulesClientDiagnostics.CreateScope("PostRulestackRuleCollection.Get");
            scope.Start();
            try
            {
                var response = await _postRulestackRulePostRulesRestClient.GetAsync(Id.Name, priority, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PostRulestackRuleResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a PostRulesResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/PaloAltoNetworks.Cloudngfw/globalRulestacks/{globalRulestackName}/postRules/{priority}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PostRules_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PostRulestackRuleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="priority"> Post Rule priority. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="priority"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="priority"/> is null. </exception>
        public virtual Response<PostRulestackRuleResource> Get(string priority, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(priority, nameof(priority));

            using var scope = _postRulestackRulePostRulesClientDiagnostics.CreateScope("PostRulestackRuleCollection.Get");
            scope.Start();
            try
            {
                var response = _postRulestackRulePostRulesRestClient.Get(Id.Name, priority, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PostRulestackRuleResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List PostRulesResource resources by Tenant
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/PaloAltoNetworks.Cloudngfw/globalRulestacks/{globalRulestackName}/postRules</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PostRules_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PostRulestackRuleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PostRulestackRuleResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PostRulestackRuleResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _postRulestackRulePostRulesRestClient.CreateListRequest(Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _postRulestackRulePostRulesRestClient.CreateListNextPageRequest(nextLink, Id.Name);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new PostRulestackRuleResource(Client, PostRulestackRuleData.DeserializePostRulestackRuleData(e)), _postRulestackRulePostRulesClientDiagnostics, Pipeline, "PostRulestackRuleCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// List PostRulesResource resources by Tenant
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/PaloAltoNetworks.Cloudngfw/globalRulestacks/{globalRulestackName}/postRules</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PostRules_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PostRulestackRuleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PostRulestackRuleResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PostRulestackRuleResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _postRulestackRulePostRulesRestClient.CreateListRequest(Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _postRulestackRulePostRulesRestClient.CreateListNextPageRequest(nextLink, Id.Name);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new PostRulestackRuleResource(Client, PostRulestackRuleData.DeserializePostRulestackRuleData(e)), _postRulestackRulePostRulesClientDiagnostics, Pipeline, "PostRulestackRuleCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/PaloAltoNetworks.Cloudngfw/globalRulestacks/{globalRulestackName}/postRules/{priority}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PostRules_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PostRulestackRuleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="priority"> Post Rule priority. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="priority"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="priority"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string priority, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(priority, nameof(priority));

            using var scope = _postRulestackRulePostRulesClientDiagnostics.CreateScope("PostRulestackRuleCollection.Exists");
            scope.Start();
            try
            {
                var response = await _postRulestackRulePostRulesRestClient.GetAsync(Id.Name, priority, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/providers/PaloAltoNetworks.Cloudngfw/globalRulestacks/{globalRulestackName}/postRules/{priority}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PostRules_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PostRulestackRuleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="priority"> Post Rule priority. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="priority"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="priority"/> is null. </exception>
        public virtual Response<bool> Exists(string priority, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(priority, nameof(priority));

            using var scope = _postRulestackRulePostRulesClientDiagnostics.CreateScope("PostRulestackRuleCollection.Exists");
            scope.Start();
            try
            {
                var response = _postRulestackRulePostRulesRestClient.Get(Id.Name, priority, cancellationToken: cancellationToken);
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
        /// <description>/providers/PaloAltoNetworks.Cloudngfw/globalRulestacks/{globalRulestackName}/postRules/{priority}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PostRules_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PostRulestackRuleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="priority"> Post Rule priority. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="priority"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="priority"/> is null. </exception>
        public virtual async Task<NullableResponse<PostRulestackRuleResource>> GetIfExistsAsync(string priority, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(priority, nameof(priority));

            using var scope = _postRulestackRulePostRulesClientDiagnostics.CreateScope("PostRulestackRuleCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _postRulestackRulePostRulesRestClient.GetAsync(Id.Name, priority, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<PostRulestackRuleResource>(response.GetRawResponse());
                return Response.FromValue(new PostRulestackRuleResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/providers/PaloAltoNetworks.Cloudngfw/globalRulestacks/{globalRulestackName}/postRules/{priority}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PostRules_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PostRulestackRuleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="priority"> Post Rule priority. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="priority"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="priority"/> is null. </exception>
        public virtual NullableResponse<PostRulestackRuleResource> GetIfExists(string priority, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(priority, nameof(priority));

            using var scope = _postRulestackRulePostRulesClientDiagnostics.CreateScope("PostRulestackRuleCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _postRulestackRulePostRulesRestClient.Get(Id.Name, priority, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<PostRulestackRuleResource>(response.GetRawResponse());
                return Response.FromValue(new PostRulestackRuleResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<PostRulestackRuleResource> IEnumerable<PostRulestackRuleResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<PostRulestackRuleResource> IAsyncEnumerable<PostRulestackRuleResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
