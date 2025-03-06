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
            Console.WriteLine("Simple serialize :\n" + simpleSerialized);
            stopwatch.Stop();
            Console.WriteLine("Simple serialize time : " + stopwatch.ElapsedMilliseconds + "ms");
            stopwatch.Restart();
            stopwatch.Start();
            var serializer = new EmitSerializer();
            string emitSerialized = serializer.Serialize(person);
            Console.WriteLine("Emit serialize :\n" + emitSerialized);
            stopwatch.Stop();
            Console.WriteLine("Emit serialize time : " + stopwatch.ElapsedMilliseconds + "ms");
        }
    }

    /// <summary>
    /// Person model
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Person name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Person age
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Person hobbies
        /// </summary>
        public List<string> Hobbies { get; set; }

        /// <summary>
        /// Constructor to initialize values
        /// </summary>
        /// <param name="name">Person name</param>
        /// <param name="age">Person age</param>
        /// <param name="hobbies">Person hobbies</param>
        public Person(string name, int age, List<string> hobbies)
        {
            Name = name;
            Age = age;
            Hobbies = hobbies;
        }
    }
}
