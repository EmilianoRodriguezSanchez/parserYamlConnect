using System.Collections.Generic;
using Newtonsoft.Json;
using YamlAPIConnectParser.Entity.Utils;

namespace YamlAPIConnectParser.Entity
{
    public class Verb : DynamicDictionary
    {
        public enum VerbType
        {
            Get,
            Post,
            Put,
            Delete,
            Head,
            Patch,
            Options
        }

        [JsonIgnore]
        public VerbType  Type {get ;set;}

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("operationId")]
        public string OperationId { get; set; }

        [JsonProperty("deprecated")]
        public bool IsDeprecated { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonIgnore]
        public List<Parameter> Parameters { get; set; }

        [JsonProperty(PropertyName ="responses", ItemConverterType = typeof(ResponseConverter))]
        public Dictionary<string, Response> Responses {get; set;}
        
    }
}