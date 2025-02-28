namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var oddNumbers = numbers.Where(n => n % 2 != 0);
            var squaredOddNumbers = oddNumbers.Select(n => n * n);
            Console.WriteLine("Squared odd numbers:");
            foreach (var number in squaredOddNumbers)
            {
                Console.WriteLine(number);
            }
            Console.ReadLine();
        }
    }
}