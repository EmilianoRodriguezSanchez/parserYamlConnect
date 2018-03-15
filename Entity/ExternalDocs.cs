using Newtonsoft.Json;
using YamlAPIConnectParser.Utils;

namespace YamlAPIConnectParser.Entity
{
    public class ExternalDocs : DynamicDictionary
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}