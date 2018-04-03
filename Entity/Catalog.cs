using System.Collections.Generic;
using Newtonsoft.Json;
using YamlAPIConnectParser.Entity.Utils;

namespace YamlAPIConnectParser.Entity
{
    public class Catalog : DynamicDictionary
    {
        [JsonProperty("properties")]
        public Dictionary<string, string> Values { get; set; }
    }
}