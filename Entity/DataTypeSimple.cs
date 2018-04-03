using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using YamlAPIConnectParser.Entity.Interfaces;
using YamlAPIConnectParser.Entity.Utils;

namespace YamlAPIConnectParser.Entity
{
    public partial class DataTypeSimple : IDataType
    {
        public enum ParameterType
        {
            [EnumMember(Value = "")]
            Undefined,
            [EnumMember(Value = "integer")]
            Integer,
            [EnumMember(Value = "number")]
            Number,
            [EnumMember(Value = "string")]
            String,
            [EnumMember(Value = "boolean")]
            Boolean,
            [EnumMember(Value = "object")]
            Object
        }

        public enum FormatType
        {
            [EnumMember(Value = "")]
            Undefined,
            [EnumMember(Value = "int32")]
            Int32,
            [EnumMember(Value = "int64")]
            Int64,
            [EnumMember(Value = "float")]
            Float,
            [EnumMember(Value = "double")]
            Double,
            [EnumMember(Value = "byte")]
            Byte,
            [EnumMember(Value = "binary")]
            Binary,
            [EnumMember(Value = "date")]
            Date,
            [EnumMember(Value = "date-time")]
            DateTime,
            [EnumMember(Value = "password")]
            Password,
        }
        
        public enum ApiConnectType
        {
            Integer,
            Long,
            Float,
            Double,
            String,
            Byte,
            Binary,
            Boolean,
            Date,
            DateTime,
            Password,
            Object
        };

        private ApiConnectType CheckIntegerFormat() 
        {
            switch(Format)
            {
                case FormatType.Int32:
                    return ApiConnectType.Integer;
                case FormatType.Int64:
                    return ApiConnectType.Long;
                default:
                    throw new ArgumentException("The parameter haven't a valid format");

            }
        }

        private ApiConnectType CheckNumberFormat() 
        {
            switch(Format)
            {
                case FormatType.Float:
                    return ApiConnectType.Float;
                case FormatType.Double:
                    return ApiConnectType.Double;
                default:
                    throw new ArgumentException("The parameter haven't a valid format");

            }
        }

        private ApiConnectType CheckStringFormat() 
        {
            switch(Format)
            {
                case FormatType.Undefined:
                    return ApiConnectType.String;
                case FormatType.Byte:
                    return ApiConnectType.Byte;
                case FormatType.Binary:
                    return ApiConnectType.Binary;
                case FormatType.Date:
                    return ApiConnectType.Date;
                case FormatType.DateTime:
                    return ApiConnectType.DateTime;
                default:                
                    throw new ArgumentException("The parameter haven't a valid format");

            }
        }

        private ApiConnectType CheckBooleanFormat() 
        {
            switch(Format)
            {
                case FormatType.Undefined:
                    return ApiConnectType.Boolean;
                default:                
                    throw new ArgumentException("The parameter haven't a valid format");
            }
        }

        public ApiConnectType ToApiConnectType()
        {
            switch(Type)
            {
                case ParameterType.Integer:
                    return CheckIntegerFormat();
                case ParameterType.Number:
                    return CheckNumberFormat();
                case ParameterType.String:
                    return CheckStringFormat();
                case ParameterType.Boolean:
                    return CheckBooleanFormat();
                case ParameterType.Object:
                    return ApiConnectType.Object;
                default:
                    throw new ArgumentException("The parameter haven't a valid type");
            }
        }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ParameterType Type { get; set; }
        

        [JsonProperty("format")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FormatType Format { get; set; }

        #region  IDataType
        
        [JsonProperty("name")]
        string IDataType.Name { get; set; }
        
        #endregion
    }
}