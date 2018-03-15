using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using YamlAPIConnectParser.Utils;

namespace YamlAPIConnectParser.Entity.Interfaces
{
    public interface IDataType
    {
        string Name { get; set; }
    }
}