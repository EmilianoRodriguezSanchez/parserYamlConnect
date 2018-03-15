using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using YamlAPIConnectParser.Entity.Interfaces;
using YamlAPIConnectParser.Utils;

namespace YamlAPIConnectParser.Entity
{
    public partial class DataTypeSimple : IDataType
    {
        public enum ParameterType
        {
            [EnumMember(Value = "integer")]
            Integer,
            [EnumMember(Value = "long")]
            Long,
            [EnumMember(Value = "float")]
            Float,
            [EnumMember(Value = "double")]
            Double,
            [EnumMember(Value = "string")]
            String,
            [EnumMember(Value = "byte")]
            Byte,
            [EnumMember(Value = "binary")]
            Binary,
            [EnumMember(Value = "boolean")]
            Boolean,
            [EnumMember(Value = "date")]
            Date,
            [EnumMember(Value = "dateTime")]
            DateTime,
            [EnumMember(Value = "password")]
            Password,
            [EnumMember(Value = "object")]
            Object
        };

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ParameterType Type { get; set; }
        

        [JsonProperty("format")]
        public string Format { get; set; }

        #region  IDataType
        
        [JsonProperty("name")]
        string IDataType.Name { get; set; }
        
        #endregion
    }
}