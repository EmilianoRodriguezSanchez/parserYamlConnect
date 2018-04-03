using System.Collections.Generic;
using Newtonsoft.Json;
using YamlAPIConnectParser.Entity.Utils;

namespace YamlAPIConnectParser.Entity
{
    public class ConfigurationProperty : DynamicDictionary
    {
        [JsonProperty("value")]
        public string Value { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("encoded")]
        public bool Encoded { get; set; }
        
    }
}