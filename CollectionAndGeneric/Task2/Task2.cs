namespace CollectionAndGeneric.Task2
{
    /// <summary>
    /// Class to implement task2
    /// </summary>
    public class Task2
    {
        /// <summary>
        /// Stack to store character
        /// </summary>
        public Stack<char> charStack { get; set; }

        /// <summary>
        /// String to reverse
        /// </summary>
        public string StringToReverse { get; set; }

        /// <summary>
        /// String in reversed order
        /// </summary>
        public string ReversedString { get ; set; }

        /// <summary>
        /// Constructor to initialize values
        /// </summary>
        public Task2()
        {
            charStack = new Stack<char>();
        }

        /// <summary>
        /// Invoke all the methods
        /// </summary>
        public void ExecuteStackOperations()
        {
            Console.WriteLine("Stack implementation");
            Console.WriteLine("______________________");
            Console.WriteLine("Enter a string to reverse: ");
            StringToReverse = Console.ReadLine();
            AddCharToStack();
            PopAndAppendChar();
            DisplayResult();
            Console.WriteLine("***********************");
        }

        private void AddCharToStack()
        {
            foreach (char c in StringToReverse)
            {
                charStack.Push(c);
            }
        }

        private void PopAndAppendChar()
        {
            Console.WriteLine("Reversed string: ");
            while (charStack.Count > 0)
            {
                ReversedString += charStack.Pop();
            }
        }

        private void DisplayResult()
        {
            Console.WriteLine("Original string : "+StringToReverse);
            Console.WriteLine("Reversed string : "+ReversedString);
            Console.WriteLine("___________________________________");
        }
    }
}
