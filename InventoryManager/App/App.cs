/// <summary>
/// <see cref="App"/> which starts the main flow 
/// </summary>
public class App
{
    private readonly IInventoryManager _inventoryManager;
    private readonly IUserInteraction _userInteraction;
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Constructor used to inject the required interfaces <see cref="IInventoryManager"/> <see cref="IUserInteraction"/> <see cref="IProductRepository"/>
    /// </summary>
    /// <param name="IinventoryManager"></param>
    /// <param name="userInteraction"></param>
    /// <param name="productRepository"></param>
    public App(IInventoryManager IinventoryManager, IUserInteraction userInteraction, IProductRepository productRepository)
    {
        _inventoryManager = IinventoryManager;
        _userInteraction = userInteraction;
        _productRepository = productRepository;
    }

    /// <summary>
    /// <see cref="run"/> initialize the working flow
    /// </summary>
    public void run()
    {
        bool isExit = false;
        while (!isExit)
        {

            _userInteraction.displayOptions();
            string userOption = _userInteraction.GetAndValidateStringInput("option");
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
                case "e":
                case "E":
                    _inventoryManager.editExistingProduct();
                    break;
                case "S":
                case "s":
                    _inventoryManager.searchProduct();
                    break;
                case "C":
                case "c":
                    Console.Clear();
                    break;
                case "EX":
                case "ex":
                    isExit = true;
                    break;
                default:
                    Console.WriteLine("***Invalid Input***");
                    break;

            }

        }
    }
}

