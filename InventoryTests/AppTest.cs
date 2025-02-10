using NUnit.Framework;
using Moq;
using InventoryManager.Manager;
using InventoryManager.ConsoleInteraction;
using InventoryManager.Controller;
using InventoryManager.Model;
using InventoryManager;

namespace InventoryManagerTests
{
    public class AppTest
    {
        private App _app;
        private Mock<IManageInventory> _manageInventory;
        private Mock<IUserInteraction> _userInteraction;
        private Mock<IProductRepository> _productRepository;

        [SetUp]
        public void SetUp()
        {
            _manageInventory = new Mock<IManageInventory>();
            _userInteraction = new Mock<IUserInteraction>();
            _productRepository = new Mock<IProductRepository>();
            _app = new App(_manageInventory.Object, _userInteraction.Object, _productRepository.Object);
        }

        [TestCase("1")]
        public void Run_ShallDisplayOptions_WhenInputIs1(string userOption)
        {
            _userInteraction.SetupSequence(mock => mock.GetInputString(It.IsAny<string>())).Returns(userOption).Returns("7");
            _productRepository.Setup(mock => mock.GetAllProducts()).Returns(new List<Product>());

            _app.Run();

            _userInteraction.Verify(mock => mock.DisplayAllProducts(new List<Product>()));
        }

        [TestCase("2")]
        public void Run_ShallAddNewProduct_WhenInputIs2(string userOption)
        {
            _userInteraction.SetupSequence(mock => mock.GetInputString(It.IsAny<string>())).Returns(userOption).Returns("7");

            _app.Run();

            _manageInventory.Verify(mock => mock.AddNewProduct());
        }

        [TestCase("3")]
        public void Run_ShallEditProduct_WhenInputIs3(string userOption)
        {
            _userInteraction.SetupSequence(mock => mock.GetInputString(It.IsAny<string>())).Returns(userOption).Returns("7");

            _app.Run();

            _manageInventory.Verify(mock => mock.EditExistingProduct());
        }

        [TestCase("4")]
        public void Run_ShallDeleteProduct_WhenInputIs4(string userOption)
        {
            _userInteraction.SetupSequence(mock => mock.GetInputString(It.IsAny<string>())).Returns(userOption).Returns("7");

            _app.Run();

            _manageInventory.Verify(mock => mock.DeleteExistingProduct());
        }

        [TestCase("5")]
        public void Run_ShallSearchProduct_WhenInputIs5(string userOption)
        {
            _userInteraction.SetupSequence(mock => mock.GetInputString(It.IsAny<string>())).Returns(userOption).Returns("7");

            _app.Run();

            _manageInventory.Verify(mock => mock.SearchProducts());
        }
    }
}
