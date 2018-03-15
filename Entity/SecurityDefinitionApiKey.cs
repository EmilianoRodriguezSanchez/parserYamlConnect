using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using YamlAPIConnectParser.Entity.Interfaces;
using YamlAPIConnectParser.Utils;

namespace YamlAPIConnectParser.Entity
{
    //[JsonDictionary()]
    public partial class SecurityDefinitionApiKey : DynamicDictionary, ISecurityDefinition
    {
        public enum InType
        {
            [EnumMember(Value = "header")]
            Header,

            [EnumMember(Value = "query")]
            Query
        }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("in")]
        [JsonConverter(typeof(StringEnumConverter))]
        public InType In { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}



