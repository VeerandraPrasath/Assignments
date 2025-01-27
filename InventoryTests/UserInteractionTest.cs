using InventoryManager.ConsoleInteraction;
using InventoryManager.Controller;
using InventoryManager.Model;
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
            _productList = new List<Product>() { _product1,new Product(2,"Arun",20,30)};
            _productRepository = new Mock<IProductRepository>();
            _userInteraction=new UserInteraction(_productRepository.Object);
            stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

        }

        [Test]
        public void DisplayAllProductsShallPrintAllProductInList()
        {
            string products="";
            string newLine = "";
            for (int i = 0; i < _productList.Count; i++)
            {
                products += $"{newLine}{i + 1} . {_productList[i].ToString()}\r\n";
                
            }

            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            _userInteraction.DisplayAllProducts(_productList);

            string output = stringWriter.ToString();
            //ClassicAssert.IsTrue(output.Contains(products));
            ClassicAssert.AreEqual(products, output);
        }

        [Test]
        public void DisplayAllProductsShallPrintMessageIFProductNotFoundInList()
        {
            string message = "**** No products available ****\r\n";
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            _userInteraction.DisplayAllProducts(new List<Product>());

            string output = stringWriter.ToString();
            ClassicAssert.AreEqual(message, output);
        }

        [Test]
        public void DisplayEditOptionsShallPrintAllEditOptions()
        {
            string message = "\n[1] Name \n[2] Id\n[3] Quantity \n[4] Price\n\r\n";
            _userInteraction.DisplayEditOptions();

            string output = stringWriter.ToString();
            ClassicAssert.AreEqual(message, output);
        }

        [Test]
        public void DisplayOptionsShallPrintAllAvailableOptions()
        {
            string message = "\n[1] View \n[2] Add \n[3] Edit \n[4] Delete \n[5] Search \n[6] Clear \n[7] Exit\n\r\n";
            _userInteraction.DisplayOptions();

            string output = stringWriter.ToString();
            ClassicAssert.AreEqual(message, output);
        }

        [Test]
        public void GetProductDetail_ShallReturnProductBasedOnUserInput()
        {

        }

        [Test]
        public void GetInputStringShallReturnString_BasedOnUserInput()
        {
            //string input = "5\n\100\nojdad";
            //StringReader  inputReader = new StringReader(input);
            //Console.SetIn(inputReader);

            string input = "Prasath";
            StringReader inputReader= new StringReader(input);
            Console.SetIn(inputReader);

            var result = _userInteraction.GetInputString("Name");

            ClassicAssert.AreEqual(input, result);

        }

        [Test]
        public void GetInputIntShallReturnInt_BasedOnUserInput()
        {
            string input = "1";
            StringReader inputReader = new StringReader(input);
            Console.SetIn(inputReader);

            var result = _userInteraction.GetInputString("Id");

            ClassicAssert.AreEqual(input, result);

        }

        [Test]
        public void GetUniqueIdShallReturnIdIfInputIdIsUnique()
        {
            string consoleinput = "1";
            StringReader inputReader = new StringReader(consoleinput);
            Console.SetIn(inputReader);

            var input = 1;
            _productRepository.Setup(mock=>mock.IsIdUnique(input)).Returns(true);
             var result= _userInteraction.GetUniqueId();
            ClassicAssert.AreEqual(input, result);
        }

        [Test]
        public void GetUniqueNameShallReturnIdIfInputIdIsUnique()
        {
            string input = "Prasath";
            StringReader inputReader = new StringReader(input);
            Console.SetIn(inputReader);

            _productRepository.Setup(mock => mock.IsNameUnique(input)).Returns(true);
            var result = _userInteraction.GetUniqueId();
            ClassicAssert.AreEqual(input, result);
        }
    }
}
