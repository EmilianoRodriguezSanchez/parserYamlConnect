using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using YamlAPIConnectParser.Entity.Utils;

namespace YamlAPIConnectParser.Entity
{
    public partial class Info : DynamicDictionary
    {
        [JsonProperty("contact")]
        public Contact Contact { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("x-ibm-name")]
        public string Name { get; set; }

        [JsonProperty("license")]
        public License License { get; set;}
    }
}
