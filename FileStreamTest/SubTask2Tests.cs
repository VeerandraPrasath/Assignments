using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileAndStream.Task4;
using NUnit.Framework.Legacy;
using NUnit.Framework;

namespace FileAndStreamTest
{
    [TestFixture]
    public class SubTask2Tests
    {
        private const string TestLogFilePath = "log.txt";

        [SetUp]
        public void Setup()
        {
            if (!File.Exists(TestLogFilePath))
            {
                File.Create(TestLogFilePath);
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
        public void LogError_ShouldWriteErrorMessageToLogFile()
        {
            string errorMessage = "An error occurred";
            string expectedLogEntry = $"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}: {errorMessage}{Environment.NewLine}";

            SubTask2.LogError(errorMessage);

            ClassicAssert.IsTrue(File.Exists(TestLogFilePath), "Log file was not created.");

            string[] logEntries = File.ReadAllLines(TestLogFilePath);
            ClassicAssert.IsNotEmpty(logEntries, "Log file is empty.");
        }
    }
}
