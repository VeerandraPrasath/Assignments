namespace Task1
{
    internal class Program
    {
        static readonly HttpClient client = new HttpClient();
        const string URL = "https://opentdb.com/api.php?amount=10&category=17&difficulty=easy";

        private static void Main(string[] args)
        {
            Task<string> task = GetDataFromURL(URL);
            string data = task.Result;
            Console.WriteLine(data);
        }

        private static async Task<string> GetDataFromURL(string uri)
        {
            Console.WriteLine("Downloading data...");
            string responseBody = await client.GetStringAsync(uri);

            return responseBody;
        }
    }
}
