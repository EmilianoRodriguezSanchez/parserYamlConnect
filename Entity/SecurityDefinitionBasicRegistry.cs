using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using YamlAPIConnectParser.Entity.Interfaces;
using YamlAPIConnectParser.Entity.Utils;

namespace YamlAPIConnectParser.Entity
{
    //[JsonDictionary()]
    public partial class SecurityDefinitionBasicRegistry : SecurityDefinitionBasic
    {
        [JsonProperty("x-ibm-authentication-registry")]
        public string Registry { get; set; } 
    }
}



