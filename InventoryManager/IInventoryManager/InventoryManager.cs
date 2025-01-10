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
       
          int id=_userInteraction.getAndValidateID();
          string message = _productRepository.deleteProduct(id) == true ? "Deleted successfully" : "Product not found";
           Console.WriteLine(message);
        
    }
   

    
   
}

