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
        private Mock<IProductRepository> _mockProductRepository;
        private Mock<IUserInteraction> _mockUserInteraction;
        private List<Product> _productList;
        private Product _product1, _emptyProduct;

        [SetUp]
        public void Setup()
        {
            _product1 = new Product(1, "Prasath", 1, 20);
            _emptyProduct = null;
            _productList = new List<Product>() { _product1, new Product(2, "Arun", 2, 30) };
            _mockProductRepository = new Mock<IProductRepository>();
            _mockUserInteraction = new Mock<IUserInteraction>();
            _manageInventory = new ManageInventory(_mockProductRepository.Object, _mockUserInteraction.Object);
        }

        [TestCase(2, "Arun", 10, 30)]
        [TestCase(3, "Bhai", 30, 40)]
        public void AddNewProduct_AddProductTOList(int id, string name, int quantity, int price)
        {
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var product = new Product(id, name, quantity, price);
            _mockUserInteraction.Setup(mock => mock.GetProductDetails()).Returns(product);
            _manageInventory.AddNewProduct();


            _mockProductRepository.Verify(mock => mock.AddProduct(product),Times.Once);
            var output = stringWriter.ToString();
            ClassicAssert.IsTrue(output.Contains("Product added successfully !!!"));
        }

        [TestCase("Prasath")]
        [TestCase("1")]
        public void DeleteExistingProduct_DeleteProduct_When_ProductExist(string productDetail)
        {
            _mockProductRepository.Setup(mock => mock.GetAllProducts()).Returns(_productList);
            _mockUserInteraction.Setup(mock => mock.GetInputString("Product Name or Id ")).Returns(productDetail);
            _mockProductRepository.Setup(mock => mock.FindProduct(productDetail)).Returns(_product1);

            _manageInventory.DeleteExistingProduct();

            _mockProductRepository.Verify(mock => mock.DeleteProduct(_product1), Times.Once);
        }

        [TestCase("Arun")]
        [TestCase("2")]
        public void DeleteExistingProduct_NotDeleteProduct_When_ProductNotExist(string productDetail)
        {
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            _mockProductRepository.Setup(mock => mock.GetAllProducts()).Returns(_productList);
            _mockUserInteraction.Setup(mock => mock.GetInputString("Product Name or Id ")).Returns(productDetail);
            _mockProductRepository.Setup(mock => mock.FindProduct(productDetail)).Returns((Product)null);

            _manageInventory.DeleteExistingProduct();
            var output = stringWriter.ToString();

            ClassicAssert.IsTrue(output.Contains("Product Not Found  !"));
        }

        [TestCase("Prasath", "Veera", "1")]
        [TestCase("Arun", "Kumar", "1")]
        public void EditExistingProduct_EditProductName_When_UserSelectName(string productDetail, string newName, string userOption)
        {

            _mockProductRepository.Setup(mock => mock.GetAllProducts()).Returns(_productList);
            _mockUserInteraction.Setup(mock => mock.GetInputString("Product Name or Id ")).Returns(productDetail);
            _mockProductRepository.Setup(mock => mock.FindProduct(productDetail)).Returns(_product1);
            _mockUserInteraction.Setup(mock => mock.GetInputString("option")).Returns(userOption);
            _mockUserInteraction.Setup(mock => mock.GetUniqueName()).Returns(newName);

            _manageInventory.EditExistingProduct();

            ClassicAssert.AreEqual(newName, _product1.Name);
        }

        [TestCase("Prasath", 3, "2")]
        [TestCase("Arun", 5, "2")]
        public void EditExistingProduct_EditProductId_When_UserSelectProductId(string productDetail, int newId, string userOption)
        {
            _mockProductRepository.Setup(mock => mock.GetAllProducts()).Returns(_productList);
            _mockUserInteraction.Setup(mock => mock.GetInputString("Product Name or Id ")).Returns(productDetail);
            _mockProductRepository.Setup(mock => mock.FindProduct(productDetail)).Returns(_product1);
            _mockUserInteraction.Setup(mock => mock.GetInputString("option")).Returns(userOption);
            _mockUserInteraction.Setup(mock => mock.GetUniqueId()).Returns(newId);

            _manageInventory.EditExistingProduct();

            ClassicAssert.AreEqual(newId, _product1.Id);
        }

        [TestCase("Prasath", 30, "3")]
        [TestCase("Arun", 40, "3")]
        public void EditExistingProduct_EditProductQuantity_When_UserSelectQuantity(string productDetail, int newQuantity, string userOption)
        {
            _mockProductRepository.Setup(mock => mock.GetAllProducts()).Returns(_productList);
            _mockUserInteraction.Setup(mock => mock.GetInputString("Product Name or Id ")).Returns(productDetail);
            _mockProductRepository.Setup(mock => mock.FindProduct(productDetail)).Returns(_product1);
            _mockUserInteraction.Setup(mock => mock.GetInputString("option")).Returns(userOption);
            _mockUserInteraction.Setup(mock => mock.GetInputInt(It.IsAny<string>())).Returns(newQuantity);

            _manageInventory.EditExistingProduct();

            ClassicAssert.AreEqual(newQuantity, _product1.Quantity);
        }

        [TestCase("Prasath", 15, "4")]
        [TestCase("Arun", 20, "4")]
        public void EditExistingProduct_EditProductPrice_When_UserSelectPrice(string productDetail, int newPrice, string userOption)
        {
            _mockProductRepository.Setup(mock => mock.GetAllProducts()).Returns(_productList);
            _mockUserInteraction.Setup(mock => mock.GetInputString("Product Name or Id ")).Returns(productDetail);
            _mockProductRepository.Setup(mock => mock.FindProduct(productDetail)).Returns(_product1);
            _mockUserInteraction.Setup(mock => mock.GetInputString("option")).Returns(userOption);
            _mockUserInteraction.Setup(mock => mock.GetInputInt(It.IsAny<string>())).Returns(newPrice);

            _manageInventory.EditExistingProduct();

            ClassicAssert.AreEqual(newPrice, _product1.Price);
        }

        [TestCase("1", true)]
        [TestCase("Arun", true)]
        public void SearchProducts_ReturnProduct_When_ProductExist(string productDetail, bool expected)
        {
            _mockProductRepository.Setup(mock => mock.GetAllProducts()).Returns(_productList);
            _mockUserInteraction.Setup(mock => mock.GetInputString("Product Name or Id ")).Returns(productDetail);
            _mockProductRepository.Setup(mock => mock.FindProduct(productDetail)).Returns(_product1);

            Product product = _manageInventory.SearchProducts();

            ClassicAssert.AreEqual(expected, product is not null);
        }

        [TestCase("Prasa", false)]
        [TestCase("xxzzyy", false)]
        public void SearchProducts_ReturnNull_When_ProductNotExist(string productDetail, bool expected)
        {
            _mockProductRepository.Setup(mock => mock.GetAllProducts()).Returns(_productList);
            _mockUserInteraction.Setup(mock => mock.GetInputString("Product Name or Id ")).Returns(productDetail);
            _mockProductRepository.Setup(mock => mock.FindProduct(productDetail)).Returns((Product)null);

            Product product = _manageInventory.SearchProducts();

            ClassicAssert.AreEqual(expected, product is not null);
        }
    }
}