namespace FileAndStream.Task2
{
    /// <summary>
    /// Implements task2 functionality
    /// </summary>
    public class Task2
    {
        string[] files = { "file1.txt", "file2.txt", "file3.txt" };
        public void ExecuteTask2()
        {
            FileDataProcessorAsync.ComparePerformance(files);
            Console.WriteLine("program comes to end..");
        }
    }
}
