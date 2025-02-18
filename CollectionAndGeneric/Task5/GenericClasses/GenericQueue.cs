using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAndGeneric.Task5.GenericClasses
{
    /// <summary>
    /// Generic _queue implementation
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class GenericQueue<T>
    {
        private Queue<T> _queue;

        /// <summary>
        /// Constructor to initialize value
        /// </summary>
        public GenericQueue()
        {
            _queue = new Queue<T>();
        }

        /// <summary>
        /// Number of element in the _queue
        /// </summary>
        public int Count { get { return _queue.Count; } }


        /// <summary>
        /// Add element to the _queue
        /// </summary>
        /// <param name="item">item to add</param>
        public void Enqueue(T item)
        {
            _queue.Enqueue(item);
        }

        /// <summary>
        /// Remove element from the _queue
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            return _queue.Dequeue();
        }

        /// <summary>
        /// Checks element present in the _queue
        /// </summary>
        /// <param name="item">item to search</param>
        /// <returns>returns true if present else false</returns>
        public bool Contains(T item)
        {
            return _queue.Contains(item);
        }

        /// <summary>
        /// Display the elements in the _queue
        /// </summary>
        public void DisplayAll()
        {
            foreach (var item in _queue)
            {
                Console.WriteLine(item);
            }
        }
    }
}
