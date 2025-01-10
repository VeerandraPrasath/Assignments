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

