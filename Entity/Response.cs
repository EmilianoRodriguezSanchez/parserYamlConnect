using YamlAPIConnectParser.Entity.Interfaces;

namespace YamlAPIConnectParser.Entity
{
    public class Response
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public IDataType Type { get; set; }

    }
}