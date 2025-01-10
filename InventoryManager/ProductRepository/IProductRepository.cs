public interface IProductRepository
{
    public List<Product> getAllProducts();
    public bool addProduct(Product newProduct);
    //public bool removeProduct(Product existingProduct);
    public bool checkId(int id);
    public bool deleteProduct(int id);
    public Product findById(int id);
}

