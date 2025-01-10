public class UserInteraction : IUserInteraction
{
    private readonly IProductRepository _productRepository;
    public UserInteraction(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public void displayAllProducts(List<Product> allProducts)
    {
        if (allProducts == null || allProducts.Count==0)
        {
            Console.WriteLine("No products available !!");
            return;
        }
        for (int i = 0; i < allProducts.Count; i++)
        {
            Console.WriteLine($"{i+1} . {allProducts[i].ToString()}");
        }
         
    }

    public void displayEditOptions()
    {
        Console.WriteLine("\n[N]ame \n [Q]uantity \n [P]rice");
    }

    public void displayOptions()
    {
        Console.WriteLine("\n[V]iew \n [A]dd \n [E]dit \n [D]elete \n[S]earch \n[C]lear \n [EX]it");
    }

    public Product getNewProductDetail()
    {
        Console.WriteLine("Enter the below details :");

        int id;
        do
        {

        id=GetAndValidateIntInput("new Id");
        if (_productRepository.checkId(id))
        {
                Console.WriteLine("ID already exists !");
        }
        }while(_productRepository.checkId(id));

       string productName= GetAndValidateStringInput("Name");
        int quantity = GetAndValidateIntInput("quantity ");
        int price = GetAndValidateIntInput("price");

        return new Product(id,productName,quantity,price); 
    }

   
    public string GetAndValidateStringInput(string message)
    {
        string? userInput;
        
        
        do
        {
            Console.WriteLine($"Enter {message}");
            userInput = Console.ReadLine();
            if(userInput == "" || userInput is null)
            {
                Console.WriteLine("******Input should not be null ****");
            }
        } while (userInput=="" || userInput is null);
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
                Console.WriteLine("***Input should be number***");
            }
        } while (!isValidDigit);
        return intValue;
    }
}
    

