using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using YamlAPIConnectParser.Entity.Utils;

namespace YamlAPIConnectParser.Entity.Interfaces
{
    public interface IDefinition
    {
        string Description { get; set; }
    }
}