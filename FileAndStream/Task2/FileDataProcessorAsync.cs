using System.Diagnostics;
using System.Text;
using FileAndStream.Task1;

namespace FileAndStream.Task2
{
    /// <summary>
    /// Process file using asynchronously
    /// </summary>
    public class FileDataProcessorAsync
    {
        /// <summary>
        /// Compare performance asynchronously between files
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public static async Task ComparePerformance(string[] files)
        {
            Console.WriteLine("Starting Synchronous Processing...");
            var syncWatch = Stopwatch.StartNew();
            foreach (var file in files)
            {
                string outputFile = Path.Combine(Path.GetFileName(file) + "_sync.txt");
                FileDataProcessorSync.ProcessAndWriteFile(file, outputFile);
            }
            syncWatch.Stop();
            Console.WriteLine($"Synchronous Time: {syncWatch.ElapsedMilliseconds} ms\n");
            Console.WriteLine("Starting Asynchronous Processing...");
            var asyncWatch = Stopwatch.StartNew();
            await ProcessMultipleFilesAsync(files);
            asyncWatch.Stop();
            Console.WriteLine($"Asynchronous Time: {asyncWatch.ElapsedMilliseconds} ms");
        }

        /// <summary>
        /// Process multiple files asynchronously
        /// </summary>
        /// <param name="inputFiles">Files to process</param>
        /// <returns>Returns the Task</returns>
        public static async Task ProcessMultipleFilesAsync(string[] inputFiles)
        {
            var semaphore = new SemaphoreSlim(4);
            var tasks = new Task[inputFiles.Length];
            for (int i = 0; i < inputFiles.Length; i++)
            {
                string inputFile = inputFiles[i];
                string fileName = inputFile.Substring(0, inputFile.LastIndexOf('.'));
                string outputFile = Path.Combine(fileName + "_async.txt");
                await semaphore.WaitAsync();
                tasks[i] = ProcessFileAsync(inputFile, outputFile).ContinueWith(_ => semaphore.Release());
            }
            await Task.WhenAll(tasks);
        }

        /// <summary>
        /// Process the file asynchronously
        /// </summary>
        /// <param name="inputFile">Input file</param>
        /// <param name="outputFile">Output file</param>
        /// <returns>Returns Task</returns>
        public static async Task ProcessFileAsync(string inputFile, string outputFile)
        {
            Console.WriteLine(inputFile + " started processing and write to " + outputFile);
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
                    if (memoryStream.Length > 8192 * 10)
                    {
                        writer.Flush();
                        memoryStream.WriteTo(outputBs);
                        memoryStream.SetLength(0); // Clear buffer
                    }
                }
                writer.Flush();
                memoryStream.WriteTo(outputBs);
            }
            Console.WriteLine(inputFile + " completed processing and write to " + outputFile);
        }

        private static string ProcessFileData(string line)
        {
            return line.ToUpper();
        }
    }
}
