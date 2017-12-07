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
        public partial class Security
        {
            [JsonProperty("clientIdHeader")]
            public List<object> ClientIdHeader { get; set; }
        }
    }



