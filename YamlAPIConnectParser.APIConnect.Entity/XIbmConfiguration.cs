namespace YamlAPIConnectParser.APIConnect.Entity
{
    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using ParserToYamlJsonContext;
    //
    //    var data = GettingStarted.FromJson(jsonString);
    //
   

        using Newtonsoft.Json;
        public partial class XIbmConfiguration
        {
            [JsonProperty("assembly")]
            public Assembly Assembly { get; set; }

            [JsonProperty("cors")]
            public Cors Cors { get; set; }

            [JsonProperty("enforced")]
            public string Enforced { get; set; }

            [JsonProperty("gateway")]
            public string Gateway { get; set; }

            [JsonProperty("phase")]
            public string Phase { get; set; }

            [JsonProperty("properties")]
            public PurpleProperties Properties { get; set; }

            [JsonProperty("testable")]
            public string Testable { get; set; }
        }
    


}
