using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using YamlAPIConnectParser.Entity.Utils;

namespace YamlAPIConnectParser.Entity
{
    public class XIbmConfiguration : DynamicDictionary
    {
        public enum PhaseType
        {
            [EnumMember(Value = "identified")]
            Identified,
            [EnumMember(Value = "specified")]
            Specified,
            [EnumMember(Value = "realized")]
            Realized,
        }

        public enum GateWayType
        {
            [EnumMember(Value = "datapower-gateway")]
            DataPower,
            [EnumMember(Value = "micro-gateway")]
            MicroGateway
        }

        [JsonProperty("properties")]
        public Dictionary<string, ConfigurationProperty> ConfigurationProperties { get; set; }
        
        [JsonProperty("catalogs")]
        public Dictionary<string, Catalog> Catalogs { get; set; }
        
        [JsonProperty("testable")]
        public bool Testable { get; set; }

        [JsonProperty("enforced")]
        public bool Enforced { get; set; }

        [JsonProperty("phase")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PhaseType Phase { get; set; }
       
        [JsonProperty("gateway")]
        [JsonConverter(typeof(StringEnumConverter))]
        public GateWayType GateWay { get; set; }
    }
}