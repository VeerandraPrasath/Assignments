using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAndStream.Task4
{
    internal class SubTask5
    {
        public static void LoadTest()
        {
            int numberOfUsers = 20;
            Console.WriteLine("Starting multiple user using single file");
            Task[] task3 = new Task[numberOfUsers];
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < numberOfUsers; i++)
            {
                string userId = $"User{i}";
                task3[i] = Task.Run(() => SubTask3.LogError("Sample error message"));
            }
            Task.WaitAll(task3);
            stopwatch.Stop();
            Console.WriteLine("Logging completed in"+ stopwatch.ElapsedMilliseconds+" ms");


            stopwatch.Reset();
            Console.WriteLine("Starting multiple user using s file");
            stopwatch.Start();
            Task[] task4 = new Task[numberOfUsers];
            for (int i = 0; i < numberOfUsers; i++)
            {
                string userId = $"User{i}";
                task4[i] = Task.Run(() => SubTask4.LogError(userId, "Sample error message"));
            }
            Task.WaitAll(task4);
            stopwatch.Stop();
            Console.WriteLine("Logging completed in" + stopwatch.ElapsedMilliseconds + " ms");
        }
    }
}
