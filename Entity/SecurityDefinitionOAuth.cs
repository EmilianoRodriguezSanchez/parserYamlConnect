using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using YamlAPIConnectParser.Entity.Interfaces;
using YamlAPIConnectParser.Entity.Utils;

namespace YamlAPIConnectParser.Entity
{
    public partial class SecurityDefinitionOAuth : DynamicDictionary, ISecurityDefinition
    {
        public enum FlowType
        {
            [EnumMember(Value = "implicit")]
            Implicit,

            [EnumMember(Value = "accessCode")]
            AccessCode,
            [EnumMember(Value = "application")]
            Application,
            [EnumMember(Value = "password")]
            Password

        }

        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("flow")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FlowType Flow { get; set; }

        [JsonProperty("tokenUrl")]
        public string TokenUrl { get; set; }

        [JsonProperty("scopes")]
        public Dictionary<string, string> Scopes { get; set; }

        [JsonProperty("authorizationUrl")]
        public string AuthorizationUrl { get; set; }
    }
}



