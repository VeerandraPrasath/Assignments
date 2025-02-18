
namespace CollectionAndGeneric.Task3
{
    /// <summary>
    /// Class to implement task3
    /// </summary>
    public class Task3
    {
        /// <summary>
        /// Queue stores people
        /// </summary>
        public Queue<string> PeopleQueue { get; set; }

        /// <summary>
        /// Constructor to initialize values
        /// </summary>
        public Task3()
        {
            PeopleQueue = new Queue<string>();
        }

        /// <summary>
        /// Invoke all the methods
        /// </summary>
        public void Run()
        {
            AddPeopleToQueue();
            ServePeople();
            DisplayPeopleInQueue();
        }

        /// <summary>
        /// Add people to the _queue
        /// </summary>
        public void AddPeopleToQueue()
        {
            Console.WriteLine("Enter the number of people to add to the _queue: ");
            int numberOfPeople = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPeople; i++)
            {
                Console.Write("Enter the name of person " + (i + 1) + ": ");
                string name = Console.ReadLine();
                PeopleQueue.Enqueue(name);
            }
        }

        /// <summary>
        /// Remove people from the _queue
        /// </summary>
        public void ServePeople()
        {
            if (PeopleQueue.Count == 0)
            {
                Console.WriteLine("No people in the _queue.");
                return;
            }
            else
            {
                Console.WriteLine("Enter the number of people to serve: ");
                int numberOfPeople = int.Parse(Console.ReadLine());
                for (int i = 0; i < numberOfPeople; i++)
                {
                    Console.WriteLine($"Served {PeopleQueue.Dequeue()} in the _queue: ");
                }
            }
        }

        /// <summary>
        /// Display peoples in the _queue
        /// </summary>
        public void DisplayPeopleInQueue()
        {
            Console.WriteLine("People in the _queue: ");
            foreach (string person in PeopleQueue)
            {
                Console.WriteLine(person);
            }
        }
    }
}
