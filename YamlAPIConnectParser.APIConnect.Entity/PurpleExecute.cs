namespace YamlAPIConnectParser.APIConnect.Entity
{
    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using ParserToYamlJsonContext;
    //
    //    var data = GettingStarted.FromJson(jsonString);
    //
   

        using Newtonsoft.Json;
        public partial class PurpleExecute
        {
            [JsonProperty("operation-switch")]
            public OperationSwitch OperationSwitch { get; set; }
        }
    }



