using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace YamlAPIConnectParser.APIConnect.Reflection
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class PropertyHelper<T> where T : class, new()
    {

        private static PropertyInfo[] _properties;
        /// <summary>
        /// Determines whether [is ca write] [the specified nameproperty].
        /// </summary>
        /// <param name="nameproperty">The nameproperty.</param>
        /// <returns>
        ///   <c>true</c> if [is ca write] [the specified nameproperty]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsCaWrite(string nameproperty)
        {
            return typeof(T).GetProperty(nameproperty, BindingFlags.Public | BindingFlags.Instance).CanWrite;
        }
        /// <summary>
        /// Creates the property.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="nameproperty">The nameproperty.</param>
        /// <param name="typeProperty">The type property.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static T CreateProperty(string nameproperty, Type typeProperty, object value)
        {
            Type type = typeof(T);
            var obj = Activator.CreateInstance(type);

            PropertyInfo prop = type.GetProperty(nameproperty, BindingFlags.Public | BindingFlags.Instance);
            if (null == prop)
            {
                try
                {
                    type.InvokeMember(nameproperty,
                        BindingFlags.Public |
                        BindingFlags.Instance | BindingFlags.SetProperty,
                        null, obj, new object[] { value });
                }
                catch (MissingFieldException e)
                {
                    // Show the user that the DoSomething method cannot be called.
                    Console.WriteLine("Unable to call the DoSomething method: {0}", e.Message);
                }
            }
            else if (null != prop && prop.CanWrite)
            {
                var valueOld = prop.GetValue(obj, null);
                if (valueOld != value) { prop.SetValue(obj, value, null); }
            }
            return (T)obj;

        }


        /// <summary>
        /// Gets the properties.
        /// </summary>
        /// <returns></returns>
        public static PropertyInfo[] GetProperties()
        {
            _properties = typeof(T).GetProperties();

            return _properties;
        }

        public static readonly string ColumnAttributeName = "ColumnAttribute";
        /// <summary>
        /// Selects the property.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        private static PropertyInfo SelectProperty(string columnName)
        {
            return
                typeof(T).GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).
                    FirstOrDefault(
                        prop =>
                        prop.GetCustomAttributes(false)
                            // Search properties to find the one ColumnAttribute applied with Name property set as columnName to be Mapped 
                            .Any(attr => attr.GetType().Name == ColumnAttributeName
                                         &&
                                         attr.GetType().GetProperties(BindingFlags.Public |
                                                                      BindingFlags.NonPublic |
                                                                      BindingFlags.Instance)
                                             .Any(
                                                 f =>
                                                 f.Name == "Name" &&
                                                 f.GetValue(attr).ToString().ToLower() == columnName.ToLower()))
                        && // Also ensure the property is not read-only
                        (prop.DeclaringType == typeof(T)
                             ? prop.GetSetMethod(true)
                             : prop.DeclaringType.GetProperty(prop.Name,
                                                              BindingFlags.Public | BindingFlags.NonPublic |
                                                              BindingFlags.Instance).GetSetMethod(true)) != null
                    );
        }




        /// <summary>
        /// Gets the select properties.
        /// </summary>
        /// <value>
        /// The select properties.
        /// </value>
        private static Expression<Func<T, List<string>>> SelectProperties
        {
            get
            {
                return value => _properties.Select
                               (
                                   prop => (prop.GetValue(value, new object[0]) ?? string.Empty).ToString()
                               ).ToList();
            }
        }



        /// <summary>
        /// Exists the property.
        /// </summary>
        /// <param name="nampeProperty">The nampe property.</param>
        /// <returns></returns>
        public static bool ExistProperty(string nampeProperty)
        {
            return GetProperty(nampeProperty) != null;
        }

        /// <summary>
        /// Gets the property.
        /// </summary>
        /// <param name="nampeProperty">The nampe property.</param>
        /// <returns></returns>
        public static PropertyInfo GetProperty(string nampeProperty)
        {
            try
            {
                return typeof(T).GetProperty(nampeProperty);
            }

            catch (NullReferenceException)
            {
                return null;
            }
        }
        /// <summary>
        /// Gets the property.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="selector">The selector.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static PropertyInfo GetProperty<TValue>(
            Expression<Func<T, TValue>> selector)
        {
            Expression body = selector;
            if (body is LambdaExpression)
            {
                body = ((LambdaExpression)body).Body;
            }
            switch (body.NodeType)
            {
                case ExpressionType.MemberAccess:
                    return (PropertyInfo)((MemberExpression)body).Member;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
