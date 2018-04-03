﻿using System.Collections.Generic;
using Newtonsoft.Json;
using YamlAPIConnectParser.Entity.Utils;

namespace YamlAPIConnectParser.Entity
{
    public partial class SecurityRequirement
    {
        public string SecurityDefinitionName { get; set; }
        public List<string> AppliedScopes { get; set; }
    }
}


