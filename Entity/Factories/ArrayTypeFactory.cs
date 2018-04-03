using System;
using Newtonsoft.Json.Linq;
using YamlAPIConnectParser.Entity.Interfaces;

namespace YamlAPIConnectParser.Entity.Factories
{
    class ArrayTypeFactory : ITypeFactory
    {
        public IDataType CreateType(JToken token)
        {
            var items = token["items"];
            return new DataTypeArray()
            {
                ItemsType = items["type"]?.ToString() ?? items["$ref"]?.ToString()
            };
        }
    }

}