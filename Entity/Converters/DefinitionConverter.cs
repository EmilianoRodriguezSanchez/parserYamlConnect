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
    public class DefinitionConverter : JsonConverter
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
            if(jObject["type"] != null)
            {
                return new PropertyBasic()
                {
                    Description = jObject["description"]?.ToString(),
                    Type = TypesFactory.GetFactory(jObject).CreateType(jObject)
                };
            }
            else
            {
                var schema = new Schema()
                {
                    Description = jObject["description"]?.ToString(),
                    HasAdditionalProperties = Boolean.TryParse(jObject["additionalProperties"]?.ToString(), out bool additionalProperties) ? additionalProperties : false,
                    Properties = JsonConvert.DeserializeObject<List<Property>>(jObject["properties"].ToString(), new DefinitionPropertyConverter())
                };
                
                var requiredFields = jObject["required"]?.Select(x => x.Value<string>());
                schema.Properties
                    .Where(x => requiredFields?.Contains(x.Name) ?? false)
                    ?.ToList()
                    ?.ForEach(x => x.IsRequired = true);

                return schema;
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
            //return objectType == typeof(User);
        }
    }
}