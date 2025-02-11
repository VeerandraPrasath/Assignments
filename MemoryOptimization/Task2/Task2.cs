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
        public int N { get; set; }

        /// <summary>
        /// Stores the list of integer array
        /// </summary>
        public List<int[]> memalloc { get; set; }

        /// <summary>
        /// Constructor to initialize the list
        /// </summary>
        public Task2()
        {
            memalloc = new List<int[]>();
        }

        /// <summary>
        /// Get the number of elements to allocate from the user
        /// </summary>
        public void GetValuesFromUser()
        {
            Console.WriteLine("Enter the number of elements to allocate");
            N = Convert.ToInt32(Console.ReadLine());
        }

        /// <summary>
        /// Allocate the memory for the elements
        /// </summary>
        public void Allocate()
        {
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Enter the size for element {i + 1} :");
                int size = Convert.ToInt32(Console.ReadLine());
                memalloc.Add(new int[size]);
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// Dispose the memory allocated
        /// </summary>
        public void Dispose()
        {
            memalloc.Clear();
        }
    }
}
