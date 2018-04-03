using Newtonsoft.Json;
using YamlAPIConnectParser.Entity.Interfaces;
using YamlAPIConnectParser.Entity.Utils;

namespace YamlAPIConnectParser.Entity
{
    public partial class Property : PropertyBasic
    {
        public string Example { get; set; }
        public bool IsRequired { get; set; }
        public string Name { get; set; }
    }


}
