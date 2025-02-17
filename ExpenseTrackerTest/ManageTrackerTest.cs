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
        private ManageTracker _manageTracker;
        private Mock<IUserInteraction> _mockUserInteraction;
        private Mock<IRepositoryInteraction> _mockRepositoryInteraction;
        private List<IRecord> _recordList;

        [SetUp]
        public void Setup()
        {
            _recordList = new List<IRecord>() { new Income(500, "FreeLancing"), new Expense(200, "Petrol") };
            _currentUser = new User("Prasath") { Name = "Prasath", TotalExpense = 0, TotalIncome = 0, CurrentBalance = 0, TransactionList = new List<ExpenseTracker.UserData.Transaction>() { new ExpenseTracker.UserData.Transaction(DateTime.Parse("31-1-2025")) { TransactionDate = DateTime.Parse("31-1-2025"), RecordList = _recordList } } };
            _mockUserInteraction = new Mock<IUserInteraction>();
            _mockRepositoryInteraction = new Mock<IRepositoryInteraction>();
            _manageTracker = new ManageTracker(_mockUserInteraction.Object, _mockRepositoryInteraction.Object);
            _manageTracker._currentUser = _currentUser;
        }

        [Test]
        public void CheckExisitingUser_ValidateUser()
        {
            string userName = "Prasath";
            _mockUserInteraction.SetupSequence(x => x.GetValidString(It.IsAny<string>())).Returns(userName).Returns("7");
            _mockRepositoryInteraction.Setup(x => x.FindByUsername(userName)).Returns(new User(userName));

            _manageTracker.CheckExisitingUser();

            _mockUserInteraction.Verify(x => x.DisplayMainMenu(), Times.Once);
        }

        [Test]
        public void ViewTransactionRecords_DisplayAvailableTransactions()
        {
            _currentUser.TransactionList.Clear();
            _mockUserInteraction.SetupSequence(x => x.GetValidString("Option ")).Returns("1").Returns("7");

            _manageTracker.Login();

            _mockUserInteraction.Verify(x => x.DisplayMessage(It.IsAny<string>()), Times.Exactly(6));
        }

        [Test]
        public void AddIncomeRecord_AddNewIncomeRecord()
        {
            Income incomeRecord = new Income(10000, "Salary");
            DateTime userInputDate = DateTime.Parse("31-1-2025");
            _mockUserInteraction.SetupSequence(x => x.GetValidString("Option ")).Returns("2").Returns("7");
            _mockUserInteraction.Setup(x => x.GetValidDate("to add Income record")).Returns(userInputDate);
            _mockRepositoryInteraction.Setup(x => x.FindByTransactionDate(userInputDate, _currentUser)).Returns((Transaction)null);
            _mockUserInteraction.Setup(x => x.GetIncomeDetails()).Returns(incomeRecord);

            _manageTracker.Login();

            _mockRepositoryInteraction.Verify(x => x.AddRecord(incomeRecord, It.IsAny<Transaction>(), _currentUser), Times.Once);
        }

        [Test]
        public void AddExpenseRecord_AddNewExpenseRecord()
        {
            Expense expenseRecord = new Expense(1000, "Gym");
            DateTime userInputDate = DateTime.Parse("31-1-2025");
            _mockUserInteraction.SetupSequence(x => x.GetValidString("Option ")).Returns("3").Returns("7");
            _mockUserInteraction.Setup(x => x.GetValidDate("to add Expense record")).Returns(userInputDate);
            _mockRepositoryInteraction.Setup(x => x.FindByTransactionDate(userInputDate, _currentUser)).Returns((Transaction)null);
            _mockUserInteraction.Setup(x => x.GetExpenseDetails()).Returns(expenseRecord);

            _manageTracker.Login();

            _mockRepositoryInteraction.Verify(x => x.AddRecord(expenseRecord, It.IsAny<Transaction>(), _currentUser), Times.Once);
        }

        [Test]
        public void EditRecord_DisplaysNoTransactionsOnEmptyTransaction()
        {
            _currentUser.TransactionList.Clear();
            _mockUserInteraction.SetupSequence(x => x.GetValidString("Option ")).Returns("4").Returns("7");

            _manageTracker.Login();

            _mockUserInteraction.Verify(x => x.DisplayMessage("\n   No Transactions found "), Times.Once);
        }

        [Test]
        public void EditRecord_DisplaysInvalidDateOnInvalidDate()
        {
            DateTime userInputDate = DateTime.Parse("31-1-2025");
            _mockUserInteraction.SetupSequence(x => x.GetValidString("Option ")).Returns("4").Returns("7");
            _currentUser.TransactionList.Add(new Transaction(userInputDate));
            _mockUserInteraction.Setup(x => x.GetValidDate("to edit record")).Returns(DateTime.Now);
            _mockRepositoryInteraction.Setup(ri => ri.FindByTransactionDate(DateTime.Now, _currentUser)).Returns((Transaction)null);

            _manageTracker.Login();

            _mockUserInteraction.Verify(x => x.DisplayMessage("\nInvalid transaction !\n"), Times.Once);
        }

        [Test]
        public void EditRecord_DisplaysNoTransactionsMessageOnEmptyRecords()
        {
            _mockUserInteraction.SetupSequence(x => x.GetValidString("Option ")).Returns("4").Returns("7");
            var transaction = new Transaction(DateTime.Parse("31-1-2025")) { RecordList = new List<IRecord>() };
            _currentUser.TransactionList.Add(transaction);
            _mockUserInteraction.Setup(x => x.GetValidDate(It.IsAny<string>())).Returns(DateTime.Now);
            _mockRepositoryInteraction.Setup(ri => ri.FindByTransactionDate(It.IsAny<DateTime>(), _currentUser)).Returns(transaction);

            _manageTracker.Login();

            _mockUserInteraction.Verify(x => x.DisplayMessage($"\nNo Transactions on {transaction.ToString()}\n"), Times.Once);
        }

        [Test]
        public void EditRecord_UpdatesRecordOnValidDateWithRecords()
        {
            _mockUserInteraction.SetupSequence(x => x.GetValidString("Option ")).Returns("4").Returns("7");
            var record = new Income(100000, "Salary");
            var updateRecord = new Income(10000, "Salary");
            var transaction = new Transaction(DateTime.Parse("31-1-2025")) { RecordList = new List<IRecord> { record } };
            _currentUser.TransactionList.Add(transaction);
            _mockUserInteraction.Setup(x => x.GetValidDate("to edit record")).Returns(DateTime.Now);
            _mockRepositoryInteraction.Setup(ri => ri.FindByTransactionDate(It.IsAny<DateTime>(), _currentUser)).Returns(transaction);
            _mockUserInteraction.Setup(x => x.GetValidInt("Index of Record to edit")).Returns(1);
            _mockUserInteraction.Setup(x => x.GetIncomeDetails()).Returns(updateRecord);

            _manageTracker.Login();

            _mockRepositoryInteraction.Verify(x => x.UpdateRecord(It.IsAny<IRecord>(), It.IsAny<IRecord>(), _currentUser), Times.Once);
        }

        [Test]
        public void DeleteRecord_DisplaysNoTransactionsOnEmptyTransactions()
        {
            _currentUser.TransactionList.Clear();
            _mockUserInteraction.SetupSequence(x => x.GetValidString("Option ")).Returns("5").Returns("7");

            _manageTracker.Login();

            _mockUserInteraction.Verify(x => x.DisplayMessage("\n   No Transactions found "), Times.Once);
        }

        [Test]
        public void DeleteRecord_UpdatesRecordOnValidDateWithRecords()
        {
            int recordIndex = 0;
            DateTime userInputDate = DateTime.Parse("31-1-2025");
            var record = new Income(100000, "Salary");
            var transaction = new Transaction(userInputDate) { RecordList = new List<IRecord> { record } };
            _currentUser.TransactionList.Add(transaction);
            _mockUserInteraction.SetupSequence(x => x.GetValidString("Option ")).Returns("5").Returns("7");
            _mockUserInteraction.Setup(x => x.GetValidDate("to delete Income record")).Returns(DateTime.Now);
            _mockRepositoryInteraction.Setup(ri => ri.FindByTransactionDate(It.IsAny<DateTime>(), _currentUser)).Returns(transaction);
            _mockUserInteraction.Setup(x => x.GetValidInt("Index of Record to delete")).Returns(recordIndex + 1);

            _manageTracker.Login();

            _mockRepositoryInteraction.Verify(ri => ri.DeleteRecord(transaction.RecordList, recordIndex, _currentUser), Times.Once);
        }

        [Test]
        public void DeleteRecord_DisplayNoTransactionOnInvalidDate()
        {
            _mockUserInteraction.SetupSequence(x => x.GetValidString("Option ")).Returns("5").Returns("7");
            var record = new Income(100000, "Salary");
            Transaction transaction = null;
            DateTime dateTime = DateTime.Now;
            _currentUser.TransactionList.Add(transaction);
            _mockUserInteraction.Setup(x => x.GetValidDate("to delete Income record")).Returns(dateTime);
            _mockRepositoryInteraction.Setup(ri => ri.FindByTransactionDate(dateTime, _currentUser)).Returns(transaction);

            _manageTracker.Login();

            _mockUserInteraction.Verify(x => x.DisplayMessage($"No Transactions on transaction {dateTime.ToString()}"), Times.Once);
        }

        [Test]
        public void FinancialSummary_DisplaysNoTransactionsOnEmptyTransactions()
        {
            _mockUserInteraction.SetupSequence(x => x.GetValidString("Option ")).Returns("6").Returns("7");
            _currentUser.TransactionList.Clear();

            _manageTracker.Login();

            _mockUserInteraction.Verify(x => x.DisplayMessage("\n   No Transactions found "), Times.Once);
        }

        [Test]
        public void FinancialSummary_DisplaysSummaryDetails()
        {
            _mockUserInteraction.SetupSequence(x => x.GetValidString(It.IsAny<string>())).Returns("6").Returns("1").Returns("7");

            _manageTracker.Login();

            _mockUserInteraction.Verify(x => x.DisplayMessage($"     OverAll Summary of {_currentUser.Name}"), Times.Once);
            _mockUserInteraction.Verify(x => x.DisplayMessage($"Balance       : {_currentUser.CurrentBalance}\n"), Times.Once);
            _mockUserInteraction.Verify(x => x.DisplayMessage($"Total income  : {_currentUser.TotalIncome}\n"), Times.Once);
            _mockUserInteraction.Verify(x => x.DisplayMessage($"Total expense : {_currentUser.TotalExpense}\n"), Times.Once);
        }

        [Test]
        public void FinancialSummary_DisplaysNoTransactionsOnInvalidDate()
        {

            DateTime date = DateTime.Parse("1-2-2025");
            _mockUserInteraction.SetupSequence(x => x.GetValidString(It.IsAny<string>())).Returns("6").Returns("2").Returns("7");
            _mockUserInteraction.Setup(x => x.GetValidDate("to view Summary"))
                               .Returns(date);
            _mockRepositoryInteraction.Setup(x => x.FindByTransactionDate(date, _currentUser))
                                      .Returns((Transaction)null);

            _manageTracker.Login();

            _mockUserInteraction.Verify(x => x.DisplayMessage($"No Transactions on transaction {date.ToString()}"), Times.Once);
        }
    }
}
