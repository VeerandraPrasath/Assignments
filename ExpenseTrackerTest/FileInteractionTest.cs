
using ExpenseTracker.FileInteraction;
using ExpenseTracker.UserData;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace ExpenseTrackerTest
{
    public class FileInteractionTest
    {
      
        private IFileInteraction _fileInteraction;
        private const string PATH = "UserList.json";

        [SetUp]
        public void SetUp()
        {
            _fileInteraction = new FileInteraction();
        }

        [Test]
        public void ReadAllData_ShallReturnsUserList()
        {
           var result= _fileInteraction.ReadAlldata(PATH);

            ClassicAssert.IsTrue(result is List<User>);
        }

        [Test]
        public void WriteDate_ShallWriteUserDetailsToFile()
        {
            var userList = new List<User>() { new User("Prasath"), new User("Arun") };
            var expectedJson= JsonConvert.SerializeObject(userList, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects
            });

            _fileInteraction.WriteData(PATH,userList);
             var actualJson=File.ReadAllText(PATH);

            ClassicAssert.AreEqual(expectedJson, actualJson);
        }
    }
    
}
