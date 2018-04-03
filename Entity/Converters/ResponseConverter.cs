using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using YamlAPIConnectParser.Entity.Factories;
using YamlAPIConnectParser.Entity.Interfaces;

namespace YamlAPIConnectParser.Entity
{
    public class ResponseConverter : JsonConverter
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
            var response = new Response()
            {
                Description = jObject["description"]?.ToString(),
                Type = TypesFactory.GetFactory(jObject["schema"]).CreateType(jObject["schema"])
            };

            return response;

        }

        public override bool CanConvert(Type objectType)
        {
            return true;
            //return objectType == typeof(User);
        }
    }
}