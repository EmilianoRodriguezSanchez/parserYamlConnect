using System.Collections.Generic;
using YamlAPIConnectParser.Entity.Utils;

namespace YamlAPIConnectParser.Entity
{
    public class Path : DynamicDictionary
    {
        public string Name { get; set; }

        public List<Parameter> Parameters { get ;set; }

        public Dictionary<Verb.VerbType, Verb> Verbs { get; set;}

    }
}