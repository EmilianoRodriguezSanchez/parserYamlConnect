using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace YamlAPIConnectParser.Entity
{
    public class SecurityRequirementConverter : JsonConverter
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
            var securityDefinitions = jObject.Properties()
                .Select(x => x.Name)
                .Select(n => new SecurityRequirement() 
                {
                    SecurityDefinitionName = n, 
                    AppliedScopes = new List<string>(jObject[n].Values<string>())
                });

            return new SecurityRequirementSet()
            {
                SecurityDefinitions = securityDefinitions.ToList()
            };
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
            //return objectType == typeof(User);
        }
    }
}