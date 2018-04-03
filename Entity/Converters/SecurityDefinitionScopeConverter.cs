using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace YamlAPIConnectParser.Entity
{
    public class SecurityDefinitionScopeConverter : JsonConverter
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
                switch((string)jObject["type"])
                {
                    case "basic":
                        if(jObject["x-ibm-authentication-url"] != null)
                        {
                            return JsonConvert.DeserializeObject<SecurityDefinitionBasicUrl>(jObject.ToString());
                        }
                        else
                        {
                            return JsonConvert.DeserializeObject<SecurityDefinitionBasicRegistry>(jObject.ToString());
                        }
                        
                    case "apiKey":
                        return JsonConvert.DeserializeObject<SecurityDefinitionApiKey>(jObject.ToString());
                    case "oauth2":
                        return JsonConvert.DeserializeObject<SecurityDefinitionOAuth>(jObject.ToString());
                    default:
                        throw new ArgumentException($"Cannot convert the SecurityDefinition element. The type {(string)jObject["type"]} is not a valid type");
                }
            }
            throw new ArgumentException("Cannot convert the SecurityDefinition element. The type is undefined");
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
            //return objectType == typeof(User);
        }
    }
}