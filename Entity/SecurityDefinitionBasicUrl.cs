using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using YamlAPIConnectParser.Entity.Interfaces;
using YamlAPIConnectParser.Utils;

namespace YamlAPIConnectParser.Entity
{
    //[JsonDictionary()]
    public partial class SecurityDefinitionBasicUrl : SecurityDefinitionBasic
    {
        [JsonProperty("x-ibm-authentication-url")]
        public SecurityDefinitionAuthUrl Url { get; set; }  
    }
}



