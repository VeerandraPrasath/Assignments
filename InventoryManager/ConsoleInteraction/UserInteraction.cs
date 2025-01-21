using InventoryManager.Model;
using InventoryManager.Controller;

namespace InventoryManager.ConsoleInteraction
{

    /// <summary>
    /// <see cref="UserInteraction"/> implements the features of <see cref="IUserInteraction"/> Interface
    /// </summary>
    public class UserInteraction : IUserInteraction
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// <see cref="UserInteraction"/> Constructor injects <see cref="IProductRepository"/>
        /// </summary>
        /// <param name="productRepository"></param>
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
            Console.WriteLine("\n[N]ame \n[Q]uantity \n[P]rice\n");
        }

        public void DisplayOptions()
        {
            Console.WriteLine("\n[V]iew \n[A]dd \n[E]dit \n[D]elete \n[S]earch \n[C]lear \n[EX]it\n");
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