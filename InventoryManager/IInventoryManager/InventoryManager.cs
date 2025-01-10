class InventoryManager :IInventoryManager
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
       
          int id=_userInteraction.GetAndValidateIntInput("id");
          string message = _productRepository.deleteProduct(id) == true ? "Deleted successfully" : "Product not found";
           Console.WriteLine(message);
        
    }
   public void editExistingProduct()
    {
        int id = _userInteraction.GetAndValidateIntInput("id");
        Product product = _productRepository.findById(id);
        if (product is not null)
        {
            _userInteraction.displayEditOptions();
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

   public void searchProduct()
    {
        Console.WriteLine("Search with \n [I]D \n [N]ame ");
        string userInput=_userInteraction.GetAndValidateStringInput("option");
        Product product;
        switch (userInput)
        {
            case "N":
            case "n":
                string name = _userInteraction.GetAndValidateStringInput("Name");
               product= _productRepository.getByName(name);
                if(product is  not null)
                {
                    Console.WriteLine(product);
                }
                else
                {
                    Console.WriteLine("Product not found");
                }
                break;
            case "I":
            case "i":
                int id = _userInteraction.GetAndValidateIntInput("ID");
                product = _productRepository.findById(id);
                if (product is not null)
                {
                    Console.WriteLine(product);
                }
                else
                {
                    Console.WriteLine("Product not found");
                }
                break;
            default:
                Console.WriteLine("***Invalid option***");
                break;



        }
    }

    
   
}

