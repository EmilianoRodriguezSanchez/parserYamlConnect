namespace YamlAPIConnectParser.APIConnect.Entity
{
    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using ParserToYamlJsonContext;
    //
    //    var data = GettingStarted.FromJson(jsonString);
    //
   
        using Newtonsoft.Json;
        public partial class Paths
        {
            [JsonProperty("/contrataciones_decenal")]
            public StandardHttp ContratacionesDecenal { get; set; }
        }
    }

