using System.Reflection;

namespace Task1
{
    internal class Program
    {
        const string assemblyPath = "C:\\Users\\veerandra.prasath\\source\\repos\\ContactManager\\Reflection\\Task1\\bin\\Debug\\net8.0\\AssemblyModel.dll";
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFile(assemblyPath);
            Console.WriteLine($"Assembly: {assembly.FullName}\n");
            Console.WriteLine("******************************************************************");

            Type[] types = assembly.GetTypes();

            foreach (Type type in types)
            {
                Console.WriteLine($"Type: {type.FullName}");
                Console.WriteLine("__________\n");
                Console.WriteLine("Methods:");
                Console.WriteLine("__________");
                MethodInfo[] methods = type.GetMethods();
                foreach (MethodInfo method in methods)
                {
                    Console.WriteLine($"- {method.Name}");
                }
                Console.WriteLine();
                Console.WriteLine("Properties:");
                Console.WriteLine("______________");

                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    Console.WriteLine($"- {property.Name}");
                }
                Console.WriteLine();
                Console.WriteLine("Fields:");
                Console.WriteLine("__________");
                FieldInfo[] fields = type.GetFields();
                foreach (FieldInfo field in fields)
                {
                    Console.WriteLine($"- {field.Name}");
                }
                Console.WriteLine();
                Console.WriteLine("Events:");
                Console.WriteLine("__________");
                EventInfo[] events = type.GetEvents();
                foreach (EventInfo eventInfo in events)
                {
                    Console.WriteLine($"- {eventInfo.Name}");
                }
            }
        }
    }
}
