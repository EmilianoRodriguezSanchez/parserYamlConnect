namespace YamlAPIConnectParser.APIConnect.Entity
{
    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using ParserToYamlJsonContext;
    //
    //    var data = GettingStarted.FromJson(jsonString);
    //
    

        using Newtonsoft.Json;
        public partial class PurpleProperties
        {
            [JsonProperty("altaValContrBKN-url")]
            public BKNUrl AltaValContrBKNUrl { get; set; }

            [JsonProperty("elimContrBKN-url")]
            public BKNUrl ElimContrBKNUrl { get; set; }

            [JsonProperty("preContrataBKN-url")]
            public BKNUrl PreContrataBKNUrl { get; set; }
        }
  
}
