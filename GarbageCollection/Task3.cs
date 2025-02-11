namespace GarbageCollection
{
    /// <summary>
    /// Used to implement the task3
    /// </summary>
    public class Task3
    {
        /// <summary>
        /// Generates a large number of objects and removes every second object from the list
        /// </summary>
        public void GenerateLargeNumberOfObjects()
        {
            List<ReferenceObject> objectList = new List<ReferenceObject>();
            for (int i = 0; i < 100000; i++)
            {
                ReferenceObject obj = new ReferenceObject(i);
                objectList.Add(obj);
                if (i % 2 == 0)
                {
                    objectList.Remove(obj);
                }
            }
            GC.Collect();
        }

    }

    /// <summary>
    /// Represents a reference object
    /// </summary>
    public class ReferenceObject
    {
        /// <summary>
        /// Store the integer value
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Constructor to initialize the value
        /// </summary>
        /// <param name="value">Any integer value</param>
        public ReferenceObject(int value)
        {
            Value = value;
        }
    }
}
