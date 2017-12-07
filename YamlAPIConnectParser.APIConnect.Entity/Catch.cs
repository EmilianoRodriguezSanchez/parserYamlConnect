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
        public partial class Catch
        {
            [JsonProperty("errors")]
            public List<object> Errors { get; set; }

            [JsonProperty("execute")]
            public List<object> Execute { get; set; }
        }
    }



