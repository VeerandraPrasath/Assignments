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
        /// Constructor of User Interaction
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

        public void DisplayEditMenuOptions()
        {
            Console.WriteLine("\n[1] Name \n[2] Id\n[3] Quantity \n[4] Price\n");
        }

        public void DisplayMenuOptions()
        {
            Console.WriteLine("\n[1] View \n[2] Add \n[3] Edit \n[4] Delete \n[5] Search \n[6] Clear \n[7] Exit\n");
        }

        public Product GetProductDetails()
        {
            int id,quantity,price;
            string name;
            Console.WriteLine("Enter the below details :\n");

            id=GetUniqueId();
            name = GetUniqueName();
            quantity = GetInputInt("quantity ");
            price = GetInputInt("price");

            return new Product(id,name, quantity, price);
        }

        public string GetInputString(string message)
        {
            string userInput;
            do
            {
                Console.Write($"Enter {message} :");
                userInput = Console.ReadLine();
                if (userInput == "" || userInput is null)
                {
                    Console.WriteLine("**** Input should not be null ****");
                }
            } while (userInput == "" || userInput is null);

            return userInput;
        }

        public int GetInputInt(string message)
        {
            bool isValidDigit = false;
            int intValue;
            do
            {
                isValidDigit = int.TryParse(GetInputString(message), out intValue);
                if (!isValidDigit)
                {
                    Console.WriteLine("**** Input should be number ****");
                }
            } while (!isValidDigit);

            return intValue;
        }

        public int GetUniqueId()
        {
            int uniqueId;
            do
            {
                uniqueId = GetInputInt("new Id");
                if (!_productRepository.IsIdUnique(uniqueId))
                {
                    Console.WriteLine("**** ID already exists ****");
                }
            } while (!_productRepository.IsIdUnique(uniqueId));

            return uniqueId;
        }
        
        public string GetUniqueName()
        {
            string uniqueName;
            do
            {
                uniqueName = GetInputString("name");
                if (!_productRepository.IsNameUnique(uniqueName))
                {
                    Console.WriteLine("**** Name already exists ****");
                }
            } while (!_productRepository.IsNameUnique(uniqueName));
            
            return uniqueName;
        }
    }
}