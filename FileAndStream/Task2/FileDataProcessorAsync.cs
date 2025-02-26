
using System.Diagnostics;
using System.Text;
using FileAndStream.Task1;

namespace FileAndStream.Task2
{
    public class FileDataProcessorAsync
    {
        public static async Task ComparePerformance(string[] files)
        {
            Console.WriteLine("Starting Synchronous Processing...");
            var syncWatch = Stopwatch.StartNew();
            foreach (var file in files)
            {
                string outputFile = Path.Combine(Path.GetFileName(file) + "_sync.txt");
                FileDataProcessor.ProcessAndWriteFile(file, outputFile);
            }
            syncWatch.Stop();
            Console.WriteLine($"Synchronous Time: {syncWatch.ElapsedMilliseconds} ms\n");

            Console.WriteLine("Starting Asynchronous Processing...");
            var asyncWatch = Stopwatch.StartNew();
            await ProcessMultipleFilesAsync(files);
            asyncWatch.Stop();
            Console.WriteLine($"Asynchronous Time: {asyncWatch.ElapsedMilliseconds} ms");
        }

        public static async Task ProcessMultipleFilesAsync(string[] inputFiles)
        {
            var semaphore = new SemaphoreSlim(4);
            var tasks = new Task[inputFiles.Length];

            for (int i = 0; i < inputFiles.Length; i++)
            {
                string inputFile = inputFiles[i];
                string fileName = inputFile.Substring(0, inputFile.LastIndexOf('.'));
                string outputFile =Path.Combine(fileName+ "_async.txt");

                //tasks[i] = ProcessFileAsync(inputFile, outputFile);
                await semaphore.WaitAsync();
                tasks[i] = ProcessFileAsync(inputFile, outputFile).ContinueWith(_ => semaphore.Release());
            }

            await Task.WhenAll(tasks);
        }

        public static async Task ProcessFileAsync(string inputFile, string outputFile)
        {
            Console.WriteLine(inputFile + " started processing and write to " + outputFile);

            // Open input file asynchronously
            using (FileStream inputFs = new FileStream(inputFile, FileMode.Open, FileAccess.Read, FileShare.Read, 8192 * 10, useAsync: true))
            using (BufferedStream inputBs = new BufferedStream(inputFs, 8192 * 10))
            using (StreamReader reader = new StreamReader(inputBs, Encoding.UTF8))

            using (FileStream outputFs = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None, 8192 * 10, useAsync: true))
            using (BufferedStream outputBs = new BufferedStream(outputFs, 8192 * 10))
            using (MemoryStream memoryStream = new MemoryStream())
            using (StreamWriter writer = new StreamWriter(memoryStream, Encoding.UTF8))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    string processedLine = await Task.Run(() => ProcessFileData(line));
                    await writer.WriteLineAsync(processedLine);

                    if (memoryStream.Length > 8192 * 10) // Flush if buffer is full
                    {
                        writer.Flush();
                        memoryStream.WriteTo(outputBs);
                        memoryStream.SetLength(0); // Clear buffer
                    }
                }

                // Final flush to ensure all data is written
                writer.Flush();
                memoryStream.WriteTo(outputBs);
            }

            Console.WriteLine(inputFile + " completed processing and write to " + outputFile);
        }

        private static string ProcessFileData(string line)
        {
            return line.ToUpper(); // Example: Convert text to uppercase
        }
    }

}
