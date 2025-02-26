using System.Diagnostics;

namespace FileAndStream.Task1
{
    /// <summary>
    /// Implements the task1
    /// </summary>
    public class Task1
    {
        const string Path = "DataAbout1gb.txt";
        const string InputFile = "input.txt";
        const string OutputFile = "output.txt";
        string data = "VeerandraPrasath Arun pirai sudhan sivanandhan veda sree ram diwakar";

        /// <summary>
        /// Execute task1
        /// </summary>
        public void ExecuteTask1()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            double fileStreamTime = FileDataProcessorSync.ReadFileUsingFileStream(InputFile);
            Console.WriteLine($"FileStream read time: {fileStreamTime} ms");

            double bufferedStreamTime = FileDataProcessorSync.ReadFileUsingBufferedStream(InputFile);
            Console.WriteLine($"BufferedStream read time: {bufferedStreamTime} ms");

            FileDataProcessorSync.ProcessAndWriteFile(InputFile, OutputFile);

            //Write1GBData(); 
            Console.WriteLine("File processing complete.");

        }

        /// <summary>
        /// Write one gigabyte data to file
        /// </summary>
        public void Write1GBData()
        {
            FileCommunication.WriteData(Path, data);
            while (FileCommunication.GetFileSize(Path) / 1000000000 != 1)
            {
                Console.WriteLine($"FileSize in KB {FileCommunication.GetFileSize(Path)}");
                string readData = FileCommunication.ReadFiledata(Path);
                Console.WriteLine(readData);
                if (readData.Length > 0)
                {
                    FileCommunication.WriteData(Path, readData);
                }
            }
            Console.WriteLine("File write complete ");
        }
    }

    /// <summary>
    /// Interact with file
    /// </summary>
    public static class FileCommunication
    {
        /// <summary>
        /// Read data from file
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <returns>Return read data</returns>
        public static string ReadFiledata(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return "";
            }
            return File.ReadAllText(filePath);
        }

        /// <summary>
        /// Write data to file
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <param name="data">Data to write</param>
        public static void WriteData(string filePath, string data)
        {
            File.AppendAllText(filePath, data);
        }

        /// <summary>
        /// Get file size
        /// </summary>
        /// <param name="FilePath">File path</param>
        /// <returns>Returns the file size in bytes</returns>
        public static long GetFileSize(string FilePath)
        {
            if (File.Exists(FilePath))
            {
                return new FileInfo(FilePath).Length;
            }
            return 0;
        }
    }
}
