using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAndStream.Task4
{
    internal class SubTask2
    {

        private static readonly string _logFilePath = "log.txt";

        public static void LogError(string errorMessage)
        {
            string logEntry = $"{DateTime.UtcNow}: {errorMessage}{Environment.NewLine}";

            File.AppendAllText(_logFilePath, logEntry, Encoding.UTF8);
        }
    }
}

