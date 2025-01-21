using InventoryManager.Manager;
using InventoryManager.ConsoleInteraction;
using InventoryManager.Controller;
namespace InventoryManager.Application
{

    /// <summary>
    /// <see cref="App"/> which starts the main flow 
    /// </summary>
    public class App
    {
        private readonly IManageInventory _inventoryManager;
        private readonly IUserInteraction _userInteraction;
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Constructor used to inject the required interfaces <see cref="IManageInventory"/> <see cref="IUserInteraction"/> <see cref="IProductRepository"/>
        /// </summary>
        /// <param name="IinventoryManager"></param>
        /// <param name="userInteraction"></param>
        /// <param name="productRepository"></param>
        public App(IManageInventory IinventoryManager, IUserInteraction userInteraction, IProductRepository productRepository)
        {
            _inventoryManager = IinventoryManager;
            _userInteraction = userInteraction;
            _productRepository = productRepository;
        }

        /// <summary>
        /// <see cref="Run"/> initialize the working flow
        /// </summary>
        public void Run()
        {
            bool isExit = false;
            while (!isExit)
            {

                _userInteraction.DisplayOptions();
                string userOption = _userInteraction.GetAndValidateStringInput("option");
                switch (userOption.ToLower())
                {
                    case "v":
                        _userInteraction.DisplayAllProducts(_productRepository.GetAllProducts());
                        break;
                    case "a":
                        _inventoryManager.AddNewProduct();
                        break;
                    case "d":
                        _inventoryManager.DeleteExistingProduct();
                        break;
                    case "e":
                        _inventoryManager.EditExistingProduct();
                        break;
                    case "s":
                        _inventoryManager.SearchProduct();
                        break;
                    case "c":
                        Console.Clear();
                        break;
                    case "ex":
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("***Invalid Input***");
                        break;

                }

            }
        }
    }
}