using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using YamlAPIConnectParser.Entity.Interfaces;
using YamlAPIConnectParser.Entity.Utils;

namespace YamlAPIConnectParser.Entity
{
    public partial class DataTypeSchema : IDataType
    {
        [JsonIgnore]
        public string ReferencedType { get; set; }

        #region  IDataType
        
        [JsonProperty("name")]
        string IDataType.Name { get; set; }

        #endregion
    }
}