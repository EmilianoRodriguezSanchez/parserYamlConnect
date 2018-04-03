using System;
using Newtonsoft.Json.Linq;
using YamlAPIConnectParser.Entity.Interfaces;

namespace YamlAPIConnectParser.Entity.Factories
{
    class ReferenceFactory : ITypeFactory
    {
        public IDataType CreateType(JToken token)
        {
            return new DataTypeSchema()
            {
                ReferencedType = token["$ref"] != null ? token["$ref"].ToString() :  token["schema"]["$ref"].ToString()
            };
        }
    }

}