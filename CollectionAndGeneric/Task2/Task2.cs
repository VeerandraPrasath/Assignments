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
        /// Constructor to initialize values
        /// </summary>
        public Task2()
        {
            charStack = new Stack<char>();
        }

        /// <summary>
        /// Invoke all the methods
        /// </summary>
        public void Run()
        {
            GetStringInput();
            ReverseString();
        }

        /// <summary>
        /// Get string from the user
        /// </summary>
        public void GetStringInput()
        {
            Console.WriteLine("Enter a string to reverse: ");
            StringToReverse = Console.ReadLine();
        }

        /// <summary>
        /// Reverse the string
        /// </summary>
        public void ReverseString()
        {
            string reversedString = "";
            foreach (char c in StringToReverse)
            {
                charStack.Push(c);
            }
            Console.WriteLine("Reversed string: ");
            while (charStack.Count > 0)
            {
                reversedString += charStack.Pop();
            }
            Console.WriteLine(reversedString);
        }
    }
}
