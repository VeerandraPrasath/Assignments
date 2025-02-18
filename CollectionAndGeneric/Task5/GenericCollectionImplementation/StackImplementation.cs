using CollectionAndGeneric.Task5.GenericClasses;

namespace CollectionAndGeneric.Task5.GenericCollectionImplementation
{
    public class StackImplementation
    {
        public GenericStack<char> charStack { get; set; }
        public GenericStack<int>   intStack { get; set; }

        public StackImplementation()
        {
            charStack = new GenericStack<char>();
            intStack = new GenericStack<int>();
        }
        public void Run()
        {
            StackImplementationUsingChar();
            StackImplementationUsingInt();
        }

        public void StackImplementationUsingChar()
        {
            Console.WriteLine("Stack Implementation using char \n");
            charStack.Push('a');
            Console.WriteLine("a is pushed to stack ");
            charStack.Push('e');
            Console.WriteLine("e is pushed to stack");
            charStack.Push('i');
            Console.WriteLine("i is pushed to stack");
            Console.WriteLine($"{charStack.Pop()} removed from stack");
            Console.WriteLine($"Peek element in stack is {charStack.Peek()}");
        }

        public void StackImplementationUsingInt()
        {
            Console.WriteLine("Stack Implementation using int\n");
            intStack.Push(1);
            Console.WriteLine("1 is pushed to stack ");
            intStack.Push(2);
            Console.WriteLine("2 is pushed to stack");
            intStack.Push(3);
            Console.WriteLine("3 is pushed to stack");
            Console.WriteLine($"{intStack.Pop()} removed from stack");
            Console.WriteLine($"Peek element in stack is {intStack.Peek()}");
        }



    }
}
