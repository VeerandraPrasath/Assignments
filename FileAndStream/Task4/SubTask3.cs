using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileAndStream.Task4
{
    public class SubTask3
    {
        private static readonly string _logFilePath = "log.txt";
        private static readonly object _lock = new object();

        public static void LogError(string errorMessage)
        {
            string logEntry = $"{DateTime.UtcNow}: {errorMessage}{Environment.NewLine}";

            lock (_lock)
            {
                File.AppendAllText(_logFilePath, logEntry, Encoding.UTF8);
            }
        }
    }
}
