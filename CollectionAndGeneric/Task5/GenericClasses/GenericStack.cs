using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAndGeneric.Task5.GenericClasses
{
    /// <summary>
    /// Generic _stack implementation
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class GenericStack<T>
    {

        private Stack<T> _stack;

        /// <summary>
        /// Number of element in the _stack
        /// </summary>
        public int Count { get { return _stack.Count; } }

        /// <summary>
        /// Construtor to initialize value
        /// </summary>
        public GenericStack()
        {

            _stack = new Stack<T>();
        }

        /// <summary>
        /// Add element to the _stack
        /// </summary>
        /// <param name="item">Element to add</param>
        public void Push(T item)
        {
            _stack.Push(item);
        }

        /// <summary>
        /// Remove element from _stack
        /// </summary>
        /// <returns>returns the removed element</returns>
        public T Pop()
        {
            return _stack.Pop();
        }

        /// <summary>
        /// Top element in the _stack
        /// </summary>
        /// <returns>returns the top element</returns>
        public T Peek()
        {
            return _stack.Peek();
        }

        /// <summary>
        /// Display all the element in the _stack
        /// </summary>
        public void DisplayAll()
        {
            foreach (var item in _stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
