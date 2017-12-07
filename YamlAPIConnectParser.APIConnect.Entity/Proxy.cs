namespace YamlAPIConnectParser.APIConnect.Entity
{
    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using ParserToYamlJsonContext;
    //
    //    var data = GettingStarted.FromJson(jsonString);
    //
    

        using Newtonsoft.Json;
        public partial class Proxy
        {
            [JsonProperty("cache-response")]
            public string CacheResponse { get; set; }

            [JsonProperty("cache-ttl")]
            public string CacheTtl { get; set; }

            [JsonProperty("target-url")]
            public string TargetUrl { get; set; }

            [JsonProperty("timeout")]
            public string Timeout { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("verb")]
            public string Verb { get; set; }
        }
    


}
