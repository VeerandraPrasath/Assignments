using System.Text;

namespace FileAndStream.Task4
{
    /// <summary>
    /// Class implement the need of subTask2
    /// </summary>
    public class SubTask2
    {
        private static readonly string _logFilePath = "log.txt";

        /// <summary>
        /// Log error to file
        /// </summary>
        /// <param name="errorMessage">Message to log</param>
        public static void LogError(string errorMessage)
        {
            string logEntry = $"{DateTime.UtcNow}: {errorMessage}{Environment.NewLine}";

            File.AppendAllText(_logFilePath, logEntry, Encoding.UTF8);
        }
    }
}

