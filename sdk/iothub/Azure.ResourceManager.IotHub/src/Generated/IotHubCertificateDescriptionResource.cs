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
using Azure.ResourceManager.IotHub.Models;

namespace Azure.ResourceManager.IotHub
{
    /// <summary>
    /// A Class representing an IotHubCertificateDescription along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct an <see cref="IotHubCertificateDescriptionResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetIotHubCertificateDescriptionResource method.
    /// Otherwise you can get one from its parent resource <see cref="IotHubDescriptionResource"/> using the GetIotHubCertificateDescription method.
    /// </summary>
    public partial class IotHubCertificateDescriptionResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="IotHubCertificateDescriptionResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="resourceName"> The resourceName. </param>
        /// <param name="certificateName"> The certificateName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string certificateName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/IotHubs/{resourceName}/certificates/{certificateName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _iotHubCertificateDescriptionCertificatesClientDiagnostics;
        private readonly CertificatesRestOperations _iotHubCertificateDescriptionCertificatesRestClient;
        private readonly IotHubCertificateDescriptionData _data;

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Devices/IotHubs/certificates";

        /// <summary> Initializes a new instance of the <see cref="IotHubCertificateDescriptionResource"/> class for mocking. </summary>
        protected IotHubCertificateDescriptionResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="IotHubCertificateDescriptionResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal IotHubCertificateDescriptionResource(ArmClient client, IotHubCertificateDescriptionData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="IotHubCertificateDescriptionResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal IotHubCertificateDescriptionResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _iotHubCertificateDescriptionCertificatesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.IotHub", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string iotHubCertificateDescriptionCertificatesApiVersion);
            _iotHubCertificateDescriptionCertificatesRestClient = new CertificatesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, iotHubCertificateDescriptionCertificatesApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual IotHubCertificateDescriptionData Data
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
        /// Returns the certificate.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/IotHubs/{resourceName}/certificates/{certificateName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Certificates_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-06-30</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="IotHubCertificateDescriptionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IotHubCertificateDescriptionResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _iotHubCertificateDescriptionCertificatesClientDiagnostics.CreateScope("IotHubCertificateDescriptionResource.Get");
            scope.Start();
            try
            {
                var response = await _iotHubCertificateDescriptionCertificatesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new IotHubCertificateDescriptionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Returns the certificate.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/IotHubs/{resourceName}/certificates/{certificateName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Certificates_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-06-30</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="IotHubCertificateDescriptionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IotHubCertificateDescriptionResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _iotHubCertificateDescriptionCertificatesClientDiagnostics.CreateScope("IotHubCertificateDescriptionResource.Get");
            scope.Start();
            try
            {
                var response = _iotHubCertificateDescriptionCertificatesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new IotHubCertificateDescriptionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes an existing X509 certificate or does nothing if it does not exist.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/IotHubs/{resourceName}/certificates/{certificateName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Certificates_Delete</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-06-30</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="IotHubCertificateDescriptionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ifMatch"> ETag of the Certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> is null. </exception>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, string ifMatch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(ifMatch, nameof(ifMatch));

            using var scope = _iotHubCertificateDescriptionCertificatesClientDiagnostics.CreateScope("IotHubCertificateDescriptionResource.Delete");
            scope.Start();
            try
            {
                var response = await _iotHubCertificateDescriptionCertificatesRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, ifMatch, cancellationToken).ConfigureAwait(false);
                var operation = new IotHubArmOperation(response);
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
        /// Deletes an existing X509 certificate or does nothing if it does not exist.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/IotHubs/{resourceName}/certificates/{certificateName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Certificates_Delete</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-06-30</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="IotHubCertificateDescriptionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ifMatch"> ETag of the Certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> is null. </exception>
        public virtual ArmOperation Delete(WaitUntil waitUntil, string ifMatch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(ifMatch, nameof(ifMatch));

            using var scope = _iotHubCertificateDescriptionCertificatesClientDiagnostics.CreateScope("IotHubCertificateDescriptionResource.Delete");
            scope.Start();
            try
            {
                var response = _iotHubCertificateDescriptionCertificatesRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, ifMatch, cancellationToken);
                var operation = new IotHubArmOperation(response);
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
        /// Adds new or replaces existing certificate.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/IotHubs/{resourceName}/certificates/{certificateName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Certificates_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-06-30</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="IotHubCertificateDescriptionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The certificate body. </param>
        /// <param name="ifMatch"> ETag of the Certificate. Do not specify for creating a brand new certificate. Required to update an existing certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<IotHubCertificateDescriptionResource>> UpdateAsync(WaitUntil waitUntil, IotHubCertificateDescriptionData data, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _iotHubCertificateDescriptionCertificatesClientDiagnostics.CreateScope("IotHubCertificateDescriptionResource.Update");
            scope.Start();
            try
            {
                var response = await _iotHubCertificateDescriptionCertificatesRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data, ifMatch, cancellationToken).ConfigureAwait(false);
                var operation = new IotHubArmOperation<IotHubCertificateDescriptionResource>(Response.FromValue(new IotHubCertificateDescriptionResource(Client, response), response.GetRawResponse()));
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
        /// Adds new or replaces existing certificate.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/IotHubs/{resourceName}/certificates/{certificateName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Certificates_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-06-30</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="IotHubCertificateDescriptionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The certificate body. </param>
        /// <param name="ifMatch"> ETag of the Certificate. Do not specify for creating a brand new certificate. Required to update an existing certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<IotHubCertificateDescriptionResource> Update(WaitUntil waitUntil, IotHubCertificateDescriptionData data, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _iotHubCertificateDescriptionCertificatesClientDiagnostics.CreateScope("IotHubCertificateDescriptionResource.Update");
            scope.Start();
            try
            {
                var response = _iotHubCertificateDescriptionCertificatesRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data, ifMatch, cancellationToken);
                var operation = new IotHubArmOperation<IotHubCertificateDescriptionResource>(Response.FromValue(new IotHubCertificateDescriptionResource(Client, response), response.GetRawResponse()));
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
        /// Generates verification code for proof of possession flow. The verification code will be used to generate a leaf certificate.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/IotHubs/{resourceName}/certificates/{certificateName}/generateVerificationCode</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Certificates_GenerateVerificationCode</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-06-30</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="IotHubCertificateDescriptionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ifMatch"> ETag of the Certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> is null. </exception>
        public virtual async Task<Response<IotHubCertificateWithNonceDescription>> GenerateVerificationCodeAsync(string ifMatch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(ifMatch, nameof(ifMatch));

            using var scope = _iotHubCertificateDescriptionCertificatesClientDiagnostics.CreateScope("IotHubCertificateDescriptionResource.GenerateVerificationCode");
            scope.Start();
            try
            {
                var response = await _iotHubCertificateDescriptionCertificatesRestClient.GenerateVerificationCodeAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, ifMatch, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Generates verification code for proof of possession flow. The verification code will be used to generate a leaf certificate.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/IotHubs/{resourceName}/certificates/{certificateName}/generateVerificationCode</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Certificates_GenerateVerificationCode</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-06-30</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="IotHubCertificateDescriptionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ifMatch"> ETag of the Certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> is null. </exception>
        public virtual Response<IotHubCertificateWithNonceDescription> GenerateVerificationCode(string ifMatch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(ifMatch, nameof(ifMatch));

            using var scope = _iotHubCertificateDescriptionCertificatesClientDiagnostics.CreateScope("IotHubCertificateDescriptionResource.GenerateVerificationCode");
            scope.Start();
            try
            {
                var response = _iotHubCertificateDescriptionCertificatesRestClient.GenerateVerificationCode(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, ifMatch, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Verifies the certificate's private key possession by providing the leaf cert issued by the verifying pre uploaded certificate.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/IotHubs/{resourceName}/certificates/{certificateName}/verify</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Certificates_Verify</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-06-30</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="IotHubCertificateDescriptionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ifMatch"> ETag of the Certificate. </param>
        /// <param name="content"> The name of the certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> or <paramref name="content"/> is null. </exception>
        public virtual async Task<Response<IotHubCertificateDescriptionResource>> VerifyAsync(string ifMatch, IotHubCertificateVerificationContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(ifMatch, nameof(ifMatch));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _iotHubCertificateDescriptionCertificatesClientDiagnostics.CreateScope("IotHubCertificateDescriptionResource.Verify");
            scope.Start();
            try
            {
                var response = await _iotHubCertificateDescriptionCertificatesRestClient.VerifyAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, ifMatch, content, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new IotHubCertificateDescriptionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Verifies the certificate's private key possession by providing the leaf cert issued by the verifying pre uploaded certificate.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/IotHubs/{resourceName}/certificates/{certificateName}/verify</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Certificates_Verify</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-06-30</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="IotHubCertificateDescriptionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ifMatch"> ETag of the Certificate. </param>
        /// <param name="content"> The name of the certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> or <paramref name="content"/> is null. </exception>
        public virtual Response<IotHubCertificateDescriptionResource> Verify(string ifMatch, IotHubCertificateVerificationContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(ifMatch, nameof(ifMatch));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _iotHubCertificateDescriptionCertificatesClientDiagnostics.CreateScope("IotHubCertificateDescriptionResource.Verify");
            scope.Start();
            try
            {
                var response = _iotHubCertificateDescriptionCertificatesRestClient.Verify(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, ifMatch, content, cancellationToken);
                return Response.FromValue(new IotHubCertificateDescriptionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
