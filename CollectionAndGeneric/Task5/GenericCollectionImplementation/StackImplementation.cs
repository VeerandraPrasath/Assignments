using CollectionAndGeneric.Task5.GenericClasses;

namespace CollectionAndGeneric.Task5.GenericCollectionImplementation
{
    /// <summary>
    /// Class implements GenericStack operations
    /// </summary>
    public class StackImplementation
    {
        private GenericStack<char> _charStack { get; set; }
        private GenericStack<int> _intStack { get; set; }

        /// <summary>
        /// Constructor initialize values
        /// </summary>
        public StackImplementation()
        {
            _charStack = new GenericStack<char>();
            _intStack = new GenericStack<int>();
        }

        /// <summary>
        /// Invoke all methods
        /// </summary>
        public void Run()
        {
            StackImplementationUsingChar();
            StackImplementationUsingInt();
        }

        /// <summary>
        /// Method implements all _stack operations using char
        /// </summary>
        public void StackImplementationUsingChar()
        {
            Console.WriteLine("Stack Implementation using char \n");
            _charStack.Push('a');
            Console.WriteLine("a is pushed to _stack ");
            _charStack.Push('e');
            Console.WriteLine("e is pushed to _stack");
            _charStack.Push('i');
            Console.WriteLine("i is pushed to _stack");
            Console.WriteLine($"{_charStack.Pop()} removed from _stack");
            Console.WriteLine($"Peek element in _stack is {_charStack.Peek()}");
        }

        /// <summary>
        /// Method implements all _stack operations using int
        /// </summary>
        public void StackImplementationUsingInt()
        {
            Console.WriteLine("Stack Implementation using int\n");
            _intStack.Push(1);
            Console.WriteLine("1 is pushed to _stack ");
            _intStack.Push(2);
            Console.WriteLine("2 is pushed to _stack");
            _intStack.Push(3);
            Console.WriteLine("3 is pushed to _stack");
            Console.WriteLine($"{_intStack.Pop()} removed from _stack");
            Console.WriteLine($"Peek element in _stack is {_intStack.Peek()}");
        }
    }
}
