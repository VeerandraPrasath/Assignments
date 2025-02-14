using CollectionAndGeneric.Task5.GenericClasses;

namespace CollectionAndGeneric.Task5.GenericCollectionImplementation
{
    public class GenericStackUsingChar
    {
        public GenericStackImplementation<char> charStack { get; set; }
        public string StringToReverse { get; set; }

        public GenericStackUsingChar()
        {
            charStack = new GenericStackImplementation<char>();
        }

        public void Run()
        {
            GetStringInput();
            ReverseString();
        }

        public void GetStringInput()
        {
            Console.WriteLine("Enter a string to reverse: ");
            StringToReverse = Console.ReadLine();
        }

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
