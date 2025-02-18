namespace CollectionAndGeneric.Task6
{
    /// <summary>
    /// Class to understand IEnumerable
    /// </summary>
    public class UnderstandIEnumerable
    {
        private List<int> _list;
        private Stack<int> _stack;
        private Queue<int> _queue;

        public UnderstandIEnumerable()
        {
            _list = new List<int> { 1, 2, 3, 4, 5 };
            _stack = new Stack<int>();
            _queue = new Queue<int>();
            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);
            _queue.Enqueue(4);
            _queue.Enqueue(5);
            _queue.Enqueue(6);
        }

        /// <summary>
        /// Invoke the flow
        /// </summary>
        public void Run()
        {
            Console.WriteLine("Understandiung IEnumerable \n");
            Console.WriteLine("______________________");
            Console.WriteLine($"Sum of List is {SumOfElements(_list)}");
            Console.WriteLine($"Sum of Stack is {SumOfElements(_stack)}");
            Console.WriteLine($"Sum of Queue is {SumOfElements(_queue)}");
            Console.WriteLine("***********************");
        }

        /// <summary>
        /// Add all the elements
        /// </summary>
        /// <param name="elements">Elements to add</param>
        /// <returns>Returns the sum of the elements</returns>
        public int SumOfElements(IEnumerable<int> elements)
        {
            return elements.Sum(i => i);
        }
    }
}
