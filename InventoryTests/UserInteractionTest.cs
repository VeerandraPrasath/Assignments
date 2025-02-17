using InventoryManager.ConsoleInteraction;
using InventoryManager.Controller;
using InventoryManager.Model;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace InventoryManagerTests
{
    [TestFixture]
    public class UserInteractionTest
    {
        private List<Product> _productList;
        private Product _product1;
        private Mock<IProductRepository> _mockProductRepository;
        private IUserInteraction _userInteraction;
        StringWriter stringWriter;

        [SetUp]
        public void SetUp()
        {
            _product1 = new Product(1, "Prasath", 10, 20);
            _productList = new List<Product>() { _product1, new Product(2, "Arun", 20, 30) };
            _mockProductRepository = new Mock<IProductRepository>();
            _userInteraction = new UserInteraction(_mockProductRepository.Object);
            stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
        }

        [Test]
        public void DisplayAllProducts_PrintAllProductInList()
        {
            string products = "";
            for (int i = 0; i < _productList.Count; i++)
            {
                products += $"{i + 1} . {_productList[i].ToString()}\r\n";

            }
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            _userInteraction.DisplayAllProducts(_productList);
            string output = stringWriter.ToString();

            ClassicAssert.AreEqual(products, output);
        }

        [Test]
        public void DisplayAllProducts_PrintMessageOnEmptyProductList()
        {
            _productList.Clear();
            string message = "**** No products available ****\r\n";
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            _userInteraction.DisplayAllProducts(_productList);
            string output = stringWriter.ToString();

            ClassicAssert.AreEqual(message, output);
        }

        [Test]
        public void DisplayEditOptions_PrintAllEditOptions()
        {
            string message = "\n[1] Name \n[2] Id\n[3] Quantity \n[4] Price\n\r\n";

            _userInteraction.DisplayEditMenuOptions();
            string output = stringWriter.ToString();

            ClassicAssert.AreEqual(message, output);
        }

        [Test]
        public void DisplayOptions_PrintAllAvailableOptions()
        {
            string message = "\n[1] View \n[2] Add \n[3] Edit \n[4] Delete \n[5] Search \n[6] Clear \n[7] Exit\n\r\n";
            _userInteraction.DisplayMenuOptions();
            string output = stringWriter.ToString();

            ClassicAssert.AreEqual(message, output);
        }

        [TestCase(3, "Vasanth", 10, 15)]
        [TestCase(4, "Nikil", 12, 10)]
        public void GetProductDetail_GetAllProductDetailsFromUser_ReturnsProduct(int id, string name, int quantity, int price)
        {
            string input = $"{id}\n{name}\n{quantity}\n{price}";
            StringReader inputReader = new StringReader(input);
            Console.SetIn(inputReader);
            _mockProductRepository.Setup(mock => mock.IsNameUnique(It.IsAny<string>()))
                  .Returns((string name) => !_productList.Any(p => p.Name.Equals(name)));
            _mockProductRepository.Setup(mock => mock.IsIdUnique(It.IsAny<int>()))
                      .Returns((int id) => !_productList.Any(p => p.Id == id));


            Product result = _userInteraction.GetProductDetails();

            ClassicAssert.IsTrue(result.Id == id && result.Name.Equals(name) && result.Quantity == quantity && result.Price == price);
        }

        [TestCase("ABCD")]
        [TestCase("Prasath")]
        public void GetInputString_GetValidStringFromUser_ReturnsString(string inputString)
        {
            StringReader inputReader = new StringReader(inputString);
            Console.SetIn(inputReader);

            var result = _userInteraction.GetInputString("Name");

            ClassicAssert.AreEqual(inputString, result);
        }

        [TestCase("1")]
        [TestCase("91283")]
        [TestCase("0003")]
        [TestCase("2323")]
        public void GetInputInt_GetValidIntFromUser_ReturnsInt(string inputInt)
        {
            StringReader inputReader = new StringReader(inputInt);
            Console.SetIn(inputReader);

            var result = _userInteraction.GetInputString("Id");

            ClassicAssert.AreEqual(inputInt, result);
        }

        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void GetUniqueId_GetUniqueIdFromUser_ReturnId(int productId)
        {
            string consoleinput = $"{productId}";
            StringReader inputReader = new StringReader(consoleinput);
            Console.SetIn(inputReader);

            _mockProductRepository.Setup(mock => mock.IsIdUnique(productId))
                       .Returns((int id) => !_productList.Any(p => p.Id == id));

            var result = _userInteraction.GetUniqueId();
            ClassicAssert.AreEqual(productId, result);
        }

        [TestCase("Vasanth")]
        [TestCase("Nikil")]
        public void GetUniqueName_GetUniqueNameFromUser_ReturnsName(string productName)
        {
            StringReader inputReader = new StringReader(productName);
            Console.SetIn(inputReader);
            _mockProductRepository.Setup(mock => mock.IsNameUnique(productName))
                  .Returns((string name) => !_productList.Any(p => p.Name.Equals(name)));

            var result = _userInteraction.GetUniqueName();

            ClassicAssert.AreEqual(productName, result);
        }
    }
}
