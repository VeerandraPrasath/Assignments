using System.Diagnostics;

namespace Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var person = new Person("Prasath", 25, new List<string> { "Reading", "Traveling", "Swimming" });
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            SimpleSerializer simpleSerializer = new SimpleSerializer();
            string simpleSerialized = simpleSerializer.Serialize(person);
            Console.WriteLine("Simple serialize :\n"+simpleSerialized);
            stopwatch.Stop();
            Console.WriteLine("Simple serialize time : " + stopwatch.ElapsedMilliseconds + "ms");
            stopwatch.Restart();
            stopwatch.Start();
            var serializer = new EmitSerializer();
            string emitSerialized = serializer.Serialize(person);
            Console.WriteLine("Emit serialize :\n"+emitSerialized);
            stopwatch.Stop();
            Console.WriteLine("Emit serialize time : " + stopwatch.ElapsedMilliseconds + "ms");
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Hobbies { get; set; }

        public Person(string name, int age, List<string> hobbies)
        {
            Name = name;
            Age = age;
            Hobbies = hobbies;
        }
    }

}
