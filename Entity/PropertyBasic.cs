using Newtonsoft.Json;
using YamlAPIConnectParser.Entity.Interfaces;
using YamlAPIConnectParser.Entity.Utils;

namespace YamlAPIConnectParser.Entity
{
    public partial class PropertyBasic : IDefinition
    {
        public IDataType Type { get; set; }
        
        #region IDefinition
        public string Description { get; set; }

        #endregion
    }


}
