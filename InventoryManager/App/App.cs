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

