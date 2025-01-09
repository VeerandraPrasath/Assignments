
using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        ProductRepository productRepository = new ProductRepository();
        UserInteraction userInteraction = new UserInteraction(productRepository);
        InventoryManager inventoryManager = new InventoryManager(productRepository, userInteraction);
        App app = new App(inventoryManager, userInteraction, productRepository);
        app.run();
    }
}

public class App
{
    private readonly IInventoryManager _inventoryManager;
    private readonly IUserInteraction _userInteraction;
    private readonly IProductRepository _productRepository;
    public App(IInventoryManager IinventoryManager,IUserInteraction userInteraction,IProductRepository productRepository)
    {
          _inventoryManager = IinventoryManager;
        _userInteraction = userInteraction;
        _productRepository = productRepository;
    }

    public void run()
    {
        bool isExit=false;
        while (!isExit)
        {

        _userInteraction.displayOptions();
         String userOption=Console.ReadLine();
        switch (userOption)
        {
            case "V":
            case "v":
                _userInteraction.displayAllProducts(_productRepository.getAllProducts());
                break;
            case "A":
            case "a":
                _inventoryManager.addNewProduct();
                break;
                case "D":
                case "d":
                 _inventoryManager.deleteExistingProduct();
                  break;
           
            case "C":
            case "c":
                 Console.Clear();
                  break;
             case "EX":
             case "ex":
                    isExit = true;
                     break;         
        }

        }
    }
}
public interface IInventoryManager
{
   public  void addNewProduct();
    public void deleteExistingProduct();

}
class InventoryManager:IInventoryManager
{
    private readonly IProductRepository _productRepository;
    private readonly IUserInteraction _userInteraction; 
    public InventoryManager(IProductRepository productRepository, IUserInteraction userInteraction)
    {
          _productRepository = productRepository;
        _userInteraction= userInteraction;
    }

    public void addNewProduct()
    {
        Product newProduct=_userInteraction.getNewProductDetail();
        _productRepository.addProduct(newProduct);
        Console.WriteLine("Product added successfully !!!");
        
    }
    public void deleteExistingProduct()
    {
       
          int id=_userInteraction.getAndValidateID();
          string message = _productRepository.deleteProduct(id) == true ? "Deleted successfully" : "Product not found";
           Console.WriteLine(message);
        
    }
   

    
   
}
public interface IProductRepository
{
    public List<Product> getAllProducts();
    public bool addProduct(Product newProduct);
    //public bool removeProduct(Product existingProduct);
    public bool checkId(int id);
    public bool deleteProduct(int id);
    public Product findById(int id);
}
public class ProductRepository:IProductRepository
{
   private List<Product> allProducts;
    public ProductRepository()
    {
        allProducts=new List<Product>();    
    }
    public bool addProduct(Product newProduct)
    {
        allProducts.Add(newProduct);    
        return true;
    }

    public List<Product> getAllProducts()
    {
        return allProducts;
    }

    public bool checkId(int id)
    {
        foreach (Product product in allProducts)
        {
            if(product.Id == id) return true;
        }
        return false;
    }
   
    public bool deleteProduct(int id)
    {
        Product productToDelete=findById(id);
        if (productToDelete != null)
        {
            allProducts.Remove(findById(id));
            return true;
        }
        else
        {
            return false;
        }
    }
    public Product findById(int id)
    {
        foreach(Product product in allProducts)
        {
            if(product.Id == id) return product;
        }
        return null;
    }
}
public interface IUserInteraction
{
    public void displayOptions();
    public void displayEditOptions();
    public void displayAllProducts(List<Product> allProducts);
    public Product getNewProductDetail();
    public int getAndValidateID();

}
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

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }

    public Product(int id, string name, int quantity, int price)
    {
        Id = id;
        Name = name;
        Quantity = quantity;

        Price = price;
    }
    public override string ToString()
    {
        return $"ID :{Id}  Name : {Name} Quantity : {Quantity} Price : {Price} ";
    }
}

