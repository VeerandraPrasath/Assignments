
using System.Diagnostics;

namespace FileAndStream
{
    public class Task1
    {
        string data = "VeerandraPrasath Arun pirai sudhan sivanandhan veda sree ram diwakar";
        const string Path = "DataAbout1gb.txt";

        const string InputFile = "input.txt";
        const string OutputFile = "output.txt";
       
        public void Run()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            double fileStreamTime = FileDataProcessor.ReadFileUsingFileStream(InputFile);
            Console.WriteLine($"FileStream read time: {fileStreamTime} ms");

            double bufferedStreamTime = FileDataProcessor.ReadFileUsingBufferedStream(InputFile);
            Console.WriteLine($"BufferedStream read time: {bufferedStreamTime} ms");

            FileDataProcessor.ProcessAndWriteFile(InputFile, OutputFile);

            //Write1GBData(); 
            Console.WriteLine("File processing complete.");
        
        }

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



    public static class FileCommunication
    {
        public static string ReadFiledata(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return "";
            }
          return File.ReadAllText(filePath);
        }

        public static void WriteData(string filePath, string data)
        {
            
            File.AppendAllText(filePath,data);
        }
         public  static long GetFileSize(string FilePath)
        {
            if (File.Exists(FilePath))
            {
                return new FileInfo(FilePath).Length;
            }
            return 0;
        }
    }

}
