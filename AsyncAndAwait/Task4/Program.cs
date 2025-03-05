using System.Text.Json;

namespace Task4
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var result = await MethodC();
            Console.WriteLine($"Result: {result}");
        }

        private static Task<int> MethodA()
        {
            Random random = new Random();
            return Task.Run(() =>
            { 
                Console.WriteLine("Starting CPU-bound operation...");
                Task.Delay(2000);
                Console.WriteLine("CPU-bound operation completed.");

                return random.Next(100); 
            });
        }

        private static async Task<string> MethodB()
        {
            int resultFromMethodA = await MethodA();
            string url = $"https://jsonplaceholder.typicode.com/posts/{resultFromMethodA}";

            HttpClient client = new HttpClient();

            Console.WriteLine("web service called");
            var response = await client.GetStringAsync(url);
            Console.WriteLine("Web service call completed");

            return response;
        }

        private static async Task<int> MethodC()
        {
            string jsonResponse = await MethodB();
            var jsonDocument = JsonDocument.Parse(jsonResponse);
            int keyValuePairCount = jsonDocument.RootElement.EnumerateObject().Count();
            Console.WriteLine($"Number of key-value pairs in the response: {keyValuePairCount}");

            return keyValuePairCount;
        }
    }
}
