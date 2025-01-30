using InventoryManager.ConsoleInteraction;
using InventoryManager.Controller;
using InventoryManager.Manager;
using InventoryManager.Model;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace InventoryManagerTests
{
    public class InventoryManagerTest
    {
        private IManageInventory _manageInventory;
        private Mock<IProductRepository> _productRepository;
        private Mock<IUserInteraction> _userInteraction;
        private List<Product> _productList;
        private Product _product1,_emptyProduct;

        [SetUp]
        public void Setup()
        {
            _product1 = new Product(1, "Prasath", 1, 20);
            _emptyProduct = null;
            _productList = new List<Product>() { _product1,new Product(2,"Arun",2,30)};
           _productRepository= new Mock<IProductRepository>();
            _userInteraction= new Mock<IUserInteraction>();
            _manageInventory = new ManageInventory(_productRepository.Object, _userInteraction.Object);
        }

        [TestCase(2,"Arun",10,30)]
        [TestCase(3,"Bhai",30,40)]
        [Test]
        public void AddNewProduct_ShallAddProductTOList(int id,string name,int quantity,int price)
        {
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var product = new Product(id,name,quantity,price);
            _userInteraction.Setup(mock => mock.GetProductDetail()).Returns(product);
            _manageInventory.AddNewProduct();


            _productRepository.Verify(mock=>mock.AddProduct(product));
            var output= stringWriter.ToString();
            ClassicAssert.IsTrue(output.Contains("Product added successfully !!!"));
        }

        [TestCase("Prasath")]
        [TestCase("1")]
        [Test]
        public void DeleteExistingProduct_ShallDeleteProduct_IfExisted(string inputString)
        {  
            _productRepository.Setup(mock=>mock.GetAllProducts()).Returns(_productList);
            _userInteraction.Setup(mock => mock.GetInputString(It.IsAny<string>())).Returns(inputString);
            _productRepository.Setup(mock => mock.FindProduct(inputString)).Returns(_product1);

            _manageInventory.DeleteExistingProduct();   

            _productRepository.Verify(mock=>mock.DeleteProduct(_product1));
        }

        [TestCase("Arun")]
        [TestCase("2")]
        [Test]
        public void DeleteExistingProduct_ShallNotDeleteProduct_IfNotExisted(string inputString)
        {
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            _productRepository.Setup(mock => mock.GetAllProducts()).Returns(_productList);
            _userInteraction.Setup(mock => mock.GetInputString(It.IsAny<string>())).Returns(inputString);
            _productRepository.Setup(mock => mock.FindProduct(inputString)).Returns(_emptyProduct);

            _manageInventory.DeleteExistingProduct();

            var output = stringWriter.ToString();
            ClassicAssert.IsTrue(output.Contains("Product Not Found  !"));
        }

        [TestCase("Prasath","Veera","1")]
        public void EditExistingProduct_ShallEditProductName_WhenOptionIs1(string inputString,string newName,string userOption)
        {
       
            _productRepository.Setup(mock => mock.GetAllProducts()).Returns(_productList);
            _userInteraction.Setup(mock => mock.GetInputString(It.IsAny<string>())).Returns(inputString);
            _productRepository.Setup(mock => mock.FindProduct(inputString)).Returns(_product1);
            _userInteraction.Setup(mock=>mock.GetInputString("option")).Returns(userOption);
            _userInteraction.Setup(mock => mock.GetUniqueName()).Returns(newName);

            _manageInventory.EditExistingProduct();

            ClassicAssert.AreEqual(newName,_product1.Name);

        }

        [TestCase("Prasath", 3, "2")]
        public void EditExistingProduct_ShallEditProductId_WhenOptionIs2(string inputString, int newId, string userOption)
        {
            _productRepository.Setup(mock => mock.GetAllProducts()).Returns(_productList);
            _userInteraction.Setup(mock => mock.GetInputString(It.IsAny<string>())).Returns(inputString);
            _productRepository.Setup(mock => mock.FindProduct(inputString)).Returns(_product1);
            _userInteraction.Setup(mock => mock.GetInputString("option")).Returns(userOption);
            _userInteraction.Setup(mock => mock.GetUniqueId()).Returns(newId);

            _manageInventory.EditExistingProduct();

            ClassicAssert.AreEqual(newId, _product1.Id);
        }

        [TestCase("Prasath", 30, "3")]
        public void EditExistingProduct_ShallEditProductQuantity_WhenOptionIs3(string inputString, int newQuantity, string userOption)
        {
            _productRepository.Setup(mock => mock.GetAllProducts()).Returns(_productList);
            _userInteraction.Setup(mock => mock.GetInputString(It.IsAny<string>())).Returns(inputString);
            _productRepository.Setup(mock => mock.FindProduct(inputString)).Returns(_product1);
            _userInteraction.Setup(mock => mock.GetInputString("option")).Returns(userOption);
            _userInteraction.Setup(mock => mock.GetInputInt(It.IsAny<string>())).Returns(newQuantity);

            _manageInventory.EditExistingProduct();

            ClassicAssert.AreEqual(newQuantity, _product1.Quantity);
        }

        [TestCase("Prasath", 15, "4")]
        public void EditExistingProduct_ShallEditProductPrice_WhenOptionIs4(string inputString, int newPrice, string userOption)
        {
            _productRepository.Setup(mock => mock.GetAllProducts()).Returns(_productList);
            _userInteraction.Setup(mock => mock.GetInputString(It.IsAny<string>())).Returns(inputString);
            _productRepository.Setup(mock => mock.FindProduct(inputString)).Returns(_product1);
            _userInteraction.Setup(mock => mock.GetInputString("option")).Returns(userOption);
            _userInteraction.Setup(mock => mock.GetInputInt(It.IsAny<string>())).Returns(newPrice);

            _manageInventory.EditExistingProduct();

            ClassicAssert.AreEqual(newPrice, _product1.Price);
        }

        [TestCase("Prasa",false)]
        [TestCase("1",true)]
        [TestCase("Arun",true)]
        [TestCase("xxzzyy",false)]
        [Test]
        public void SearchProducts_ShallReturnProduct_IfExistedElseNull(string inputString,bool expected)
        {
            _productRepository.Setup(mock => mock.GetAllProducts()).Returns(_productList);
            _userInteraction.Setup(mock => mock.GetInputString(It.IsAny<string>())).Returns(inputString);
            _productRepository.Setup(mock => mock.FindProduct(inputString)).Returns(() => {
                foreach (var p in _productList)
                {
                    if (p.Id.ToString().Equals(inputString) || p.Name.Equals(inputString))
                    {
                        return p;
                    }
                }
                return null;
            });
            Product product = _manageInventory.SearchProducts();
            ClassicAssert.AreEqual(expected,product is not null);
        }
    }
}