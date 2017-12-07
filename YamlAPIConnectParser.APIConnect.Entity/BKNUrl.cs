namespace YamlAPIConnectParser.APIConnect.Entity
{
    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using ParserToYamlJsonContext;
    //
    //    var data = GettingStarted.FromJson(jsonString);
    //
   
    

        using Newtonsoft.Json;
        public partial class BKNUrl
        {
            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("encoded")]
            public string Encoded { get; set; }

            [JsonProperty("value")]
            public string Value { get; set; }
        }
    }



