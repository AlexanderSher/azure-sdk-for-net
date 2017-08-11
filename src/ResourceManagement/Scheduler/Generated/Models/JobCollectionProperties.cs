// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.2.2.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Scheduler.Fluent.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.Scheduler;
    using Microsoft.Azure.Management.Scheduler.Fluent;
    using Newtonsoft.Json;
    using System.Linq;

    public partial class JobCollectionProperties
    {
        /// <summary>
        /// Initializes a new instance of the JobCollectionProperties class.
        /// </summary>
        public JobCollectionProperties()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the JobCollectionProperties class.
        /// </summary>
        /// <param name="sku">Gets or sets the SKU.</param>
        /// <param name="state">Gets or sets the state. Possible values
        /// include: 'Enabled', 'Disabled', 'Suspended', 'Deleted'</param>
        /// <param name="quota">Gets or sets the job collection quota.</param>
        public JobCollectionProperties(Sku sku = default(Sku), JobCollectionState? state = default(JobCollectionState?), JobCollectionQuota quota = default(JobCollectionQuota))
        {
            Sku = sku;
            State = state;
            Quota = quota;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the SKU.
        /// </summary>
        [JsonProperty(PropertyName = "sku")]
        public Sku Sku { get; set; }

        /// <summary>
        /// Gets or sets the state. Possible values include: 'Enabled',
        /// 'Disabled', 'Suspended', 'Deleted'
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public JobCollectionState? State { get; set; }

        /// <summary>
        /// Gets or sets the job collection quota.
        /// </summary>
        [JsonProperty(PropertyName = "quota")]
        public JobCollectionQuota Quota { get; set; }

    }
}
