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

    public class MethodModel
    {
        public void Hi()
        {
            Console.WriteLine($"Invoked Hi Method ");
        }

        public void Hello()
        {
            Console.WriteLine($"Invoked Hello Method");
        }

        public void Welcome()
        {
            Console.WriteLine($"Invoked Welcome Method ");
        }
    }

    public class MethodInvoker
    {
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
