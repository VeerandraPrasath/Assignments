using InventoryManager.Controller;
using InventoryManager.ConsoleInteraction;
using InventoryManager.Model;

namespace InventoryManager.Manager
{
    /// <summary>
    /// Implements <see cref="IManageInventory"/>
    /// </summary>
    class ManageInventory : IManageInventory
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserInteraction _userInteraction;

        /// <summary>
        /// Constructor for ManageInventory
        /// </summary>
        /// <param name="productRepository">Product Repository</param>
        /// <param name="userInteraction">User Interaction</param>
        public ManageInventory(IProductRepository productRepository, IUserInteraction userInteraction)
        {
            _productRepository = productRepository;
            _userInteraction = userInteraction;
        }

        public void AddNewProduct()
        {
            Product newProduct = _userInteraction.GetProductDetails();
            _productRepository.AddProduct(newProduct);
            Console.WriteLine("Product added successfully !!!");
        }

        public void DeleteExistingProduct()
        {
            Product product = SearchProducts();
            if (product is null)
            {
                Console.WriteLine("Product Not Found  !");

                return;
            }
            Console.WriteLine(product);
            _productRepository.DeleteProduct(product);
            Console.WriteLine("Product Deleted Successfully !");
        }

        public void EditExistingProduct()
        {
            Product product = SearchProducts();
            if (product is not null)
            {
                Console.WriteLine(product);
                _userInteraction.DisplayEditMenuOptions();
                string userEditOption = _userInteraction.GetInputString("option");
                switch (userEditOption)
                {
                    case "1":
                        product.Name = _userInteraction.GetUniqueName();
                        Console.WriteLine("\nName updated successfully !\n");
                        break;
                    case "2":
                        product.Id = _userInteraction.GetUniqueId();
                        Console.WriteLine("\nId updated successfully !\n");
                        break;
                    case "3":
                        product.Quantity = _userInteraction.GetInputInt("Quantity");
                        Console.WriteLine("\nQuantity updated Successfully !\n");
                        break;
                    case "4":
                        product.Price = _userInteraction.GetInputInt("Price");
                        Console.WriteLine("\nPrice updated successfully !\n");
                        break;
                    default:
                        Console.WriteLine("*** Invalid input ***");
                        break;
                }
            }
            else
            {
                Console.WriteLine("**** No product found ********");
            }
        }

        public Product SearchProducts()
        {
            bool isExit = false;
            if (_productRepository.GetAllProducts().Count == 0)
            {
                return null;
            }
            string userInput = _userInteraction.GetInputString("Product Name or Id ");

            return _productRepository.FindProduct(userInput);
        }
    }
}