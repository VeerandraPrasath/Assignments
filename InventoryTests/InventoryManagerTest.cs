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

        [Test]
        public void AddNewProductShallAddProductTOList()
        {
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var product = new Product(2, "NewProduct", 2, 10);
            _userInteraction.Setup(mock => mock.GetProductDetail()).Returns(product);
            _manageInventory.AddNewProduct();
            _productRepository.Verify(mock=>mock.AddProduct(product));

            var output= stringWriter.ToString();
            ClassicAssert.IsTrue(output.Contains("Product added successfully !!!"));

        }

        [Test]
        public void DeleteExistingProductShallDeleteProductIfExisted()
        {   var inputString = "Prasath";
            _productRepository.Setup(mock=>mock.GetAllProducts()).Returns(_productList);
            _userInteraction.Setup(mock => mock.GetInputString("Product Name or Id ")).Returns(inputString);
            _productRepository.Setup(mock => mock.FindProduct(inputString)).Returns(_product1);

            _manageInventory.DeleteExistingProduct();   

            _productRepository.Verify(mock=>mock.DeleteProduct(_product1));
        }

        [Test]
        public void DeleteExistingProductShallNotDeleteProductIfNotExisted()
        {
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var inputString = "4";
            _productRepository.Setup(mock => mock.GetAllProducts()).Returns(_productList);
            _userInteraction.Setup(mock => mock.GetInputString("Product Name or Id ")).Returns(inputString);
            _productRepository.Setup(mock => mock.FindProduct(inputString)).Returns(_emptyProduct);

            _manageInventory.DeleteExistingProduct();

            //_productRepository.Verify(mock => mock.DeleteProduct(_product1));
            var output = stringWriter.ToString();
            ClassicAssert.IsTrue(output.Contains("Product Not Found  !"));
        }

        [Test]
        public void EditExistingProductShallEditProductNameWhenOptionIs1()
        {
            var inputString = "Prasath";
            //var editOption = "\n[1] Name \n[2] Id\n[3] Quantity \n[4] Price\n";
            _productRepository.Setup(mock => mock.GetAllProducts()).Returns(_productList);
            _userInteraction.Setup(mock => mock.GetInputString("Product Name or Id ")).Returns(inputString);
            _productRepository.Setup(mock => mock.FindProduct(inputString)).Returns(_product1);

            var newName = "Veera";
            //_userInteraction.Setup(mock=>mock.DisplayEditOptions());
            _userInteraction.Setup(mock=>mock.GetInputString("option")).Returns("1");
            _userInteraction.Setup(mock => mock.GetUniqueName()).Returns(newName);

            _manageInventory.EditExistingProduct();

            ClassicAssert.AreEqual(newName,_product1.Name);

        }

        [Test]
        public void EditExistingProductShallEditProductIdWhenOptionIs2()
        {
            var inputString = "Prasath";
            //var editOption = "\n[1] Name \n[2] Id\n[3] Quantity \n[4] Price\n";
            _productRepository.Setup(mock => mock.GetAllProducts()).Returns(_productList);
            _userInteraction.Setup(mock => mock.GetInputString("Product Name or Id ")).Returns(inputString);
            _productRepository.Setup(mock => mock.FindProduct(inputString)).Returns(_product1);

            var newId = 3;
            //_userInteraction.Setup(mock => mock.DisplayEditOptions());
            _userInteraction.Setup(mock => mock.GetInputString("option")).Returns("2");
            _userInteraction.Setup(mock => mock.GetUniqueId()).Returns(newId);

            _manageInventory.EditExistingProduct();

            ClassicAssert.AreEqual(newId, _product1.Id);

        }

        [Test]
        public void EditExistingProductShallEditProductQuantityWhenOptionIs3()
        {
            var inputString = "Prasath";
            //var editOption = "\n[1] Name \n[2] Id\n[3] Quantity \n[4] Price\n";
            _productRepository.Setup(mock => mock.GetAllProducts()).Returns(_productList);
            _userInteraction.Setup(mock => mock.GetInputString("Product Name or Id ")).Returns(inputString);
            _productRepository.Setup(mock => mock.FindProduct(inputString)).Returns(_product1);

            var newQuantity = 30;
            //_userInteraction.Setup(mock => mock.DisplayEditOptions());
            _userInteraction.Setup(mock => mock.GetInputString("option")).Returns("3");
            _userInteraction.Setup(mock => mock.GetInputInt(It.IsAny<string>())).Returns(newQuantity);

            _manageInventory.EditExistingProduct();

            ClassicAssert.AreEqual(newQuantity, _product1.Quantity);

        }

        [Test]
        public void EditExistingProductShallEditProductPriceWhenOptionIs4()
        {
            var inputString = "Prasath";
            //var editOption = "\n[1] Name \n[2] Id\n[3] Quantity \n[4] Price\n";
            _productRepository.Setup(mock => mock.GetAllProducts()).Returns(_productList);
            _userInteraction.Setup(mock => mock.GetInputString("Product Name or Id ")).Returns(inputString);
            _productRepository.Setup(mock => mock.FindProduct(inputString)).Returns(_product1);

            var newPrice = 100;
            //_userInteraction.Setup(mock => mock.DisplayEditOptions());
            _userInteraction.Setup(mock => mock.GetInputString("option")).Returns("4");
            _userInteraction.Setup(mock => mock.GetInputInt(It.IsAny<string>())).Returns(newPrice);

            _manageInventory.EditExistingProduct();

            ClassicAssert.AreEqual(newPrice, _product1.Price);

        }

        [Test]
        public void SearchProductsShallReturnProductIfExisted()
        {
            var inputString = "Prasath";
            //var editOption = "\n[1] Name \n[2] Id\n[3] Quantity \n[4] Price\n";
            _productRepository.Setup(mock => mock.GetAllProducts()).Returns(_productList);
            _userInteraction.Setup(mock => mock.GetInputString("Product Name or Id ")).Returns(inputString);
            _productRepository.Setup(mock => mock.FindProduct(inputString)).Returns(_product1);

            Product product=_manageInventory.SearchProducts();
            ClassicAssert.AreEqual(_product1, product);
        }

        [Test]
        public void SearchProductsShallReturnNullIfNotExisted()
        {
            var inputString = "4";
            //var editOption = "\n[1] Name \n[2] Id\n[3] Quantity \n[4] Price\n";
            _productRepository.Setup(mock => mock.GetAllProducts()).Returns(_productList);
            _userInteraction.Setup(mock => mock.GetInputString("Product Name or Id ")).Returns(inputString);
            _productRepository.Setup(mock => mock.FindProduct(inputString)).Returns(_emptyProduct);

            Product product = _manageInventory.SearchProducts();
            ClassicAssert.IsNull(product);
        }
    }

}
;