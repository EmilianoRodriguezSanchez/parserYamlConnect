using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using YamlAPIConnectParser.Entity.Interfaces;
using YamlAPIConnectParser.Utils;

namespace YamlAPIConnectParser.Entity
{
    public abstract class SecurityDefinitionBasic : DynamicDictionary, ISecurityDefinition
    {
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}



