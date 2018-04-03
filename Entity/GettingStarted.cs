using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using YamlAPIConnectParser.Entity.Interfaces;
using YamlAPIConnectParser.Entity.Utils;

namespace YamlAPIConnectParser.Entity
{
    public partial class GettingStarted : DynamicDictionary
    {
        [JsonProperty("basePath")]
        public string BasePath { get; set; }

        [JsonProperty("consumes")]
        public List<string> Consumes { get; set; }

        [JsonProperty(PropertyName = "definitions", ItemConverterType = typeof(DefinitionConverter))]
        public Dictionary<string, IDefinition> Definitions { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("info")]
        public Info Info { get; set; }

        [JsonProperty(PropertyName = "paths", ItemConverterType = typeof(PathConverter))]
        public Dictionary<string, Path> Paths { get; set; }

        [JsonProperty("produces")]
        public List<string> Produces { get; set; }

        [JsonProperty (PropertyName = "schemes", ItemConverterType = typeof(StringEnumConverter))]
        public List<EntitiesEnums.SchemeTypes> Schemes { get; set; }

        [JsonProperty(PropertyName = "security", ItemConverterType = typeof(SecurityRequirementConverter))]
        public List<SecurityRequirementSet> Security { get; set; }

        [JsonProperty (PropertyName ="securityDefinitions", ItemConverterType = typeof(SecurityDefinitionScopeConverter))]
        public Dictionary<string, ISecurityDefinition> SecurityDefinitions { get; set; }

        [JsonProperty("swagger")]
        public string SwaggerVersion { get; set; }

        [JsonProperty (PropertyName ="parameters", ItemConverterType = typeof(ParameterConverter))]
        public Dictionary<string, Parameter> Parameters { get; set; }

        [JsonProperty("x-ibm-configuration")]
        public XIbmConfiguration XIbmConfiguration { get; set; }

        [JsonProperty("tags")]
        public List<ExternalDocs> Tags { get; set; }


    }
}



