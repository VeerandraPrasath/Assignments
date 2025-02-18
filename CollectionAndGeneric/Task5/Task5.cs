using CollectionAndGeneric.Task5.GenericCollectionImplementation;

namespace CollectionAndGeneric.Task5
{
    /// <summary>
    /// Class to implement task5
    /// </summary>
    public class Task5
    {
        /// <summary>
        /// Invoke all the collections
        /// </summary>
        public void Run()
        {
            Console.WriteLine("Generic List operations");
            new ListImplementation().Run();
            Console.WriteLine("Generic Stack operations");
            new StackImplementation().Run();
            Console.WriteLine("Generic Queue operations");
            new QueueImplementation().Run();
            Console.WriteLine("Generic Dictionary operations");
            new DictionaryImplementation().Run();
        }
    }
}



