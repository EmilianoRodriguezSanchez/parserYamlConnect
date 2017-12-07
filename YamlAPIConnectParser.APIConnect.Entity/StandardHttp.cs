namespace YamlAPIConnectParser.APIConnect.Entity
{
    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using ParserToYamlJsonContext;
    //
    //    var data = GettingStarted.FromJson(jsonString);
    //
       using Newtonsoft.Json;
        public partial class StandardHttp
        {
            [JsonProperty("delete")]
            public Delete Delete { get; set; }

            [JsonProperty("get")]
            public Get Get { get; set; }

            [JsonProperty("post")]
            public Get Post { get; set; }
        }
    }



