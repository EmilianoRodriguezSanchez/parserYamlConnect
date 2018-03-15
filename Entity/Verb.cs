using System.Collections.Generic;

namespace YamlAPIConnectParser.Entity
{
    public class Verb
    {
        public enum VerbType
        {
            Post,
            Put,
            Delete,
            Head,
            Patch,
            Options
        }

        public VerbType Type {get ;set;}

        public string Summary { get; set; }

        public string OperationId { get; set; }

        public bool IsDeprecated { get; set; }

        public string Description { get; set; }

        public List<Tag> Tags { get; set; }

        public List<Parameter> Parameters { get; set; }
        
    }
}