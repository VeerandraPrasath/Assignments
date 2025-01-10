/// <summary>
/// ProductRepository class implements all the method in the IProductRepository
/// </summary>
public class ProductRepository:IProductRepository
{
   private List<Product> allProducts;
    /// <summary>
    /// initialize the list
    /// </summary>
    public ProductRepository()
    {
        allProducts=new List<Product>();    
    }
    /// <summary>
    /// add new product to the product list
    /// </summary>
    /// <param name="newProduct"></param>
    /// <returns></returns>
    public bool addProduct(Product newProduct)
    {
        allProducts.Add(newProduct);    
        return true;
    }
    /// <summary>
    /// return all the available products
    /// </summary>
    /// <returns></returns>
    public List<Product> getAllProducts()
    {
        return allProducts;
    }
    /// <summary>
    /// cheeck the product with the provided ID exist or not
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool checkId(int id)
    {
        foreach (Product product in allProducts)
        {
            if(product.Id == id) return true;
        }
        return false;
    }
   /// <summary>
   /// delete product with ID
   /// </summary>
   /// <param name="id"></param>
   /// <returns></returns>
    public bool deleteProduct(int id)
    {
        Product productToDelete=findById(id);
        if (productToDelete != null )
        {
            allProducts.Remove(productToDelete);
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// return product with id if exist
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Product findById(int id)
    {
        foreach(Product product in allProducts)
        {
            if(product.Id == id) return product;
        }
        return null;
    }
    /// <summary>
    /// return product with name if available
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Product getByName(string name)
    {
        foreach(Product product in allProducts)
        {
            if(product.Name.Equals(name)) return product;
        }
        return null;
    }
}

