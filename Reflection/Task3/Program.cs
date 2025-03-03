using System.Reflection;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MethodModel methodModel = new MethodModel();
            MethodInvoker invoker = new MethodInvoker();
            invoker.InvokeMethod(methodModel, "Hi");
            invoker.InvokeMethod(methodModel, "Hello");
            invoker.InvokeMethod(methodModel, "Welcome");
            invoker.InvokeMethod(methodModel, "UnknownMethod");
        }
    }

    /// <summary>
    /// MethodModel class contains methods to invoke
    /// </summary>
    public class MethodModel
    {
        /// <summary>
        /// Hi Method
        /// </summary>
        public void Hi()
        {
            Console.WriteLine($"Invoked Hi Method ");
        }

        /// <summary>
        /// Hello method
        /// </summary>
        public void Hello()
        {
            Console.WriteLine($"Invoked Hello Method");
        }

        /// <summary>
        /// Welcome method
        /// </summary>
        public void Welcome()
        {
            Console.WriteLine($"Invoked Welcome Method ");
        }
    }

    /// <summary>
    /// Contains the implementation to Invoke the methods
    /// </summary>
    public class MethodInvoker
    {
        /// <summary>
        /// Invokes the method
        /// </summary>
        /// <param name="obj">Object of the type</param>
        /// <param name="methodName">Name of the method</param>
        public void InvokeMethod(object obj, string methodName)
        {
            Type type = obj.GetType();
            MethodInfo methodInfo = type.GetMethod(methodName);
            if (methodInfo != null)
            {
                methodInfo.Invoke(obj, []);
            }
            else
            {
                Console.WriteLine($"Method '{methodName}' not found.");
            }
        }
    }
}
