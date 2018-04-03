using System.Collections.Generic;
using Newtonsoft.Json;
using YamlAPIConnectParser.Entity.Interfaces;
using YamlAPIConnectParser.Entity.Utils;

namespace YamlAPIConnectParser.Entity
{
    public partial class Schema : IDefinition
    {
        public bool HasAdditionalProperties { get; set; }
        public List<Property> Properties { get; set; }
        
        #region IDefinition
        
        public string Description { get; set; }
        
        #endregion
    }


}
