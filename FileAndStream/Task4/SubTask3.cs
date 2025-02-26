using System.Text;

namespace FileAndStream.Task4
{
    /// <summary>
    /// Implements the need of subTask3
    /// </summary>
    public class SubTask3
    {
        private static readonly string _logFilePath = "log.txt";
        private static readonly object _lock = new object();

        /// <summary>
        /// Log error to file with thread safe
        /// </summary>
        /// <param name="errorMessage">Message to log</param>
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
