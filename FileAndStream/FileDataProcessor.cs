
using System.Diagnostics;
using System.Text;

namespace FileAndStream
{
    public  class FileDataProcessor
 {
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

        public static string ProcessFileData(string data)
        {
            return data.ToUpper();
        }
    }

}
