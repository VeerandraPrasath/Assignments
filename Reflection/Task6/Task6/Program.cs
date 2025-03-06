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

    /// <summary>
    /// Build mock objects
    /// </summary>
    public class MockBuilder
    {
        /// <summary>
        /// Create mock object
        /// </summary>
        /// <param name="interfaceType">Interface type</param>
        /// <returns>Returns the type</returns>
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

    /// <summary>
    /// Math operations interface
    /// </summary>
    public interface IMathOperations
    {
        /// <summary>
        /// Add two numbers
        /// </summary>
        /// <param name="a">Number 1</param>
        /// <param name="b">Number 2</param>
        /// <returns>Returns the sum</returns>
        int Add(int a, int b);

        /// <summary>
        /// Subtract two numbers
        /// </summary>
        /// <param name="a">Number 1</param>
        /// <param name="b">Number 2</param>
        /// <returns>Returns the difference</returns>
        int Subtract(int a, int b);
    }
}
