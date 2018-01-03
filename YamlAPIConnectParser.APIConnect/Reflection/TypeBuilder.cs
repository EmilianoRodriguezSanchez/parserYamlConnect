using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
namespace YamlAPIConnectParser.APIConnect.Reflection
{
    public class Field
    {
        public string FieldName { get; internal set; }
        public Type FieldType { get; internal set; }
    }

    public  class TypeBuilder<T>: TypeBuilderBase
        where T : class, new()
    {
        private  Type type = typeof(T);
        public static object CreateNewObject()
        {

            IEnumerable<Field> fields = typeof(T).GetMembers(BindingFlags.CreateInstance   |
                                                            BindingFlags.DeclaredOnly |
                                                            BindingFlags.Instance |
                                                            BindingFlags.Static |
                                                            BindingFlags.Public |
                                                            BindingFlags.NonPublic 
                                                            ).Where(mInfo =>mInfo is FieldInfo).Select(mInfo => new Field() { FieldName = mInfo.Name, FieldType = mInfo.GetType() });
        

      
          return CreateNewObject(typeof(T).Assembly.GetName().Name, typeof(T).ToString(), fields);

        }
        

    }
    /// <summary>
    /// 
    /// </summary>
    public class TypeBuilderBase
    {
        /// <summary>
        /// Creates the new object.
        /// </summary>
        /// <param name="assemblyname">The assemblyname.</param>
        /// <param name="classname">The classname.</param>
        /// <returns></returns>
        public static object CreateNewObject(string assemblyname, string classname, IEnumerable<Field> fields)
        {
            var type = CompileResultType( assemblyname,  classname, fields);
           return  Activator.CreateInstance(type);
        }
        /// <summary>
        /// Compiles the type of the result.
        /// </summary>
        /// <param name="assemblyname">The assemblyname.</param>
        /// <param name="classname">The classname.</param>
        /// <returns></returns>
        public static Type CompileResultType(string assemblyname, string classname, IEnumerable<Field> fields)
        {
            TypeBuilder tb = GetTypeBuilder(assemblyname, classname);
            ConstructorBuilder constructor = tb.DefineDefaultConstructor(MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);

            // NOTE: assuming your list contains Field objects with fields FieldName(string) and FieldType(Type)
            foreach (var field in fields)
              CreateProperty(tb, field.FieldName, field.FieldType);

            Type objectType = tb.CreateType();
            return objectType;
        }

        /// <summary>
        /// Gets the type builder.
        /// </summary>
        /// <param name="assemblyname">The assemblyname.</param>
        /// <param name="classname">The classname.</param>
        /// <returns></returns>
        private static TypeBuilder GetTypeBuilder(string assemblyname, string classname)
        {
            var an = new AssemblyName(assemblyname);
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(an, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(an.Name);
            TypeBuilder tb = moduleBuilder.DefineType(classname,
                    TypeAttributes.Public |
                    TypeAttributes.Class |
                    TypeAttributes.AutoClass |
                    TypeAttributes.AnsiClass |
                    TypeAttributes.BeforeFieldInit |
                    TypeAttributes.AutoLayout,
                    null);
            return tb;
        }
        /// <summary>
        /// Creates the property.
        /// </summary>
        /// <param name="tb">The tb.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="propertyType">Type of the property.</param>
        private static void CreateProperty(TypeBuilder tb, string propertyName, Type propertyType)
        {
            FieldBuilder fieldBuilder = tb.DefineField("_" + propertyName, propertyType, FieldAttributes.Private);

            PropertyBuilder propertyBuilder = tb.DefineProperty(propertyName, PropertyAttributes.HasDefault, propertyType, null);
            MethodBuilder getPropMthdBldr = tb.DefineMethod("get_" + propertyName, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, propertyType, Type.EmptyTypes);
            ILGenerator getIl = getPropMthdBldr.GetILGenerator();

            getIl.Emit(OpCodes.Ldarg_0);
            getIl.Emit(OpCodes.Ldfld, fieldBuilder);
            getIl.Emit(OpCodes.Ret);

            MethodBuilder setPropMthdBldr =
                tb.DefineMethod("set_" + propertyName,
                  MethodAttributes.Public |
                  MethodAttributes.SpecialName |
                  MethodAttributes.HideBySig,
                  null, new[] { propertyType });

            ILGenerator setIl = setPropMthdBldr.GetILGenerator();
            Label modifyProperty = setIl.DefineLabel();
            Label exitSet = setIl.DefineLabel();

            setIl.MarkLabel(modifyProperty);
            setIl.Emit(OpCodes.Ldarg_0);
            setIl.Emit(OpCodes.Ldarg_1);
            setIl.Emit(OpCodes.Stfld, fieldBuilder);

            setIl.Emit(OpCodes.Nop);
            setIl.MarkLabel(exitSet);
            setIl.Emit(OpCodes.Ret);

            propertyBuilder.SetGetMethod(getPropMthdBldr);
            propertyBuilder.SetSetMethod(setPropMthdBldr);
        }

       
    }


}
