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

namespace Azure.ResourceManager.Compute
{
    /// <summary>
    /// A Class representing a CommunityGalleryImageVersion along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="CommunityGalleryImageVersionResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetCommunityGalleryImageVersionResource method.
    /// Otherwise you can get one from its parent resource <see cref="CommunityGalleryImageResource"/> using the GetCommunityGalleryImageVersion method.
    /// </summary>
    public partial class CommunityGalleryImageVersionResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="CommunityGalleryImageVersionResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="location"> The location. </param>
        /// <param name="publicGalleryName"> The publicGalleryName. </param>
        /// <param name="galleryImageName"> The galleryImageName. </param>
        /// <param name="galleryImageVersionName"> The galleryImageVersionName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, AzureLocation location, string publicGalleryName, string galleryImageName, string galleryImageVersionName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}/images/{galleryImageName}/versions/{galleryImageVersionName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _communityGalleryImageVersionClientDiagnostics;
        private readonly CommunityGalleryImageVersionsRestOperations _communityGalleryImageVersionRestClient;
        private readonly CommunityGalleryImageVersionData _data;

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/locations/communityGalleries/images/versions";

        /// <summary> Initializes a new instance of the <see cref="CommunityGalleryImageVersionResource"/> class for mocking. </summary>
        protected CommunityGalleryImageVersionResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="CommunityGalleryImageVersionResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal CommunityGalleryImageVersionResource(ArmClient client, CommunityGalleryImageVersionData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="CommunityGalleryImageVersionResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal CommunityGalleryImageVersionResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _communityGalleryImageVersionClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Compute", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string communityGalleryImageVersionApiVersion);
            _communityGalleryImageVersionRestClient = new CommunityGalleryImageVersionsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, communityGalleryImageVersionApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual CommunityGalleryImageVersionData Data
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
        /// Get a community gallery image version.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}/images/{galleryImageName}/versions/{galleryImageVersionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CommunityGalleryImageVersions_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-08-03</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CommunityGalleryImageVersionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<CommunityGalleryImageVersionResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _communityGalleryImageVersionClientDiagnostics.CreateScope("CommunityGalleryImageVersionResource.Get");
            scope.Start();
            try
            {
                var response = await _communityGalleryImageVersionRestClient.GetAsync(Id.SubscriptionId, new AzureLocation(Id.Parent.Parent.Parent.Name), Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                response.Value.Id = CreateResourceIdentifier(Id.SubscriptionId, new AzureLocation(Id.Parent.Parent.Parent.Name), Id.Parent.Parent.Name, Id.Parent.Name, Id.Name);
                return Response.FromValue(new CommunityGalleryImageVersionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a community gallery image version.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}/images/{galleryImageName}/versions/{galleryImageVersionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CommunityGalleryImageVersions_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-08-03</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CommunityGalleryImageVersionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<CommunityGalleryImageVersionResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _communityGalleryImageVersionClientDiagnostics.CreateScope("CommunityGalleryImageVersionResource.Get");
            scope.Start();
            try
            {
                var response = _communityGalleryImageVersionRestClient.Get(Id.SubscriptionId, new AzureLocation(Id.Parent.Parent.Parent.Name), Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                response.Value.Id = CreateResourceIdentifier(Id.SubscriptionId, new AzureLocation(Id.Parent.Parent.Parent.Name), Id.Parent.Parent.Name, Id.Parent.Name, Id.Name);
                return Response.FromValue(new CommunityGalleryImageVersionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
