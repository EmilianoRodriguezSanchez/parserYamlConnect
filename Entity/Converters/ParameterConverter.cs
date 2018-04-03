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
    public class ParameterConverter : JsonConverter
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
            return new Parameter()
            {
                Name = jObject["name"]?.ToString(),
                Description = jObject["description"]?.ToString(),
                IsRequired = Boolean.TryParse(jObject["description"]?.ToString(), out bool isRequired) ? isRequired : false,
                Source = Enum.TryParse<SourceType>(jObject["in"]?.ToString(), true, out SourceType source) ? source : SourceType.Undefined,
                Type = jObject["schema"] != null ? TypesFactory.GetFactory(jObject["schema"]).CreateType(jObject["schema"]) : TypesFactory.GetFactory(jObject).CreateType(jObject)
            };
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
            //return objectType == typeof(User);
        }
    }
}