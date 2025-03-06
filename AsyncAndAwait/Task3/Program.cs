using System.Net.Http.Headers;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6 };
            int val1, val2 , val3 ;
            val1 = val2 = val3 = default;
            Thread thread1 = new Thread(() => { val1 = AverageOfArray(array); });
            Thread thread2 = new Thread(() => { val2 = FirstElement(array); });
            Thread thread3 = new Thread(() => { val3 = SumOfElement(array); });
            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread1.Join();
            thread2.Join();
            thread3.Join();
            Console.WriteLine("Average = " + val1 + "  FirstElement = " + val2 + "   Sum of element =" + val3);
        }

        private static int AverageOfArray(int[] array)
        {
            return (int)array.Average(x => x);
        }

        private static int FirstElement(int[] array)
        {
            return array.FirstOrDefault();
        }

        private static int SumOfElement(int[] array)
        {
            return array.Sum(x => x);
        }
    }
}
