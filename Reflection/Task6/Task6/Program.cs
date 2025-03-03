using System.Reflection.Emit;
using System.Reflection;

namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MockBuilder mockBuilder = new MockBuilder();
            mockBuilder.CreateMock(typeof(IMathOperations));
            Console.ReadKey();
        }
    }

    public class MockBuilder
    {
        public Type CreateMock(Type interfaceType)
        {
            AssemblyName assemblyName = new AssemblyName("DynamicMockAssembly");
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);

            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicMockModule");

            TypeBuilder typeBuilder = moduleBuilder.DefineType("DynamicMock", TypeAttributes.Public);
            typeBuilder.AddInterfaceImplementation(interfaceType);

            foreach (MethodInfo method in interfaceType.GetMethods())
            {
                MethodBuilder methodBuilder = typeBuilder.DefineMethod(
                    method.Name,
                    MethodAttributes.Public | MethodAttributes.Virtual,
                    method.ReturnType,
                    Array.ConvertAll(method.GetParameters(), p => p.ParameterType));

                ILGenerator il = methodBuilder.GetILGenerator();

                if (method.ReturnType == typeof(int))
                {
                    il.Emit(OpCodes.Ldc_I4_0);
                }
                else if (method.ReturnType == typeof(double))
                {
                    il.Emit(OpCodes.Ldc_R8, 0.0);
                }
                else
                {
                    il.Emit(OpCodes.Ldnull);
                }

                il.Emit(OpCodes.Ret);
            }

            return typeBuilder.CreateType();
        }
    }

    public interface IMathOperations
    {
        int Add(int a, int b);
        int Subtract(int a, int b);
    }
}
