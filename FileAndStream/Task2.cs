
namespace FileAndStream
{
    internal class Task2
    {
        string[] files = { "file1.txt", "file2.txt", "file3.txt" };
        public void run()
        {
            FileDataProcessorAsync.ComparePerformance(files);
            Console.WriteLine("program comes to end..");
        }
    }
}
