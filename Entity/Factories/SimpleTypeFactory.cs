using System;
using Newtonsoft.Json.Linq;
using YamlAPIConnectParser.Entity.Interfaces;
using static YamlAPIConnectParser.Entity.DataTypeSimple;

namespace YamlAPIConnectParser.Entity.Factories
{
    class SimpleTypeFactory : ITypeFactory
    {
        public IDataType CreateType(JToken token)
        {
            return new DataTypeSimple()
            {
                Type = Enum.TryParse<ParameterType>(token["type"]?.ToString(), true, out ParameterType type) ? type : ParameterType.Undefined,
                Format = Enum.TryParse<FormatType>(token["format"]?.ToString(), true, out FormatType format) ? format : FormatType.Undefined
            };
        }
    }

}