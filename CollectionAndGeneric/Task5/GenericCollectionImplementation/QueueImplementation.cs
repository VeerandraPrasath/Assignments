using CollectionAndGeneric.Task5.GenericClasses;

namespace CollectionAndGeneric.Task5.GenericCollectionImplementation
{
    /// <summary>
    /// Class implements GenericQueue operations
    /// </summary>
    public class QueueImplementation
    {
        private GenericQueue<string> _stringQueue { get; set; }
        private GenericQueue<int> _intQueue { get; set; }

        /// <summary>
        /// Constructor initialize value
        /// </summary>
        public QueueImplementation()
        {
            _stringQueue = new GenericQueue<string>();
            _intQueue = new GenericQueue<int>();
        }

        /// <summary>
        /// Invoke all methods
        /// </summary>
        public void Run()
        {
            QueueImplementationUsingString();
            QueueImplementationUsingInt();
        }

        /// <summary>
        /// Method implements _queue using string
        /// </summary>
        public void QueueImplementationUsingString()
        {
            Console.WriteLine("Queue implementation using string ");
            _stringQueue.Enqueue("First");
            Console.WriteLine("Added First to Queue ");
            _stringQueue.Enqueue("Second");
            Console.WriteLine("Added Second to Queue ");
            _stringQueue.Enqueue("Third");
            Console.WriteLine("Added Third to Queue ");
            Console.WriteLine($"Removed {_stringQueue.Dequeue()}");
            Console.WriteLine($"Number of  element :{_stringQueue.Count}");
            _stringQueue.DisplayAll();
        }

        /// <summary>
        /// Method implements _queue using int
        /// </summary>
        public void QueueImplementationUsingInt()
        {
            Console.WriteLine("Queue implementation using int");
            _intQueue.Enqueue(1);
            Console.WriteLine("Added 1 to Queue ");
            _intQueue.Enqueue(2);
            Console.WriteLine("Added 2 to Queue ");
            _intQueue.Enqueue(3);
            Console.WriteLine("Added 3 to Queue ");
            Console.WriteLine($"Removed {_intQueue.Dequeue()}");
            Console.WriteLine($"Number of  element :{_intQueue.Count}");
            _stringQueue.DisplayAll();
        }
    }
}
