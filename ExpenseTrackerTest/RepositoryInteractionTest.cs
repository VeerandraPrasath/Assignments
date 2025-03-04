using ExpenseTracker.UserInteraction;
using ExpenseTracker.Controller;
using ExpenseTracker.FileInteractions;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using ExpenseTracker.UserData;
using ExpenseTracker.Record;

namespace ExpenseTrackerTest
{
    public class RespositoryInteractionTest
    {
        private IRepositoryInteraction _repositoryInteraction;
        private Mock<IUserInteraction> _mockUserInteraction;
        private Mock<IFileInteraction> _mockFileInteraction;
        private const string PATH = "UserList.json";
        private List<User> _userList;
        private User _user1;
        private User _user2;
        private Transaction _date1;
        private List<IRecord> _recordList;

        [SetUp]
        public void Setup()
        {
            _recordList = new List<IRecord>() { new Income(500, "FreeLancing"), new Expense(200, "Petrol") };
            _date1 = new Transaction(DateTime.Parse("31-1-2025")) { TransactionDate = DateTime.Parse("31-1-2025"), RecordList = _recordList };
            _user1 = new User("Prasath") { Name = "Prasath", TotalExpense = 0, TotalIncome = 0, CurrentBalance = 0, TransactionList = new List<Transaction>() { _date1 } };
            _user2 = new User("Arun") { Name = "Arun", TotalExpense = 0, TotalIncome = 0, CurrentBalance = 0, TransactionList = new List<Transaction>() { new Transaction(DateTime.Parse("30-1-2025")) { TransactionDate = DateTime.Parse("30-1-2025"), RecordList = new List<IRecord>() { new Income(25000, "Salary"), new Expense(300, "Movie") } } } };
            _userList = new List<User>() { _user1, _user2 };
            _mockUserInteraction = new Mock<IUserInteraction>();
            _mockFileInteraction = new Mock<IFileInteraction>();
            _repositoryInteraction = new RepositoryInteraction(_mockUserInteraction.Object, _mockFileInteraction.Object, PATH);
        }

        [TestCase("Prasath")]
        [TestCase("Arun")]
        public void FindByUsername_SearchUser_ReturnsUserIfExist(string userName)
        {
            _mockUserInteraction.Setup(x => x.GetValidString("New Username")).Returns(userName);
            _repositoryInteraction.CreateNewUser();

            var result = _repositoryInteraction.FindByUsername(userName);

            ClassicAssert.AreEqual(userName, result.Name);
        }

        [TestCase("Nikil", null)]
        [TestCase("Vasanth", null)]
        public void FindByUsername_SearchUser_ReturnsNullIfNotExist(string userName, User expected)
        {
            var result = _repositoryInteraction.FindByUsername(userName);

            ClassicAssert.AreEqual(expected, result);
        }

        [TestCase("Nikil", true)]
        [TestCase("Vasanth", true)]
        public void CreateNewUser_CreatesNewUserAccount_ReturnsTrueIfCreated(string userName, bool expected)
        {
            _mockUserInteraction.Setup(x => x.GetValidString("New Username")).Returns(userName);

            _repositoryInteraction.CreateNewUser();

            _mockUserInteraction.Verify(x => x.DisplayMessage("\nAccount created successfully ! please Login !\n"), Times.Once);
        }

        [Test]
        public void LoadAllData_ReadAllDataFromFile()
        {
            _repositoryInteraction.LoadData();

            _mockFileInteraction.Verify(x => x.ReadFiledata(PATH), Times.Once);
        }

        [Test]
        public void FindByTransactionDate_SearchTransactionDate_ReturnDateIfExist()
        {
            DateTime date = DateTime.Parse("31-1-2025");

            var result = _repositoryInteraction.FindByTransactionDate(date, _user1);

            ClassicAssert.AreEqual(date, result.TransactionDate);
        }

        [Test]
        public void FindByTransactionDate_SearchTransactionDate_ReturnsNullIfNotExist()
        {
            DateTime date = DateTime.Parse("30-1-2025");

            var result = _repositoryInteraction.FindByTransactionDate(date, _user1);

            ClassicAssert.AreEqual(null, result);
        }

        [TestCase(1, true)]
        [TestCase(0, true)]
        public void DeleteRecord_DeleteRecordFromTransaction_ReturnsTrueIfRemoved(int index, bool expected)
        {
            int count = _recordList.Count;
            _repositoryInteraction.DeleteRecord(_recordList, index, _user1);

            ClassicAssert.AreEqual(count - 1, _recordList.Count);
        }

        [Test]
        public void AddRecord_AddNewRecord()
        {
            IRecord record = new Expense(100, "Food");

            _repositoryInteraction.AddRecord(record, _date1, _user1);

            ClassicAssert.IsTrue(_date1.RecordList.Contains(record));
        }

        [Test]
        public void UpdateRecord_EditAlreadyExistingRecord()
        {
            IRecord oldRecord = new Expense(100, "Food");
            IRecord newRecord = new Expense(200, "Petrol")
                ;
            _repositoryInteraction.UpdateRecord(newRecord, oldRecord, _user1);

            ClassicAssert.IsTrue(oldRecord.Amount == newRecord.Amount && oldRecord.Category == newRecord.Category);
        }

        [Test]
        public void WriteToFile_WriteAllTransactionDetailsToFile()
        {
            _repositoryInteraction.WriteToFile();

            _mockFileInteraction.Verify(x => x.WriteData(PATH, It.IsAny<List<User>>()));
        }
    }

}
