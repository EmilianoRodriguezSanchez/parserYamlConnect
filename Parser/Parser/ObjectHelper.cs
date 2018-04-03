using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace YamlParserConnect.Parser.Parser
{
    public static class ObjectHelper
    {
        public static T DictionaryToObject<T>(IDictionary<object, object> dict) where T : new()
        {
            var t = new T();
            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (!dict.Any(x => x.Key.GetType().ToString().Equals(property.Name, StringComparison.InvariantCultureIgnoreCase)))
                {

                }


            /*
                KeyValuePair<object, object> item = dict.First(x => x.Key.GetType().ToString().Equals(property.Name, StringComparison.InvariantCultureIgnoreCase));

                // Find which property type (int, string, double? etc) the CURRENT property is...
                Type tPropertyType = typeof(T).GetProperty(property.Name).PropertyType;

                // Fix nullables...
                Type newT = Nullable.GetUnderlyingType(tPropertyType) ?? tPropertyType;

                // ...and change the type
                object newA =System.Convert.ChangeType(item.Value, newT);
                typeof(T).GetProperty(property.Name).SetValue(t, newA, null);
                */
            }
            return t;
        }

    }
}
