namespace YamlAPIConnectParser.APIConnect.Entity
{
    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using ParserToYamlJsonContext;
    //
    //    var data = GettingStarted.FromJson(jsonString);
    //
   
        using System.Collections.Generic;

        using Newtonsoft.Json;
        public partial class GettingStarted
        {
            [JsonProperty("basePath")]
            public string BasePath { get; set; }

            [JsonProperty("consumes")]
            public List<string> Consumes { get; set; }

            [JsonProperty("definitions")]
            public Definitions Definitions { get; set; }

            [JsonProperty("host")]
            public string Host { get; set; }

            [JsonProperty("info")]
            public Info Info { get; set; }

            [JsonProperty("paths")]
            public Paths Paths { get; set; }

            [JsonProperty("produces")]
            public List<string> Produces { get; set; }

            [JsonProperty("schemes")]
            public List<string> Schemes { get; set; }

            [JsonProperty("security")]
            public List<Security> Security { get; set; }

            [JsonProperty("securityDefinitions")]
            public SecurityDefinitions SecurityDefinitions { get; set; }

            [JsonProperty("swagger")]
            public string Swagger { get; set; }

            [JsonProperty("tags")]
            public List<object> Tags { get; set; }

            [JsonProperty("x-ibm-configuration")]
            public XIbmConfiguration XIbmConfiguration { get; set; }
        }
    }



