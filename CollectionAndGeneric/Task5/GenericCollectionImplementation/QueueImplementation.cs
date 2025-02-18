using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionAndGeneric.Task5.GenericClasses;

namespace CollectionAndGeneric.Task5.GenericCollectionImplementation
{
    public class QueueImplementation
    {
        public GenericQueue<string> StringQueue { get; set; }
        public GenericQueue<int>  IntQueue { get; set; }

        public QueueImplementation()
        {
            StringQueue= new GenericQueue<string>();
            IntQueue= new GenericQueue<int>();
        }


        public void Run()
        {
            QueueImplementationUsingString();
            QueueImplementationUsingInt();
        }

        public void QueueImplementationUsingString()
        {
            Console.WriteLine("Queue implementation using string ");
            StringQueue.Enqueue("First");
            Console.WriteLine("Added First to Queue ");
            StringQueue.Enqueue("Second");
            Console.WriteLine("Added Second to Queue ");
            StringQueue.Enqueue("Third");
            Console.WriteLine("Added Third to Queue ");
            Console.WriteLine($"Removed {StringQueue.Dequeue()}");
            Console.WriteLine($"Number of  element :{StringQueue.Count}");
            StringQueue.DisplayAll();
        }

        public void QueueImplementationUsingInt()
        {
            Console.WriteLine("Queue implementation using int");
            IntQueue.Enqueue(1);
            Console.WriteLine("Added 1 to Queue ");
            IntQueue.Enqueue(2);
            Console.WriteLine("Added 2 to Queue ");
            IntQueue.Enqueue(3);
            Console.WriteLine("Added 3 to Queue ");
            Console.WriteLine($"Removed {IntQueue.Dequeue()}");
            Console.WriteLine($"Number of  element :{IntQueue.Count}");
            StringQueue.DisplayAll();
        }
    }
}
