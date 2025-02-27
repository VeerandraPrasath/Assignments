using FileAndStream.Task1;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace FileStreamTest
{
    [TestFixture]
    public class FileDataProcessorTests
    {
        private const string TestInputFile = "testInput.txt";
        private const string TestOutputFile = "testOutput.txt";

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
            if (File.Exists(TestOutputFile))
            {
                File.Delete(TestOutputFile);
            }
        }

        [Test]
        public void ReadFileUsingFileStream_ReadDataFromFile_ReturnElapsedTime()
        {
            double elapsedTime = FileDataProcessorSync.ReadFileUsingFileStream(TestInputFile);

            ClassicAssert.Greater(elapsedTime, 0);
        }

        [Test]
        public void ReadFileUsingBufferedStream_ReadDataFromFile_ReturnElapsedTime()
        {
            double elapsedTime = FileDataProcessorSync.ReadFileUsingBufferedStream(TestInputFile);

            ClassicAssert.Greater(elapsedTime, 0);
        }

        [Test]
        public void ProcessAndWriteFile_CreateOutputFile()
        {
            FileDataProcessorSync.ProcessAndWriteFile(TestInputFile, TestOutputFile);

            ClassicAssert.IsTrue(File.Exists(TestOutputFile));

            var outputContent = File.ReadAllText(TestOutputFile);
            ClassicAssert.AreEqual("HELLO\r\nWORLD\r\nTHIS IS A TEST\r\n", outputContent);
        }

        [Test]
        public void ProcessFileData_ProcessDataToUpper_ReturnUpperCaseString()
        {
            string input = "test";

            string result = FileDataProcessorSync.ProcessFileData(input);

            ClassicAssert.AreEqual("TEST", result);
        }
    }
}
