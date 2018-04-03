using System;
using Newtonsoft.Json.Linq;

namespace YamlAPIConnectParser.Entity.Factories
{
    static class TypesFactory
    {
        internal static ITypeFactory GetFactory(JToken token)
        {
            if(token["items"] != null)
            {
                return new ArrayTypeFactory();
            }
            else if(token["type"] != null)
            {
                return new SimpleTypeFactory();
            }
            else if(token["$ref"] != null || (token["schema"] != null && token["schema"]["$ref"] != null))
            {
                return new ReferenceFactory();
            }
            else
            {
                throw new ArgumentException("The input json haven't a valid type");
            }
            
        }
    }
}