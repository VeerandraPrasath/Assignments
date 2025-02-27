using FileAndStream.Task4;
using NUnit.Framework.Legacy;
using NUnit.Framework;

namespace FileAndStreamTest
{
    [TestFixture]
    public class SubTask3Tests
    {
        private const string TestLogFilePath = "log.txt";

        [SetUp]
        public void Setup()
        {
            if (File.Exists(TestLogFilePath))
            {
                File.Delete(TestLogFilePath);
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(TestLogFilePath))
            {
                File.Delete(TestLogFilePath);
            }
        }

        [Test]
        public void LogError_WriteErrorMessageToLogFile()
        {
            string errorMessage = "An error occurred";

            SubTask3.LogError(errorMessage);

            ClassicAssert.IsTrue(File.Exists(TestLogFilePath), "Log file was not created.");

            string[] logEntries = File.ReadAllLines(TestLogFilePath);
            ClassicAssert.IsNotEmpty(logEntries);
        }
    }
}
