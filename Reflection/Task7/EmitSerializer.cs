using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Newtonsoft.Json;

public class EmitSerializer
{
    private delegate string SerializeDelegate(object obj);
    private readonly Dictionary<Type, SerializeDelegate> _serializeMethods = new Dictionary<Type, SerializeDelegate>();

    public string Serialize(object obj)
    {
        if (obj == null) return "null";

        Type type = obj.GetType();
        if (!_serializeMethods.TryGetValue(type, out var serializeMethod))
        {
            serializeMethod = CreateSerializeMethod(type);
            _serializeMethods[type] = serializeMethod;
        }

        return serializeMethod(obj);
    }

    private SerializeDelegate CreateSerializeMethod(Type type)
    {
        var dynamicMethod = new DynamicMethod($"Serialize_{type.Name}", typeof(string), new Type[] { typeof(object) }, type.Module);
        var il = dynamicMethod.GetILGenerator();

        if (type.IsPrimitive || type == typeof(string))
        {
            il.Emit(OpCodes.Ldarg_0);
            if (type.IsValueType)
            {
                il.Emit(OpCodes.Box, type);
            }
            il.Emit(OpCodes.Call, typeof(JsonConvert).GetMethod("SerializeObject", new Type[] { typeof(object) }));
            il.Emit(OpCodes.Ret);
        }
        else if (typeof(IEnumerable).IsAssignableFrom(type))
        {
            var enumerator = il.DeclareLocal(typeof(IEnumerator));
            var list = il.DeclareLocal(typeof(List<object>));
            var addMethod = typeof(List<object>).GetMethod("Add");

            il.Emit(OpCodes.Newobj, typeof(List<object>).GetConstructor(Type.EmptyTypes));
            il.Emit(OpCodes.Stloc, list);

            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Callvirt, typeof(IEnumerable).GetMethod("GetEnumerator"));
            il.Emit(OpCodes.Stloc, enumerator);

            var loopStart = il.DefineLabel();
            var loopEnd = il.DefineLabel();

            il.MarkLabel(loopStart);
            il.Emit(OpCodes.Ldloc, enumerator);
            il.Emit(OpCodes.Callvirt, typeof(IEnumerator).GetMethod("MoveNext"));
            il.Emit(OpCodes.Brfalse, loopEnd);

            il.Emit(OpCodes.Ldloc, enumerator);
            il.Emit(OpCodes.Callvirt, typeof(IEnumerator).GetMethod("get_Current"));
            il.Emit(OpCodes.Call, typeof(JsonConvert).GetMethod("SerializeObject", new Type[] { typeof(object) }));
            il.Emit(OpCodes.Ldloc, list);
            il.Emit(OpCodes.Callvirt, addMethod);

            il.Emit(OpCodes.Br, loopStart);

            il.MarkLabel(loopEnd);
            il.Emit(OpCodes.Ldloc, list);
            il.Emit(OpCodes.Call, typeof(JsonConvert).GetMethod("SerializeObject", new Type[] { typeof(object) }));
            il.Emit(OpCodes.Ret);
        }
        else
        {
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var dictionary = il.DeclareLocal(typeof(Dictionary<string, object>));
            var addMethod = typeof(Dictionary<string, object>).GetMethod("Add");

            il.Emit(OpCodes.Newobj, typeof(Dictionary<string, object>).GetConstructor(Type.EmptyTypes));
            il.Emit(OpCodes.Stloc, dictionary);

            foreach (var property in properties)
            {
                il.Emit(OpCodes.Ldloc, dictionary);
                il.Emit(OpCodes.Ldstr, property.Name);
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Castclass, type);
                il.Emit(OpCodes.Callvirt, property.GetGetMethod());
                if (property.PropertyType.IsValueType)
                {
                    il.Emit(OpCodes.Box, property.PropertyType);
                }
                il.Emit(OpCodes.Call, typeof(JsonConvert).GetMethod("SerializeObject", new Type[] { typeof(object) }));
                il.Emit(OpCodes.Callvirt, addMethod);
            }
            il.Emit(OpCodes.Ldloc, dictionary);
            il.Emit(OpCodes.Call, typeof(JsonConvert).GetMethod("SerializeObject", new Type[] { typeof(object) }));
            il.Emit(OpCodes.Ret);
        }

        return (SerializeDelegate)dynamicMethod.CreateDelegate(typeof(SerializeDelegate));
    }

}