namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 2, 8, 1, 4 };

            Array.Sort(numbers, delegate (int x, int y)
            {
                return x.CompareTo(y);
            });

            Console.WriteLine("Sorted array:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
            Console.ReadLine();
        }
    }
}