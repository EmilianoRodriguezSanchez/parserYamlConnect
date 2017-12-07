using System;
using System.ComponentModel;
using System.Globalization;
using YamlAPIConnectParser.APIConnect.Serializer;

namespace YamlAPIConnectParser.APIConnect.Convert
{
    public class ObjectConvert<T>: TypeConverter  where T : class 
    {
        Type type = typeof(T);
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {

            if (sourceType == type)
                return true;
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                return default(T);
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(T))
            {
                CsvSerializer.CsvSeparator = "|";
                string stringdata  = "";
                FieldSerializer.Serialize<T>( stringdata, value);
                return stringdata;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

}
