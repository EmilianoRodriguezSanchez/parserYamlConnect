using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using YamlAPIConnectParser.Utils;

namespace YamlAPIConnectParser.Entity.Interfaces
{
    //[JsonDictionary()]
    public interface ISecurityDefinition
    {
        string Description { get; set; }
    }
}



