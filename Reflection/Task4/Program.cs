using System.Reflection.Emit;
using System.Reflection;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DynamicTypeBuilder typeBuilder = new DynamicTypeBuilder();
            string typeName = "DynamicPerson";
            string propertyName = "Name";
            Type propertyType = typeof(string);
            string methodName = "DisplayValues";
            Type dynamicType = typeBuilder.CreateDynamicType(typeName, propertyName, propertyType, methodName);
            object dynamicInstance = Activator.CreateInstance(dynamicType);
            dynamicType.GetProperty(propertyName).SetValue(dynamicInstance, "Prasath");
            dynamicType.GetMethod(methodName).Invoke(dynamicInstance, null);
            string name = (string)dynamicType.GetProperty(propertyName).GetValue(dynamicInstance);
            Console.WriteLine($"Property '{propertyName}' value: {name}");
        }
    }

    /// <summary>
    /// Dynamic type builder class
    /// </summary>
    public class DynamicTypeBuilder
    {
        /// <summary>
        /// Create dynamic types
        /// </summary>
        /// <param name="typeName">Name of the type</param>
        /// <param name="propertyName">Name of the property</param>
        /// <param name="propertyType">Name of the PropertyType</param>
        /// <param name="methodName">Name of the method</param>
        /// <returns></returns>
        public Type CreateDynamicType(string typeName, string propertyName, Type propertyType, string methodName)
        {
            AssemblyName assemblyName = new AssemblyName("DynamicAssembly");
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);

            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicModule");

            TypeBuilder typeBuilder = moduleBuilder.DefineType(typeName, TypeAttributes.Public);

            FieldBuilder fieldBuilder = typeBuilder.DefineField($"_{propertyName.ToLower()}", propertyType, FieldAttributes.Private);

            PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(propertyName, PropertyAttributes.HasDefault, propertyType, null);

            MethodBuilder getMethodBuilder = typeBuilder.DefineMethod($"get_{propertyName}", MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig | MethodAttributes.Virtual, propertyType, Type.EmptyTypes);
            ILGenerator getIL = getMethodBuilder.GetILGenerator();
            getIL.Emit(OpCodes.Ldarg_0);
            getIL.Emit(OpCodes.Ldfld, fieldBuilder);
            getIL.Emit(OpCodes.Ret);

            MethodBuilder setMethodBuilder = typeBuilder.DefineMethod($"set_{propertyName}", MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig | MethodAttributes.Virtual, null, new Type[] { propertyType });
            ILGenerator setIL = setMethodBuilder.GetILGenerator();
            setIL.Emit(OpCodes.Ldarg_0);
            setIL.Emit(OpCodes.Ldarg_1);
            setIL.Emit(OpCodes.Stfld, fieldBuilder);
            setIL.Emit(OpCodes.Ret);

            propertyBuilder.SetGetMethod(getMethodBuilder);
            propertyBuilder.SetSetMethod(setMethodBuilder);

            MethodBuilder methodBuilder = typeBuilder.DefineMethod(methodName, MethodAttributes.Public, null, null);
            ILGenerator methodIL = methodBuilder.GetILGenerator();
            methodIL.EmitWriteLine($"Method '{methodName}' called.");
            methodIL.Emit(OpCodes.Ret);

            Type dynamicType = typeBuilder.CreateType();

            return dynamicType;
        }
    }

}
