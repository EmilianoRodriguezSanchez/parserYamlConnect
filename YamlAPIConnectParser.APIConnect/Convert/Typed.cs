using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace YamlAPIConnectParser.APIConnect.Convert
{
    class Typed
    {
        public static string TypedValueToString(object RawValue, CultureInfo Culture)
        {
            Type ValueType = RawValue.GetType();
            string Return = null;

            if (ValueType == typeof(string))
                Return = RawValue.ToString();
            else if (ValueType == typeof(int) || ValueType == typeof(decimal) ||
                  ValueType == typeof(double) || ValueType == typeof(float))
                Return = string.Format(Culture.NumberFormat, "{0}", RawValue);
            else if (ValueType == typeof(DateTime))
                Return = string.Format(Culture.DateTimeFormat, "{0}", RawValue);
            else if (ValueType == typeof(bool))
                Return = RawValue.ToString();
            else if (ValueType == typeof(byte))
                Return = RawValue.ToString();
            else if (ValueType.IsEnum)
                Return = RawValue.ToString();
            else
            {
                // Any type that supports a type converter
                System.ComponentModel.TypeConverter converter =
                      System.ComponentModel.TypeDescriptor.GetConverter(ValueType);
                if (converter != null && converter.CanConvertTo(typeof(string)))
                    Return = converter.ConvertToString(RawValue);
                else
                    // Last resort - just call ToString() on unknown type
                    Return = RawValue.ToString();
            }

            return Return;
        }

        public static object StringToTypedValue(string SourceString, Type TargetType, CultureInfo Culture)
        {

            object Result = null;


            if (TargetType == typeof(string))
                Result = SourceString;
            else if (TargetType == typeof(int))
                Result = int.Parse(SourceString,
                           System.Globalization.NumberStyles.Integer, Culture.NumberFormat);
            else if (TargetType == typeof(byte))
                Result =System.Convert.ToByte(SourceString);
            else if (TargetType == typeof(decimal))
                Result = Decimal.Parse(SourceString, System.Globalization.NumberStyles.Any, Culture.NumberFormat);
            else if (TargetType == typeof(double))
                Result = Double.Parse(SourceString, System.Globalization.NumberStyles.Any, Culture.NumberFormat);
            else if (TargetType == typeof(bool))
            {
                if (SourceString.ToLower() == "true" || SourceString.ToLower() == "on" || SourceString == "1")
                    Result = true;
                else
                    Result = false;
            }
            else if (TargetType == typeof(DateTime))
                Result = System.Convert.ToDateTime(SourceString, Culture.DateTimeFormat);
            else if (TargetType.IsEnum)
                Result = Enum.Parse(TargetType, SourceString);
            else
            {
                System.ComponentModel.TypeConverter converter =
                          System.ComponentModel.TypeDescriptor.GetConverter(TargetType);
                if (converter != null && converter.CanConvertFrom(typeof(string)))
                    Result = converter.ConvertFromString(SourceString);
                else
                {
                    throw (new Exception("Type Conversion not handled in StringToTypedValue"));
                }
            }

            return Result;
        }

    }
}
