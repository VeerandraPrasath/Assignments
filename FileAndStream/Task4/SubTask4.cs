using System.Text;

namespace FileAndStream.Task4
{
    /// <summary>
    /// Implements the need of subTask4
    /// </summary>
    public class SubTask4
    {
        private static readonly object _lock = new object();

        /// <summary>
        /// Log error to separate file with thread safe
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="errorMessage">Message to log</param>
        public static void LogError(string userId, string errorMessage)
        {
            string logFilePath = $"User_{userId}_log.txt";
            string logEntry = $"{DateTime.UtcNow}: {errorMessage}{Environment.NewLine}";

            lock (_lock)
            {
                File.AppendAllText(logFilePath, logEntry, Encoding.UTF8);
            }
        }
    }
}
