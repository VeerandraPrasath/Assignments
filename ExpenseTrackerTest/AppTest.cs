using ExpenseTracker.ConsoleInteraction;
using ExpenseTracker.Controller;
using ExpenseTracker.Manager;
using Moq;
using NUnit.Framework;

namespace ExpenseTrackerTest
{
    public class AppTest
    {
        private Mock<IManageTracker> _manageTracker;
        private Mock<IRepositoryInteraction> _repositoryInteraction;
        private Mock<IUserInteraction> _userInteraction;
        private App _app;

        [SetUp]
        public void Setup()
        {
            _userInteraction = new Mock<IUserInteraction>();
            _repositoryInteraction = new Mock<IRepositoryInteraction>();
            _manageTracker = new Mock<IManageTracker>();
            _app = new App(_userInteraction.Object, _manageTracker.Object, _repositoryInteraction.Object);
        }

        [Test]
        public void Run_InvokeCreateNewUser_WhenInput1()
        {
            _userInteraction.SetupSequence(x => x.GetStringInput(It.IsAny<string>())).Returns("1").Returns("3");

            _app.Run();

            _repositoryInteraction.Verify(x => x.CreateNewUser());
        }

        [Test]
        public void Run_InvokeCheckExisitingUser_WhenInput2()
        {
            _userInteraction.SetupSequence(x => x.GetStringInput(It.IsAny<string>())).Returns("2").Returns("3");

            _app.Run();

            _manageTracker.Verify(x => x.CheckExisitingUser());
        }
    }
}
