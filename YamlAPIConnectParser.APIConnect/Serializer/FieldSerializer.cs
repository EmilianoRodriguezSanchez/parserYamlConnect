using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace YamlAPIConnectParser.APIConnect.Serializer
{
    public static class FieldSerializer
    {
        /// <summary>
        /// </summary>
        public static void Serialize<T>(string output, object value)
        {

            IEnumerable<MemberInfo> fields = GetMemberInfos<T>();
            output= QuoteRecord(FormatObject<T>(fields, value));
        }


        static string QuoteRecord(IEnumerable<string> record)
        {
            return String.Join(Separator, record.ToArray());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static IEnumerable<MemberInfo> GetMemberInfos<T>()
        {
            return from mi in typeof(T).GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                   //where new[] { MemberTypes.Field, MemberTypes.Property }.Contains(mi.MemberType)
                  // let orderAttr = (ColumnOrderAttribute)Attribute.GetCustomAttribute(mi, typeof(ColumnOrderAttribute))
                  // orderby orderAttr == null ? int.MaxValue : orderAttr.Order, mi.Name
                   select mi;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fields"></param>
        /// <param name="record"></param>
        /// <returns></returns>
        static IEnumerable<string> FormatObject<T>(IEnumerable<MemberInfo> fields, object record)
        {
            string data;
            foreach (var field in fields)
            {
                data = FormatObject( field, record);

                yield return data;

            }
        }

        private static string FormatObject<T>( MemberInfo field, T record)
        {
            string data;
            if (field is FieldInfo)
            {
                var fi = (FieldInfo)field;
                data = string.Format("{0}{1}{2}{3}{4}{5}", fi.Name, Separator, fi.GetType(), Separator, System.Convert.ToString(fi.GetValue(record)), Separator);
            }
            else if (field is PropertyInfo)
            {
                var pi = (PropertyInfo)field;
                data = string.Format("{0}{1}{2}{3}{4}{5}", pi.Name, Separator, pi.GetType() , Separator, System.Convert.ToString(pi.GetValue(record, null)), Separator);
            }
            else
            {
                throw new Exception("Unhandled case.");
            }

            return data;
        }

        public static  string Separator { get; set; } = ",";
        
        [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
        public class ColumnOrderAttribute : Attribute
        {
            public int Order { get; private set; }
            public ColumnOrderAttribute(int order) { Order = order; }
        }
    }
}
