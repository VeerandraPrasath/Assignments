/// <summary>
/// IProductRepository interface handle with the product database
/// </summary>
public interface IProductRepository
{
    public List<Product> getAllProducts();
    public bool addProduct(Product newProduct);
    
    public bool checkId(int id);
    public bool deleteProduct(int id);
    public Product findById(int id);
    public Product getByName(string name);
}

