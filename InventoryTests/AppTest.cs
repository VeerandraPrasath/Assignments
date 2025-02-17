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
        private Mock<IManageInventory> _mockManageInventory;
        private Mock<IUserInteraction> _mockUserInteraction;
        private Mock<IProductRepository> _mockProductRepository;
        private List<Product> _productList;

        [SetUp]
        public void SetUp()
        {
            _productList=new List<Product>();
            _mockManageInventory = new Mock<IManageInventory>();
            _mockUserInteraction = new Mock<IUserInteraction>();
            _mockProductRepository = new Mock<IProductRepository>();
            _app = new App(_mockManageInventory.Object, _mockUserInteraction.Object, _mockProductRepository.Object);
        }

        [Test]
        public void Run_DisplayOptions_When_UserSelectDisplayOptions()
        {
            string userOption = "1";
            _mockUserInteraction.SetupSequence(mock => mock.GetInputString("option")).Returns(userOption).Returns("7");
            _mockProductRepository.Setup(mock => mock.GetAllProducts()).Returns(_productList);
                       
            _app.Run();

            _mockUserInteraction.Verify(mock => mock.DisplayAllProducts(_productList),Times.Once);
        }

        [Test]
        public void Run_AddNewProduct_When_UserSelectAdd()
        {
            string userOption = "2";
            _mockUserInteraction.SetupSequence(mock => mock.GetInputString("option")).Returns(userOption).Returns("7");

            _app.Run();

            _mockManageInventory.Verify(mock => mock.AddNewProduct(), Times.Once);
        }

        [Test]
        public void Run_EditProduct_When_UserSelectEdit()
        {
            string userOption = "3";
            _mockUserInteraction.SetupSequence(mock => mock.GetInputString("option")).Returns(userOption).Returns("7");

            _app.Run();

            _mockManageInventory.Verify(mock => mock.EditExistingProduct(), Times.Once);
        }

        [Test]
        public void Run_DeleteProduct_When_UserSelectDelete()
        {
            string userOption = "4";
            _mockUserInteraction.SetupSequence(mock => mock.GetInputString("option")).Returns(userOption).Returns("7");

            _app.Run();

            _mockManageInventory.Verify(mock => mock.DeleteExistingProduct(), Times.Once);
        }

        [Test]
        public void Run_SearchProduct_When_UserSelectSearch()
        {
            string userOption = "5";
            _mockUserInteraction.SetupSequence(mock => mock.GetInputString("option")).Returns(userOption).Returns("7");

            _app.Run();

            _mockManageInventory.Verify(mock => mock.SearchProducts(), Times.Once);
        }
    }
}
