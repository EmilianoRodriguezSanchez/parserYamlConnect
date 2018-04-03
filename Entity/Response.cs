using Newtonsoft.Json;
using YamlAPIConnectParser.Entity.Interfaces;

namespace YamlAPIConnectParser.Entity
{
    public class Response
    {
        public string Description { get; set; }

        [JsonIgnore]
        public IDataType Type { get; set; }

    }
}