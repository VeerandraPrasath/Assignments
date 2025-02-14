using ExpenseTracker.UserInteraction;
using ExpenseTracker.Controller;
using ExpenseTracker.FileInteractions;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using ExpenseTracker.UserData;
using ExpenseTracker.Record;
using System.Collections.Specialized;

namespace ExpenseTrackerTest
{
    public class RespositoryInteractionTest
    {
        private IRepositoryInteraction _repositoryInteraction;
        private Mock<IUserInteraction> _userInteraction;
        private Mock<IFileInteraction> _fileInteraction;
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
            _userInteraction = new Mock<IUserInteraction>();
            _fileInteraction = new Mock<IFileInteraction>();
            _repositoryInteraction = new RepositoryInteraction(_userInteraction.Object, _fileInteraction.Object, PATH);

        }

        [TestCase("Prasath")]
        [TestCase("Arun")]
        public void IsUserPresent_ShallReturnsUser_IfPresent(string userName)
        {
            var result = _repositoryInteraction.FindByUsername(userName);

            ClassicAssert.AreEqual(userName, result.Name);
        }

        [TestCase("Nikil", null)]
        [TestCase("Vasanth", null)]
        public void IsUserPresent_ShallReturnsNull_IfNotPresent(string userName, User expected)
        {
            var result = _repositoryInteraction.FindByUsername(userName);

            ClassicAssert.AreEqual(expected, result);
        }

        [TestCase("Nikil", true)]
        [TestCase("Vasanth", true)]
        public void CreateNewUser_ShallReturnsTrue_IfUserCreated(string userName, bool expected)
        {
            _userInteraction.Setup(x => x.GetValidString(It.IsAny<string>())).Returns(userName);

            _repositoryInteraction.CreateNewUser();
            
            ClassicAssert.IsTrue(_userList.Any(x => x.Name.Equals(userName)));
        }

        [Test]
        public void LoadAllData_ShallReadAllData()
        {
            _repositoryInteraction.LoadData();

            _fileInteraction.Verify(x => x.ReadFiledata(PATH));
        }

        [Test]
        public void IsDatePresent_ShallReturnDate_IfExist()
        {
            DateTime date = DateTime.Parse("31-1-2025");

            var result = _repositoryInteraction.FindByTransactionDate(date, _user1);

            ClassicAssert.AreEqual(date, result.TransactionDate);
        }

        [Test]
        public void IsDatePresent_ShallReturnNull_IfNotExist()
        {
            DateTime date = DateTime.Parse("30-1-2025");

            var result = _repositoryInteraction.FindByTransactionDate(date, _user1);

            ClassicAssert.AreEqual(null, result);
        }

        [TestCase(1, true)]
        [TestCase(0, true)]
        public void DeleteRecord_ShallReturnTrue_IfRemoved(int index, bool expected)
        {
            int count=_user1.TransactionList.Count;
            _repositoryInteraction.DeleteRecord(_recordList, index, _user1);

            ClassicAssert.AreEqual(expected, (_user1.TransactionList.Count==count-1));
        }

        [Test]
        public void AddRecord_ShallAddNewRecord()
        {
            IRecord record = new Expense(100, "Food");

            _repositoryInteraction.AddRecord(record, _date1, _user1);

            ClassicAssert.IsTrue(_date1.RecordList.Contains(record));
        }

        [Test]
        public void UpdateRecord_ShallEditRecord()
        {
            IRecord oldRecord = new Expense(100, "Food");
            IRecord newRecord = new Expense(200, "Petrol")
                ;
            _repositoryInteraction.UpdateRecord(newRecord, oldRecord, _user1);

            ClassicAssert.IsTrue(oldRecord.Amount == newRecord.Amount && oldRecord.Category == newRecord.Category);
        }

        [Test]
        public void WriteToFile_ShallWriteAllDetailsToFile()
        {
            _repositoryInteraction.WriteToFile();

            _fileInteraction.Verify(x => x.WriteData(PATH, _userList));
        }
    }

}
