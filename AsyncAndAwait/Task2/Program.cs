using System.Net.Http.Headers;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10000];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i+1;
            }

            Parallel.ForEach(arr, (i) =>
            {
                Console.WriteLine(i * i);
            });
            Console.WriteLine("Done");
        }
    }
}
