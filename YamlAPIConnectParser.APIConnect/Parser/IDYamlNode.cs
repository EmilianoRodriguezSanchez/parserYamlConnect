using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YamlDotNet.RepresentationModel;

namespace YamlAPIConnectParser.APIConnect.Parser
{
    public interface IDYamlNode<T> where T : class
    {
        void Load(T mappingNode);
        T FindMappingNode(string objId);
    }
}
