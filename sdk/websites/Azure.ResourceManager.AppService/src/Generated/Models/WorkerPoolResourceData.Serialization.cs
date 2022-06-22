// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AppService
{
    public partial class WorkerPoolResourceData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Sku))
            {
                writer.WritePropertyName("sku");
                writer.WriteObjectValue(Sku);
            }
            if (Optional.IsDefined(Kind))
            {
                writer.WritePropertyName("kind");
                writer.WriteStringValue(Kind);
            }
            writer.WritePropertyName("properties");
            writer.WriteStartObject();
            if (Optional.IsDefined(WorkerSizeId))
            {
                writer.WritePropertyName("workerSizeId");
                writer.WriteNumberValue(WorkerSizeId.Value);
            }
            if (Optional.IsDefined(ComputeMode))
            {
                writer.WritePropertyName("computeMode");
                writer.WriteStringValue(ComputeMode.Value.ToSerialString());
            }
            if (Optional.IsDefined(WorkerSize))
            {
                writer.WritePropertyName("workerSize");
                writer.WriteStringValue(WorkerSize);
            }
            if (Optional.IsDefined(WorkerCount))
            {
                writer.WritePropertyName("workerCount");
                writer.WriteNumberValue(WorkerCount.Value);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static WorkerPoolResourceData DeserializeWorkerPoolResourceData(JsonElement element)
        {
            Optional<SkuDescription> sku = default;
            Optional<string> kind = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<int> workerSizeId = default;
            Optional<ComputeModeOptions> computeMode = default;
            Optional<string> workerSize = default;
            Optional<int> workerCount = default;
            Optional<IReadOnlyList<string>> instanceNames = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("sku"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    sku = SkuDescription.DeserializeSkuDescription(property.Value);
                    continue;
                }
                if (property.NameEquals("kind"))
                {
                    kind = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.ToString());
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("workerSizeId"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            workerSizeId = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("computeMode"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            computeMode = property0.Value.GetString().ToComputeModeOptions();
                            continue;
                        }
                        if (property0.NameEquals("workerSize"))
                        {
                            workerSize = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("workerCount"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            workerCount = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("instanceNames"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<string> array = new List<string>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(item.GetString());
                            }
                            instanceNames = array;
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new WorkerPoolResourceData(id, name, type, systemData.Value, sku.Value, Optional.ToNullable(workerSizeId), Optional.ToNullable(computeMode), workerSize.Value, Optional.ToNullable(workerCount), Optional.ToList(instanceNames), kind.Value);
        }
    }
}
