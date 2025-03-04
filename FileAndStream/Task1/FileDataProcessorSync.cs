using System.Diagnostics;
using System.Text;

namespace FileAndStream.Task1
{
    /// <summary>
    /// Process file data synchronously
    /// </summary>
    public class FileDataProcessorSync
    {
        /// <summary>
        /// Read file data using file stream
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <returns>Returns millisecond</returns>
        public static double ReadFileUsingFileStream(string filePath)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.SequentialScan))
            {
                byte[] buffer = new byte[4096];
                while (fs.Read(buffer, 0, buffer.Length) > 0) { }
            }

            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        /// <summary>
        /// Read file data using Bufferstream
        /// </summary>
        /// <param name="filePath">FilePath</param>
        /// <returns>Returns millisecond</returns>
        public static double ReadFileUsingBufferedStream(string filePath)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.SequentialScan))
            using (BufferedStream bs = new BufferedStream(fs, 8192))
            {
                byte[] buffer = new byte[8192];
                while (bs.Read(buffer, 0, buffer.Length) > 0) { }
            }

            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        /// <summary>
        /// Read data from file and write to another file
        /// </summary>
        /// <param name="inputFile">File to read</param>
        /// <param name="outputFile">File to write</param>
        public static void ProcessAndWriteFile(string inputFile, string outputFile)
        {
            Console.WriteLine(inputFile + " started processing and write to " + outputFile);
            using (FileStream fs = new FileStream(inputFile, FileMode.Open, FileAccess.Read, FileShare.Read, 8192, FileOptions.SequentialScan))
            using (BufferedStream bs = new BufferedStream(fs, 8192))
            using (StreamReader reader = new StreamReader(bs, Encoding.UTF8))
            {
                using (FileStream outputFs = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                using (BufferedStream outputBs = new BufferedStream(outputFs, 8192))
                using (MemoryStream memoryStream = new MemoryStream())
                using (StreamWriter writer = new StreamWriter(memoryStream, Encoding.UTF8))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string processedLine = ProcessFileData(line);
                        writer.WriteLine(processedLine);
                        if (memoryStream.Length > 8192)
                        {
                            writer.Flush();
                            memoryStream.WriteTo(outputBs);
                            memoryStream.SetLength(0);
                        }
                    }
                    writer.Flush();
                    memoryStream.WriteTo(outputBs);
                }
                Console.WriteLine(inputFile + " Completed processing and write to " + outputFile);
            }
        }

        /// <summary>
        /// Convert data to upper
        /// </summary>
        /// <param name="data">Data to process</param>
        /// <returns>Returns string result</returns>
        public static string ProcessFileData(string data)
        {
            return data.ToUpper();
        }
    }

}
