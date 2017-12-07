namespace YamlAPIConnectParser.APIConnect.Entity
{
    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using ParserToYamlJsonContext;
    //
    //    var data = GettingStarted.FromJson(jsonString);
    //
  

        using Newtonsoft.Json;
        public partial class Operation
        {
            [JsonProperty("path")]
            public string Path { get; set; }

            [JsonProperty("verb")]
            public string Verb { get; set; }
        }
    }



