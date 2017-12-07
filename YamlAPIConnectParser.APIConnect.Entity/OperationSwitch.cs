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
        public partial class OperationSwitch
        {
            [JsonProperty("case")]
            public List<Case> Case { get; set; }

            [JsonProperty("otherwise")]
            public List<object> Otherwise { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }
        }
    }



