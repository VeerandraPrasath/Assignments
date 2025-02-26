using System.Text;

namespace FileAndStream.Task4
{
    internal class SubTask4
    {
        private static readonly object _lock = new object();

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
