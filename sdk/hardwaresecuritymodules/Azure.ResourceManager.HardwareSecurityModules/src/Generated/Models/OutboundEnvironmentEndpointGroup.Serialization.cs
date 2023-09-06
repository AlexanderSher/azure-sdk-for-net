// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.HardwareSecurityModules.Models
{
    internal partial class OutboundEnvironmentEndpointGroup
    {
        internal static OutboundEnvironmentEndpointGroup DeserializeOutboundEnvironmentEndpointGroup(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<OutboundEnvironmentEndpoint> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<OutboundEnvironmentEndpoint> array = new List<OutboundEnvironmentEndpoint>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(OutboundEnvironmentEndpoint.DeserializeOutboundEnvironmentEndpoint(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"u8))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new OutboundEnvironmentEndpointGroup(value, nextLink.Value);
        }
    }
}
