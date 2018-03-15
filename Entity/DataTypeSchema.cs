using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using YamlAPIConnectParser.Entity.Interfaces;
using YamlAPIConnectParser.Utils;

namespace YamlAPIConnectParser.Entity
{
    public partial class DataTypeSchema : IDataType
    {
        public enum ParameterType
        {
            Array,
            Schema
        }

        [JsonIgnore]
        public string ItemsType { get; set; }

        #region  IDataType
        
        [JsonProperty("name")]
        string IDataType.Name { get; set; }

        #endregion
    }
}