public class UserInteraction : IUserInteraction
{
    private readonly IProductRepository _productRepository;
    public UserInteraction(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public void displayAllProducts(List<Product> allProducts)
    {
        if (allProducts == null)
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
        Console.WriteLine("\n[P]rice \n [Q]uantity \n Enter your operation :");
    }

    public void displayOptions()
    {
        Console.WriteLine("\n[V]iew \n [A]dd \n [E]dit \n [D]elete \n[S]earch \n[C]lear \n [EX]it \nEnter your choice :");
    }

    public Product getNewProductDetail()
    {
        Console.WriteLine("Enter the below details :");
        int id;
        bool isValidDigit = false;
        bool isValidId = true;
        do
        {
            Console.WriteLine("\nEnter Valid new ID :");
            isValidDigit = int.TryParse(Console.ReadLine(), out id);
            if (isValidDigit)
            {
               isValidId= _productRepository.checkId(id);
            }
        } while (!isValidDigit || isValidId);
        Console.WriteLine("Name :");
        string  productName=Console.ReadLine();
        Console.WriteLine("Quantity :");
        int quantity;
        isValidDigit = false;
        do
        {
            isValidDigit = int.TryParse(Console.ReadLine(), out quantity);
        } while (!isValidDigit);
        Console.WriteLine("Price ");

        int price;
        isValidDigit = false;
        do
        {
            isValidDigit= int.TryParse(Console.ReadLine(), out price);
        } while (!isValidDigit);

        return new Product(id,productName,quantity,price); 
    }

    public int getAndValidateID()
    {
        int id;
        bool isValidDigit = false;
        bool isValidId = false;
        do
        {
            Console.WriteLine("\nEnter Valid  ID :");
            isValidDigit = int.TryParse(Console.ReadLine(), out id);
            if (isValidDigit)
            {
                isValidId = _productRepository.checkId(id);
            }
        } while (!isValidDigit || !isValidId);
        return id;

    }
}

