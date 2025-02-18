using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAndGeneric.Task5.GenericClasses
{
    public class GenericQueue<T>
    {
       private Queue<T> _queue;
        public GenericQueue()
        {
            _queue = new Queue<T>();
        }

        public int Count { get { return _queue.Count; } }

        public void Enqueue(T item)
        {
            _queue.Enqueue(item);
        }
        public T Dequeue()
        {
            return _queue.Dequeue();
        }
        public bool Contains(T item)
        {
            return _queue.Contains(item);
        }
        public void DisplayAll()
        {
            foreach (var item in _queue)
            {
                Console.WriteLine(item);
            }
        }


    }
}
