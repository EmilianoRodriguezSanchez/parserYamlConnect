namespace YamlAPIConnectParser.APIConnect.Entity
{
    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using ParserToYamlJsonContext;
    //
    //    var data = GettingStarted.FromJson(jsonString);
    //
    

        using Newtonsoft.Json;
        public partial class Responses
        {
            [JsonProperty("200")]
            public ErrorHttp The200 { get; set; }

            [JsonProperty("204")]
            public ErrorHttp The204 { get; set; }

            [JsonProperty("400")]
            public ErrorHttp The400 { get; set; }

            [JsonProperty("401")]
            public ErrorHttp The401 { get; set; }

            [JsonProperty("404")]
            public ErrorHttp The404 { get; set; }

            [JsonProperty("500")]
            public ErrorHttp The500 { get; set; }
        }
    


}
