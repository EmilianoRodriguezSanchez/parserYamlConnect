using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using YamlAPIConnectParser.Entity.Factories;
using YamlAPIConnectParser.Entity.Interfaces;
using static YamlAPIConnectParser.Entity.Parameter;

namespace YamlAPIConnectParser.Entity
{
    public class DefinitionPropertyConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("The write operation of the SecurityScopeConverter is not implemented yet");
            //var scope = (SecurityScope)value;
            //writer.WriteValue(scope.Name);
        }
        
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            return jObject.Properties()
                .Select(x => new Property()
                {
                    Name = x.Name,
                    Description = jObject[x.Name]["description"]?.ToString(),
                    Example = jObject[x.Name]["example"]?.ToString(),
                    Type = TypesFactory.GetFactory(jObject[x.Name]).CreateType(jObject[x.Name])
                })
                .ToList();
        }
        
        public override bool CanConvert(Type objectType)
        {
            return true;
            //return objectType == typeof(User);
        }
    }
}