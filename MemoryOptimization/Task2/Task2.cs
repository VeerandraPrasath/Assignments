namespace MemoryOptimization.Task2
{
    /// <summary>
    /// Used to implement the Task 2
    /// </summary>
    public class Task2 : IDisposable
    {
        /// <summary>
        /// Number of elements to allocate
        /// </summary>
        public int NumberOfElement { get; set; }

        /// <summary>
        /// Stores the list of integer array
        /// </summary>
        public List<int[]> IntegerArrayList { get; set; }

        /// <summary>
        /// Constructor to initialize the list
        /// </summary>
        public Task2()
        {
            IntegerArrayList = new List<int[]>();
        }

        /// <summary>
        /// Get the number of elements to allocate from the user
        /// </summary>
        public void GetValuesFromUser()
        {
            Console.WriteLine("Enter the number of elements to allocate");
            NumberOfElement = Convert.ToInt32(Console.ReadLine());
        }

        /// <summary>
        /// Allocate the memory for the elements
        /// </summary>
        public void Allocate()
        {
            for (int i = 0; i < NumberOfElement; i++)
            {
                Console.WriteLine($"Enter the size for element {i + 1} :");
                int size = Convert.ToInt32(Console.ReadLine());
                IntegerArrayList.Add(new int[size]);
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// Dispose the memory allocated
        /// </summary>
        public void Dispose()
        {
            IntegerArrayList.Clear();
        }
    }
}
