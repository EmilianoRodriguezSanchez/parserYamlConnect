using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using YamlAPIConnectParser.Utils;

namespace YamlAPIConnectParser.Entity
{
    public partial class SecurityScope : DynamicDictionary
    {

        public string Name { get; set; }


        public string Description { get; set; }
    }
}