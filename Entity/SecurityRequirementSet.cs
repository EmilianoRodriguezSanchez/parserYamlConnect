﻿using System.Collections.Generic;
using Newtonsoft.Json;
using YamlAPIConnectParser.Entity.Utils;

namespace YamlAPIConnectParser.Entity
{
    public partial class SecurityRequirementSet
    {
        public List<SecurityRequirement> SecurityDefinitions { get; set; }
    }
}


