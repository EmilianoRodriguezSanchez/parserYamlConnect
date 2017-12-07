﻿namespace YamlAPIConnectParser.APIConnect.Entity
{
    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using ParserToYamlJsonContext;
    //
    //    var data = GettingStarted.FromJson(jsonString);
    //
   
        using Newtonsoft.Json;
        public partial class Parameter
        {
            [JsonProperty("in")]
            public string In { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("required")]
            public string Required { get; set; }

            //[JsonProperty("schema")]
            //public BeanCodComercial Schema { get; set; }
        }
    }


