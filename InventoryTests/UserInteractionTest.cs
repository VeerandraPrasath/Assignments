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
        private Mock<IProductRepository> _productRepository;
        private IUserInteraction _userInteraction;
        StringWriter stringWriter;

        [SetUp]
        public void SetUp()
        {
            _product1 = new Product(1, "Prasath", 10, 20);
            _productList = new List<Product>() { _product1, new Product(2, "Arun", 20, 30) };
            _productRepository = new Mock<IProductRepository>();
            _userInteraction = new UserInteraction(_productRepository.Object);
            stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
        }

        [Test]
        public void DisplayAllProducts_ShallPrintAllProductInList()
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
        public void DisplayAllProducts_ShallPrintMessage_IFProductNotFoundInList()
        {
            string message = "**** No products available ****\r\n";
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            _userInteraction.DisplayAllProducts(new List<Product>());
            string output = stringWriter.ToString();

            ClassicAssert.AreEqual(message, output);
        }

        [Test]
        public void DisplayEditOptions_ShallPrintAllEditOptions()
        {
            string message = "\n[1] Name \n[2] Id\n[3] Quantity \n[4] Price\n\r\n";

            _userInteraction.DisplayEditMenuOptions();
            string output = stringWriter.ToString();

            ClassicAssert.AreEqual(message, output);
        }

        [Test]
        public void DisplayOptions_ShallPrintAllAvailableOptions()
        {
            string message = "\n[1] View \n[2] Add \n[3] Edit \n[4] Delete \n[5] Search \n[6] Clear \n[7] Exit\n\r\n";
            _userInteraction.DisplayMenuOptions();
            string output = stringWriter.ToString();

            ClassicAssert.AreEqual(message, output);
        }

        [TestCase(3, "Vasanth", 10, 15)]
        [TestCase(4, "Nikil", 12, 10)]
        [Test]
        public void GetProductDetail_ShallReturnProduct_BasedOnUserInput(int id, string name, int quantity, int price)
        {
            string input = $"{id}\n{name}\n{quantity}\n{price}";
            StringReader inputReader = new StringReader(input);
            Console.SetIn(inputReader);
            _productRepository.Setup(mock => mock.IsNameUnique(It.IsAny<string>()))
                  .Returns((string name) => !_productList.Any(p => p.Name.Equals(name)));
            _productRepository.Setup(mock => mock.IsIdUnique(It.IsAny<int>()))
                      .Returns((int id) => !_productList.Any(p => p.Id == id));


            Product result = _userInteraction.GetProductDetails();

            ClassicAssert.IsTrue(result.Id == id && result.Name.Equals(name) && result.Quantity == quantity && result.Price == price);
        }

        [TestCase("ABCD")]
        [TestCase("Prasath")]
        [Test]
        public void GetInputStringShallReturnString_BasedOnUserInput(string input)
        {
            StringReader inputReader = new StringReader(input);
            Console.SetIn(inputReader);

            var result = _userInteraction.GetInputString("Name");

            ClassicAssert.AreEqual(input, result);
        }


        [TestCase("1")]
        [TestCase("91283")]
        [TestCase("0003")]
        [TestCase("2323")]
        [Test]
        public void GetInputIntShallReturnInt_BasedOnUserInput(string input)
        {
            StringReader inputReader = new StringReader(input);
            Console.SetIn(inputReader);

            var result = _userInteraction.GetInputString("Id");

            ClassicAssert.AreEqual(input, result);
        }

        [Test]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void GetUniqueIdShallReturnIdIfInputIdIsUnique(int input)
        {
            string consoleinput = $"{input}";
            StringReader inputReader = new StringReader(consoleinput);
            Console.SetIn(inputReader);

            _productRepository.Setup(mock => mock.IsIdUnique(input))
                       .Returns((int id) => !_productList.Any(p => p.Id == id));

            var result = _userInteraction.GetUniqueId();
            ClassicAssert.AreEqual(input, result);
        }

        [TestCase("Vasanth")]
        [TestCase("Nikil")]
        [Test]
        public void GetUniqueNameShallReturnNameIfInputNameIsUnique(string input)
        {
            StringReader inputReader = new StringReader(input);
            Console.SetIn(inputReader);
            _productRepository.Setup(mock => mock.IsNameUnique(It.IsAny<string>()))
                  .Returns((string name) => !_productList.Any(p => p.Name.Equals(name)));

            var result = _userInteraction.GetUniqueName();

            ClassicAssert.AreEqual(input, result);
        }
    }
}
