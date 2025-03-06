namespace Task6
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var result = await MethodB();
            Console.WriteLine($"Final Result: {result}");
        }

        private static async Task<int> MethodA()
        {
            Random random = new Random();
            Console.WriteLine($"MethodA - Before await: Thread ID = {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(3000).ConfigureAwait(false);
            Console.WriteLine($"MethodA - After await: Thread ID = {Thread.CurrentThread.ManagedThreadId}");

            return random.Next(100);
        }

        private static async Task<int> MethodB()
        {
            int resultFromMethodA = await MethodA();
            int furtherProcessingResult = resultFromMethodA * 2;

            return furtherProcessingResult;
        }
    }
}
