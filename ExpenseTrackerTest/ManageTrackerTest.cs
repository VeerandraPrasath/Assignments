using ExpenseTracker.UserInteraction;
using ExpenseTracker.Controller;
using ExpenseTracker.Manager;
using Moq;
using NUnit.Framework;
using ExpenseTracker.UserData;
using ExpenseTracker.Record;

namespace ExpenseTrackerTest
{
    public class ManageTrackerTest
    {
        private User _currentUser;
        private IManageTracker _manageTracker;
        private Mock<IUserInteraction> _userInteraction;
        private Mock<IRepositoryInteraction> _repositoryInteraction;
        private List<IRecord> _recordList;

        [SetUp]
        public void Setup()
        {
            _recordList = new List<IRecord>() { new Income(500, "FreeLancing"), new Expense(200, "Petrol") };
            _currentUser = new User("Prasath") { Name = "Prasath", TotalExpense = 0, TotalIncome = 0, CurrentBalance = 0,TransactionList = new List<ExpenseTracker.UserData.Transaction>() { new ExpenseTracker.UserData.Transaction(DateTime.Parse("31-1-2025")) { TransactionDate = DateTime.Parse("31-1-2025"), RecordList = _recordList } } };
            _userInteraction = new Mock<IUserInteraction>();
            _repositoryInteraction = new Mock<IRepositoryInteraction>();
            _manageTracker = new ManageTracker(_userInteraction.Object, _repositoryInteraction.Object);
        }

        [Test]
        public void CheckExisitingUser_ShallValidateUser()
        {
            _userInteraction.SetupSequence(x => x.GetValidString(It.IsAny<string>())).Returns("Prasath").Returns("7");
            _repositoryInteraction.Setup(x => x.FindByUsername(It.IsAny<string>())).Returns(new User("Prasath"));

            _manageTracker.CheckExisitingUser();

            _userInteraction.Verify(x => x.DisplayMainMenu());

        }

        [Test]
        public void Login_ShallDisplayRecords_WhenInputIs1()
        {
            _currentUser.TransactionList.Clear();
            _userInteraction.SetupSequence(x => x.GetValidString(It.IsAny<string>())).Returns("1").Returns("7");

            _manageTracker.Login();

            _userInteraction.Verify(x => x.DisplayMessage(It.IsAny<string>()));
        }

        [Test]
        public void AddIncomeRecord_ShallAddNewRecord_WhenInputIs2()
        {
            _userInteraction.SetupSequence(x => x.GetValidString(It.IsAny<string>())).Returns("2").Returns("7");
            _userInteraction.Setup(x => x.GetValidDate(It.IsAny<string>())).Returns(DateTime.Parse("31-1-2025"));
            _repositoryInteraction.Setup(x => x.FindByTransactionDate(It.IsAny<DateTime>(), It.IsAny<User>())).Returns((Transaction)null);
            _userInteraction.Setup(x => x.GetIncomeDetails()).Returns(new Income(10000, "Salary"));

            _manageTracker.Login();

            _repositoryInteraction.Verify(x => x.AddRecord(It.IsAny<IRecord>(), It.IsAny<Transaction>(), It.IsAny<User>()));
        }

        [Test]
        public void AddExpenseRecord_ShallAddNewRecord_WhenInputIs3()
        {
            _userInteraction.SetupSequence(x => x.GetValidString(It.IsAny<string>())).Returns("3").Returns("7");
            _userInteraction.Setup(x => x.GetValidDate(It.IsAny<string>())).Returns(DateTime.Parse("31-1-2025"));
            _repositoryInteraction.Setup(x => x.FindByTransactionDate(It.IsAny<DateTime>(), It.IsAny<User>())).Returns((Transaction)null);
            _userInteraction.Setup(x => x.GetExpenseDetails()).Returns(new Expense(1000, "Gym"));

            _manageTracker.Login();

            _repositoryInteraction.Verify(x => x.AddRecord(It.IsAny<IRecord>(), It.IsAny<Transaction>(), It.IsAny<User>()));
        }

        [Test]
        public void EditRecord_ShallDisplaysNoTransactionsMessage_IfNoTransactions_()
        {
            _currentUser.TransactionList.Clear();
            _userInteraction.SetupSequence(x => x.GetValidString(It.IsAny<string>())).Returns("4").Returns("7");

            _manageTracker.Login();

            _userInteraction.Verify(x => x.DisplayMessage("___________________________________"));
            _userInteraction.Verify(x => x.DisplayMessage("\n   No Transactions found "));
            _userInteraction.Verify(x => x.DisplayMessage("___________________________________"));
        }

        [Test]
        public void EditRecord_ShallDisplaysInvalidDateMessage_IfInvalidDate()
        {
            _userInteraction.SetupSequence(x => x.GetValidString(It.IsAny<string>())).Returns("4").Returns("7");
            _currentUser.TransactionList.Add(new Transaction(DateTime.Parse("31-1-2025")));
            _userInteraction.Setup(x => x.GetValidDate(It.IsAny<string>())).Returns(DateTime.Now);
            _repositoryInteraction.Setup(ri => ri.FindByTransactionDate(It.IsAny<DateTime>(), _currentUser)).Returns((Transaction)null);

            _manageTracker.Login();

            _userInteraction.Verify(x => x.DisplayMessage("\nInvalid Date !\n"), Times.Once);
            _userInteraction.Verify(x => x.DisplayMessage(It.IsAny<string>()));
        }

        [Test]
        public void EditRecord_ShallDisplaysNoTransactionsMessage_IfValidDateNoRecords()
        {
            _userInteraction.SetupSequence(x => x.GetValidString(It.IsAny<string>())).Returns("4").Returns("7");
            var date = new Transaction(DateTime.Parse("31-1-2025")) { RecordList = new List<IRecord>() };
            _currentUser.TransactionList.Add(date);
            _userInteraction.Setup(x => x.GetValidDate(It.IsAny<string>())).Returns(DateTime.Now);
            _repositoryInteraction.Setup(ri => ri.FindByTransactionDate(It.IsAny<DateTime>(), _currentUser)).Returns(date);

            _manageTracker.Login();

            _userInteraction.Verify(x => x.DisplayMessage($"\nNo Transactions on {date.ToString()}\n"), Times.Once);
            _userInteraction.Verify(x => x.DisplayMessage(It.IsAny<string>()));
        }

        [Test]
        public void EditRecord_ShallUpdatesRecord_IfValidDateWithRecords()
        {
            _userInteraction.SetupSequence(x => x.GetValidString(It.IsAny<string>())).Returns("4").Returns("7");
            var record = new Income(100000, "Salary");
            var date = new Transaction(DateTime.Parse("31-1-2025")) { RecordList = new List<IRecord> { record } };
            _currentUser.TransactionList.Add(date);
            _userInteraction.Setup(x => x.GetValidDate(It.IsAny<string>())).Returns(DateTime.Now);
            _repositoryInteraction.Setup(ri => ri.FindByTransactionDate(It.IsAny<DateTime>(), _currentUser)).Returns(date);
            _userInteraction.Setup(x => x.GetValidInt(It.IsAny<string>())).Returns(1);
            _userInteraction.Setup(x => x.GetIncomeDetails()).Returns(new Income(10000, "Salary"));

            _manageTracker.Login();

            _repositoryInteraction.Verify(x => x.UpdateRecord(It.IsAny<IRecord>(), It.IsAny<IRecord>(), _currentUser));
        }

        [Test]
        public void DeleteRecord_ShallDisplaysNoTransactionsMessage_IfNoTransactions()
        {
            _currentUser.TransactionList.Clear();
            _userInteraction.SetupSequence(x => x.GetValidString(It.IsAny<string>())).Returns("5").Returns("7");

            _manageTracker.Login();


            _userInteraction.Verify(x => x.DisplayMessage("___________________________________"));
            _userInteraction.Verify(x => x.DisplayMessage("\n   No Transactions found "));
            _userInteraction.Verify(x => x.DisplayMessage("___________________________________"));
        }

        [Test]
        public void DeleteRecord_ShallUpdatesRecord_IfValidDateWithRecords()
        {
            _userInteraction.SetupSequence(x => x.GetValidString(It.IsAny<string>())).Returns("5").Returns("7");
            var record = new Income(100000, "Salary");
            var date = new Transaction(DateTime.Parse("31-1-2025")) { RecordList = new List<IRecord> { record } };
            _currentUser.TransactionList.Add(date);
            _userInteraction.Setup(x => x.GetValidDate(It.IsAny<string>())).Returns(DateTime.Now);
            _repositoryInteraction.Setup(ri => ri.FindByTransactionDate(It.IsAny<DateTime>(), _currentUser)).Returns(date);
            _userInteraction.Setup(x => x.GetValidInt(It.IsAny<string>())).Returns(1);

            _manageTracker.Login();

            _repositoryInteraction.Verify(ri => ri.DeleteRecord(It.IsAny<List<IRecord>>(), It.IsAny<int>(), _currentUser));
        }

        [Test]
        public void DeleteRecord_ShallDisplayNoTransactionOnDateMessage_IfInvalidDate()
        {
            _userInteraction.SetupSequence(x => x.GetValidString(It.IsAny<string>())).Returns("5").Returns("7");
            var record = new Income(100000, "Salary");
            Transaction date = null;
            DateTime dateTime = DateTime.Now;
            _currentUser.TransactionList.Add(date);
            _userInteraction.Setup(x => x.GetValidDate(It.IsAny<string>())).Returns(dateTime);
            _repositoryInteraction.Setup(ri => ri.FindByTransactionDate(It.IsAny<DateTime>(), _currentUser)).Returns(date);

            _manageTracker.Login();

            _userInteraction.Verify(x => x.DisplayMessage($"No Transactions on date {dateTime.ToString()}"));
        }

        [Test]
        public void FinancialSummary_ShallDisplaysNoTransactionsMessage_IfNoTransactions()
        {
            _userInteraction.SetupSequence(x => x.GetValidString(It.IsAny<string>())).Returns("6").Returns("7");
            _currentUser.TransactionList.Clear();

            _manageTracker.Login();

            _userInteraction.Verify(x => x.DisplayMessage("___________________________________"));
            _userInteraction.Verify(x => x.DisplayMessage("\n   No Transactions found "), Times.Once);
            _userInteraction.Verify(x => x.DisplayMessage("___________________________________"));
        }

        [Test]
        public void FinancialSummary_ShallDisplaysSummary_IfPresent()
        {
            _userInteraction.SetupSequence(x => x.GetValidString(It.IsAny<string>())).Returns("6").Returns("1").Returns("7");

            _manageTracker.Login();

            _userInteraction.Verify(x => x.DisplayMessage("--------------------------------------------"));
            _userInteraction.Verify(x => x.DisplayMessage($"     OverAll Summary of {_currentUser.Name}"), Times.Once);
            _userInteraction.Verify(x => x.DisplayMessage($"Balance       : {_currentUser.CurrentBalance}\n"), Times.Once);
            _userInteraction.Verify(x => x.DisplayMessage($"Total income  : {_currentUser.TotalIncome}\n"), Times.Once);
            _userInteraction.Verify(x => x.DisplayMessage($"Total expense : {_currentUser.TotalExpense}\n"), Times.Once);
        }

        [Test]
        public void FinancialSummary_ShallDisplaysNoTransactionsMessage_IfNotPreseentOnSpecificDate()
        {

            DateTime date = DateTime.Parse("1-2-2025");
            _userInteraction.SetupSequence(x => x.GetValidString(It.IsAny<string>())).Returns("6").Returns("2").Returns("7");
            _userInteraction.Setup(x => x.GetValidDate(It.IsAny<string>()))
                               .Returns(date);
            _repositoryInteraction.Setup(x => x.FindByTransactionDate(It.IsAny<DateTime>(), It.IsAny<User>()))
                                      .Returns((Transaction)null);

            _manageTracker.Login();

            _userInteraction.Verify(x => x.DisplayMessage($"No Transactions on date {date.ToString()}"));
        }
    }
}
