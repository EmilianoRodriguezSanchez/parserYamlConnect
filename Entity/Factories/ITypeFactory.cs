using Newtonsoft.Json.Linq;
using YamlAPIConnectParser.Entity.Interfaces;

namespace YamlAPIConnectParser.Entity.Factories
{
    interface ITypeFactory
    {
        IDataType CreateType(JToken token);
    }
}