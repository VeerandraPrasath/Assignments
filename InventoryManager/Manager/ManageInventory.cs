using InventoryManager.Controller;
using InventoryManager.ConsoleInteraction;
using InventoryManager.Model;
namespace InventoryManager.Manager
{

    /// <summary>
    /// <see cref="ManageInventory"/> implements the <see cref="IManageInventory"/> interface 
    /// </summary>
    class ManageInventory : IManageInventory
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserInteraction _userInteraction;

        /// <summary>
        /// Constructor that injects the required Interfaces <see cref="IProductRepository"/> <see cref="IUserInteraction"/>
        /// </summary>
        /// <param name="productRepository"></param>
        /// <param name="userInteraction"></param>
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
                    case "N":
                    case "n":
                        product.Name = _userInteraction.GetAndValidateStringInput("name to update");

                        Console.WriteLine("***Name updated successfully*****");
                        break;
                    case "Q":
                    case "q":


                        product.Quantity = _userInteraction.GetAndValidateIntInput("Quantity to update");
                        Console.WriteLine("***Quantity updated Successfully***");
                        break;
                    case "P":
                    case "p":

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

                Console.WriteLine("Search with \n[I]D \n[N]ame\n[E]xit");
                string userInput = _userInteraction.GetAndValidateStringInput("option");
                Product product;
                switch (userInput.ToLower())
                {
                    case "n":
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
                    case "i":
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
                    case "e":
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