using System;
using System.IO;
using System.Text;
namespace StreamAssignment
{
    public class Task3
    {

    }

    public class Program
    {
        public static void GivenCode(string[] args)
        {
            string path = "path -to-your-file";
            string data = "This is some test data";
            // Writing to file using MemoryStream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                memoryStream.Write(buffer, 0, buffer.Length);
                // Write from MemoryStream to file
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    byte[] writeBuffer = memoryStream.ToArray();
                    fileStream.Write(writeBuffer, 0, writeBuffer.Length);
                }
            }
            // Reading from file using FileStream
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    // Simulate memory inefficiency
                    for (int i = 0; i < bytesRead; i++)
                    {
                        Console.Write((char)buffer[i]);
                    }
                   Console.WriteLine();
                }
            }
        }
        public static void OptimizedCode(string[] args)
        {
            string path = "path-to-your-file";
            string data = "This is some test data";

            // Writing to file using MemoryStream (Optimized)
            using (MemoryStream memoryStream = new MemoryStream())
            {
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                memoryStream.Write(buffer, 0, buffer.Length);

                // Write directly from MemoryStream to FileStream
                using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    memoryStream.Position = 0; // Reset position before writing
                    memoryStream.WriteTo(fileStream);
                }
            }

            // Reading from file using FileStream (Optimized)
            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    // Convert buffer to string in one go (Efficient)
                    Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                }
            }
        }
    }
}