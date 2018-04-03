using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using YamlAPIConnectParser.Entity.Utils;

namespace YamlAPIConnectParser.Entity
{
    //[JsonDictionary()]
    public partial class SecurityDefinitionAuthUrl : DynamicDictionary
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("tls-profile")]
        public string TlsProfile { get; set; }

    }
}



