using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAndGeneric.Task2
{
    public class Task2
    {
        public Stack<char> charStack { get; set; }
        public string StringToReverse { get; set; }

        public Task2()
        {
            charStack = new Stack<char>();
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
