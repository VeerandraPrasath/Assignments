using FileAndStream.Task2;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace FileAndStreamTest
{
    [TestFixture]
    public class FileDataProcessorAsyncTests
    {
        private const string TestInputFile = "testInput.txt";
        private const string TestOutputFileSync = "testInput_sync.txt";
        private const string TestOutputFileAsync = "testInput_async.txt";

        [SetUp]
        public void Setup()
        {
            File.WriteAllText(TestInputFile, "Hello\nWorld\nThis is a test\n");
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(TestInputFile))
            {
                File.Delete(TestInputFile);
            }
            if (File.Exists(TestOutputFileSync))
            {
                File.Delete(TestOutputFileSync);
            }
            if (File.Exists(TestOutputFileAsync))
            {
                File.Delete(TestOutputFileAsync);
            }
        }

        [Test]
        public async Task ComparePerformance_ComparePerformanceBetweenSyncAndAsync
            ()
        {
            string[] files = { TestInputFile };

            await FileDataProcessorAsync.ComparePerformance(files);

            ClassicAssert.IsTrue(File.Exists(TestOutputFileAsync));

            var outputContent = File.ReadAllText(TestOutputFileAsync);

            ClassicAssert.AreEqual("HELLO\r\nWORLD\r\nTHIS IS A TEST\r\n", outputContent);
        }

        [Test]
        public async Task ProcessFileAsync_ProcessFileAsyncCorrectly()
        {
            string inputFile = TestInputFile;
            string outputFile = TestOutputFileAsync;

            await FileDataProcessorAsync.ProcessFileAsync(inputFile, outputFile);

            ClassicAssert.IsTrue(File.Exists(outputFile));

            var outputContent = File.ReadAllText(outputFile);
            ClassicAssert.AreEqual("HELLO\r\nWORLD\r\nTHIS IS A TEST\r\n", outputContent);
        }

        [Test]
        public async Task ProcessMultipleFilesAsync_ProcessAllFilesCorrectly()
        {
            string[] files = { TestInputFile, TestInputFile };

            await FileDataProcessorAsync.ProcessMultipleFilesAsync(files);

            ClassicAssert.IsTrue(File.Exists(TestOutputFileAsync));
        }
    }
}
