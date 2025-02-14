using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAndGeneric.Task5.GenericClasses
{
    public class GenericStackImplementation<T>
    {
        public GenericStackImplementation() { }

        private Stack<T> _stack = new Stack<T>();

        public Stack<T> Stack { get { return _stack; } }

        public int Count { get { return _stack.Count; } }

        public void Push(T item)
        {
            _stack.Push(item);
        }

        public T Pop()
        {
            return _stack.Pop();
        }

        public T Peek()
        {
            return _stack.Peek();
        }

        public void DisplayAll()
        {
            foreach (var item in _stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
