using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace YamlAPIConnectParser.Entity
{
    public class PathConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("The write operation of the SecurityScopeConverter is not implemented yet");
            //var scope = (SecurityScope)value;
            //writer.WriteValue(scope.Name);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var pathElement = new Path();

            var jObject = JObject.Load(reader);

            pathElement.Verbs = jObject.Properties()
                .Where(x => Enum.TryParse<Verb.VerbType>(x.Name, true, out Verb.VerbType verbType))
                ?.Select(x => 
                {
                    var verb = JsonConvert.DeserializeObject<Verb>(jObject[x.Name].ToString());
                    verb.Type = (Verb.VerbType)Enum.Parse(typeof(Verb.VerbType), x.Name, true);
                    if(jObject[x.Name]["parameters"] != null)
                    {
                        verb.Parameters = JsonConvert.DeserializeObject<List<Parameter>>(jObject[x.Name]["parameters"].ToString(), 
                            new ParametersConverter());
                    }
                    
                    return verb;
                })
                ?.ToDictionary(elem => elem.Type, elem => elem);

            if(jObject["parameters"] != null)
            {
                pathElement.Parameters = JsonConvert.DeserializeObject<List<Parameter>>(jObject["parameters"].ToString(), 
                    new ParametersConverter());
            }

            return pathElement;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
            //return objectType == typeof(User);
        }
    }
}