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

        [Test]
        public void Run_DisplayOptions_When_InputIs1()
        {
            string userOption = "1";
            _userInteraction.SetupSequence(mock => mock.GetInputString(It.IsAny<string>())).Returns(userOption).Returns("7");
            _productRepository.Setup(mock => mock.GetAllProducts()).Returns(new List<Product>());

            _app.Run();

            _userInteraction.Verify(mock => mock.DisplayAllProducts(new List<Product>()));
        }

        [Test]
        public void Run_AddNewProduct_When_InputIs2()
        {
            string userOption = "2";
            _userInteraction.SetupSequence(mock => mock.GetInputString(It.IsAny<string>())).Returns(userOption).Returns("7");

            _app.Run();

            _manageInventory.Verify(mock => mock.AddNewProduct());
        }

        [Test]
        public void Run_EditProduct_When_InputIs3()
        {
            string userOption = "3";
            _userInteraction.SetupSequence(mock => mock.GetInputString(It.IsAny<string>())).Returns(userOption).Returns("7");

            _app.Run();

            _manageInventory.Verify(mock => mock.EditExistingProduct());
        }

        [Test]
        public void Run_DeleteProduct_When_InputIs4()
        {
            string userOption = "4";
            _userInteraction.SetupSequence(mock => mock.GetInputString(It.IsAny<string>())).Returns(userOption).Returns("7");

            _app.Run();

            _manageInventory.Verify(mock => mock.DeleteExistingProduct());
        }

        [Test]
        public void Run_SearchProduct_When_InputIs5()
        {
            string userOption = "5";
            _userInteraction.SetupSequence(mock => mock.GetInputString(It.IsAny<string>())).Returns(userOption).Returns("7");

            _app.Run();

            _manageInventory.Verify(mock => mock.SearchProducts());
        }
    }
}
