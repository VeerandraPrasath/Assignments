using InventoryManager.Model;
using InventoryManager.Controller;

namespace InventoryManager.ConsoleInteraction
{
    /// <summary>
    /// Implements <see cref="IUserInteraction"/> Interface
    /// </summary>
    public class UserInteraction : IUserInteraction
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Injects <see cref="IProductRepository"/>
        /// </summary>
        /// <param name="productRepository">Product Repository</param>
        public UserInteraction(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void DisplayAllProducts(List<Product> productList)
        {
            if (productList == null || productList.Count == 0)
            {
                Console.WriteLine("**** No products available ****");
                return;
            }
            for (int i = 0; i < productList.Count; i++)
            {
                Console.WriteLine($"{i + 1} . {productList[i].ToString()}");
            }
        }

        public void DisplayEditOptions()
        {
            Console.WriteLine("\n[1] Name \n[2] Quantity \n[3] Price\n");
        }

        public void DisplayOptions()
        {
            Console.WriteLine("\n[1] View \n[2] Add \n[3] Edit \n[4] Delete \n[5] Search \n[6] Clear \n[7] Exit\n");
        }

        public Product GetNewProductDetail()
        {
            Console.WriteLine("Enter the below details :\n");
            int id;
            do
            {
                id = GetAndValidateIntInput("new Id");
                if (_productRepository.CheckId(id))
                {
                    Console.WriteLine("**** ID already exists ****");
                }
            } while (_productRepository.CheckId(id));
            string productName = GetAndValidateStringInput("Name");
            int quantity = GetAndValidateIntInput("quantity ");
            int price = GetAndValidateIntInput("price");

            return new Product(id, productName, quantity, price);
        }

        public string GetAndValidateStringInput(string message)
        {
            string userInput;
            do
            {
                Console.WriteLine($"Enter {message} :");
                userInput = Console.ReadLine();
                if (userInput == "" || userInput is null)
                {
                    Console.WriteLine("**** Input should not be null ****");
                }
            } while (userInput == "" || userInput is null);

            return userInput;
        }

        public int GetAndValidateIntInput(string message)
        {
            bool isValidDigit = false;
            int intValue;
            do
            {
                isValidDigit = int.TryParse(GetAndValidateStringInput(message), out intValue);
                if (!isValidDigit)
                {
                    Console.WriteLine("**** Input should be number ****");
                }
            } while (!isValidDigit);

            return intValue;
        }
    }
}