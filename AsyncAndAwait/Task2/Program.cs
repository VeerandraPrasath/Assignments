using System.Diagnostics;
using System.Net.Http.Headers;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            int[] arr = new int[10000];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i + 1;
            }

            stopwatch.Start();
            foreach (int i in arr)
            {
                Console.WriteLine(i * i);
            }
            stopwatch.Stop();
            Console.WriteLine("Time taken by foreach loop: " + stopwatch.ElapsedMilliseconds);
            Thread.Sleep(1000);

            stopwatch.Reset();
            stopwatch.Start();
            Parallel.ForEach(arr, (i) =>
            {
                Console.WriteLine(i * i);
            });
            stopwatch.Stop();
            Console.WriteLine("Time taken by Parallel.ForEach loop: " + stopwatch.ElapsedMilliseconds);
            Console.WriteLine("Done");
        }
    }
}
