using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using YamlAPIConnectParser.Entity.Interfaces;
using YamlAPIConnectParser.Entity.Utils;

namespace YamlAPIConnectParser.Entity
{
    public partial class Parameter
    {
        public enum SourceType
        {
            [EnumMember(Value = "")]
            Undefined,
            [EnumMember(Value = "path")]
            Path,
            [EnumMember(Value = "query")]
            Query,
            [EnumMember(Value = "header")]
            Header,
            [EnumMember(Value = "body")]
            Body,
            [EnumMember(Value = "formParam")]
            Form
        };

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("required")]
        public bool IsRequired { get; set; }

        [JsonProperty("in")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SourceType Source { get; set; }

        [JsonIgnore]
        public IDataType Type { get; set; }
    }
}