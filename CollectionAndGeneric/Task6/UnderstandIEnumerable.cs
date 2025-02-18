namespace CollectionAndGeneric.Task6
{
    public class UnderstandIEnumerable
    {
        public List<int> list { get; set; }
        public Stack<int> stack { get; set; }
        public Queue<int> queue { get; set; }

        public UnderstandIEnumerable()
        {
            list = new List<int>{ 1,2,3,4,5};
            stack = new Stack<int>();
            queue = new Queue<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);
        }

       public void Run()
        {
            Console.WriteLine("Understandiung IEnumerable \n");
            Console.WriteLine($"Sum of List is {SumOfElements(list)}");
            Console.WriteLine($"Sum of Stack is {SumOfElements(stack)}");
            Console.WriteLine($"Sum of Queue is {SumOfElements(queue)}");
        }

        public int SumOfElements(IEnumerable<int> elements)
        {
            return elements.Sum(i => i);
        }
    }
}
