using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public static class EntitiesEnums
{
    public enum SchemeTypes
    {
        [EnumMember(Value = "http")]
        Http,
        [EnumMember(Value = "https")]
        Https,
        [EnumMember(Value = "wss")]
        Wss,
        [EnumMember(Value = "ws")]
        Ws
    }

    
}