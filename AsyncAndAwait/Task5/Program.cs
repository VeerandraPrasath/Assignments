namespace Task5
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ModifiedCode modifiedCode = new ModifiedCode();
            Thread thread1 = new Thread(modifiedCode.Method1);
            Thread thread2 = new Thread(modifiedCode.Method2);
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            Console.ReadKey();
        }
    }
}