using InventoryManager.Controller;
using InventoryManager.ConsoleInteraction;
using InventoryManager.Manager;
using InventoryManager.Model;

namespace InventoryManager
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ProductRepository productRepository = new ProductRepository(new List<Product>());
            UserInteraction userInteraction = new UserInteraction(productRepository);
            ManageInventory inventoryManager = new ManageInventory(productRepository, userInteraction);
            App app = new App(inventoryManager, userInteraction, productRepository);
            app.Run();
        }

        /// <summar
        /// Starts the main flow
        /// </summary>
        public class App
        {
            private readonly IManageInventory _inventoryManager;
            private readonly IUserInteraction _userInteraction;
            private readonly IProductRepository _productRepository;

            /// <summary>
            /// Constructor for App
            /// </summary>
            /// <param name="inventoryManager">Inventory Manager</param>
            /// <param name="userInteraction">User Interaction</param>
            /// <param name="productRepository">Product Repository</param>
            public App(IManageInventory inventoryManager, IUserInteraction userInteraction, IProductRepository productRepository)
            {
                _inventoryManager = inventoryManager;
                _userInteraction = userInteraction;
                _productRepository = productRepository;
            }

            /// <summary>
            /// Initialize the work flow
            /// </summary>
            public void Run()
            {
                bool isExit = false;
                while (!isExit)
                {
                    _userInteraction.DisplayOptions();
                    string userOption = _userInteraction.GetInputString("option");
                    switch (userOption)
                    {
                        case "1":
                            _userInteraction.DisplayAllProducts(_productRepository.GetAllProducts());
                            break;
                        case "2":
                            _inventoryManager.AddNewProduct();
                            break;
                        case "3":
                            _inventoryManager.EditExistingProduct();
                            break;
                        case "4":
                            _inventoryManager.DeleteExistingProduct();
                            break;
                        case "5":
                            Product product = _inventoryManager.SearchProducts();
                            if (product is not null)
                            {
                                Console.WriteLine(product);
                            }
                            else
                            {
                                Console.WriteLine("Product Not Found");
                            }
                            break;
                        case "6":
                            Console.Clear();
                            break;
                        case "7":
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
}