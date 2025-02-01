
using NUnit.Framework.Legacy;
using NUnit.Framework;
using ExpenseTracker.ConsoleInteraction;
using Moq;

namespace ExpenseTrackerTest
{
    public class UserInteractionTest
    {
        private IUserInteraction _userInteraction;
        StringWriter consoleRead;

        [SetUp]
        public void Setup()
        {
            _userInteraction = new UserInteraction();
            consoleRead = new StringWriter();
            Console.SetOut(consoleRead);
        }

        [TestCase("ABCD")]
        [TestCase("Prasath")]
        [Test]
        public void GetInputStringShallReturnString_BasedOnUserInput(string input)
        {
            StringReader inputReader = new StringReader(input);
            Console.SetIn(inputReader);

            var result = _userInteraction.GetStringInput(It.IsAny<string>());

            ClassicAssert.AreEqual(input, result);
            inputReader.Dispose();
        }

        [TestCase("1")]
        [TestCase("91283")]
        [TestCase("3")]
        [TestCase("2323")]
        [Test]
        public void GetInputIntShallReturnInt_BasedOnUserInput(string input)
        {
            StringReader inputReader = new StringReader(input);
            Console.SetIn(inputReader);

            var result = _userInteraction.GetIntInput(It.IsAny<string>());

            ClassicAssert.AreEqual(input, result.ToString());
            inputReader.Dispose();
        }

        [TestCase("01-01-2025 00:00:00")]
        [TestCase("02-12-2030 00:00:00")]
        [Test]
        public void GetDateInputyShallReturnDate_BasedOnUserInput(string input)
        {
            StringReader inputReader = new StringReader(input);
            Console.SetIn(inputReader);

            var result = _userInteraction.GetDateInput(It.IsAny<string>());

            ClassicAssert.AreEqual(input, result.ToString());
            inputReader.Dispose();
        }

        [TestCase("HI")]
        [TestCase("Aruneshwar")]
        public void DisplayMessage_ShallPrintMessage(string input)
        {
           
            _userInteraction.DisplayMessage(input);
            string consoleString= consoleRead.ToString();

            ClassicAssert.AreEqual($"{ input}\r\n", consoleString);

        }
    }
}
