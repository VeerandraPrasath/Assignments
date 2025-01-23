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
        /// Injects <see cref="IProductRepository"/>,<see cref="IUserInteraction"/>
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
            Product newProduct = _userInteraction.GetNewProductDetail();
            _productRepository.AddProduct(newProduct);
            Console.WriteLine("Product added successfully !!!");
        }

        public void DeleteExistingProduct()
        {
            if(_productRepository.GetAllProducts().Count==0)
            {
                Console.WriteLine("No product available to delete !");

                return;
            }
            int id = _userInteraction.GetAndValidateIntInput("id");
            string message = _productRepository.DeleteProduct(id) == true ? "Deleted successfully" : "Product not found";
            Console.WriteLine(message);
        }

        public void EditExistingProduct()
        {
            if (_productRepository.GetAllProducts().Count == 0)
            {
                Console.WriteLine("No product available to edit !");

                return;
            }
            int id = _userInteraction.GetAndValidateIntInput("id");
            Product product = _productRepository.FindById(id);
            if (product is not null)
            {
                _userInteraction.DisplayEditOptions();
                string userEditOption = _userInteraction.GetAndValidateStringInput("option");
                switch (userEditOption)
                {
                    case "1":
                        product.Name = _userInteraction.GetAndValidateStringInput("name to update");
                        Console.WriteLine("***Name updated successfully*****");
                        break;
                    case "2":
                        product.Quantity = _userInteraction.GetAndValidateIntInput("Quantity to update");
                        Console.WriteLine("***Quantity updated Successfully***");
                        break;
                    case "3":
                        product.Price = _userInteraction.GetAndValidateIntInput("Price to update ");
                        Console.WriteLine("***Price updated successfully***");
                        break;
                    default:
                        Console.WriteLine("***Invalid input***");
                        break;
                }
            }
            else
            {
                Console.WriteLine("**** No product found with the id *****");
            }
        }

        public void SearchProduct()
        {
            if (_productRepository.GetAllProducts().Count == 0)
            {
                Console.WriteLine("No product available to search !");

                return;
            }
            bool isExit = false;
            do
            {
                Console.WriteLine("Search with \n[1] ID \n[2] Name\n[3] Exit");
                string userInput = _userInteraction.GetAndValidateStringInput("option");
                Product product;
                switch (userInput)
                {
                    case "1":
                        string name = _userInteraction.GetAndValidateStringInput("Name");
                        product = _productRepository.GetByName(name);
                        if (product is not null)
                        {
                            Console.WriteLine(product);
                        }
                        else
                        {
                            Console.WriteLine("Product not found");
                        }
                        break;
                    case "2":
                        int id = _userInteraction.GetAndValidateIntInput("ID");
                        product = _productRepository.FindById(id);
                        if (product is not null)
                        {
                            Console.WriteLine(product);
                        }
                        else
                        {
                            Console.WriteLine("***Product not found***");
                        }
                        break;
                    case "3":
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("***Invalid option***");
                        break;
                }
            } while (!isExit);
        }
    }
}