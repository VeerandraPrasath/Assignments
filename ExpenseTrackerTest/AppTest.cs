using ExpenseTracker.UserInteraction;
using ExpenseTracker.Controller;
using ExpenseTracker.Manager;
using Moq;
using NUnit.Framework;

namespace ExpenseTrackerTest
{
    public class AppTest
    {
        private Mock<IManageTracker> _mockManageTracker;
        private Mock<IRepositoryInteraction> _mockRepositoryInteraction;
        private Mock<IUserInteraction> _mockUserInteraction;
        private App _app;

        [SetUp]
        public void Setup()
        {
            _mockUserInteraction = new Mock<IUserInteraction>();
            _mockRepositoryInteraction = new Mock<IRepositoryInteraction>();
            _mockManageTracker = new Mock<IManageTracker>();
            _app = new App(_mockUserInteraction.Object, _mockManageTracker.Object, _mockRepositoryInteraction.Object);
        }

        [Test]
        public void Run_InvokeCreateNewUser()
        {
            _mockUserInteraction.SetupSequence(x => x.GetValidString("option")).Returns("1").Returns("3");

            _app.Run();

            _mockRepositoryInteraction.Verify(x => x.CreateNewUser(), Times.Once);
        }

        [Test]
        public void Run_InvokeCheckExisitingUser()
        {
            _mockUserInteraction.SetupSequence(x => x.GetValidString("option")).Returns("2").Returns("3");

            _app.Run();

            _mockManageTracker.Verify(x => x.CheckExisitingUser());
        }
    }
}
