/// <summary>
/// <see cref="IProductRepository"/> Interface is used to interact with the <see cref="ProductRepository.allProducts"/>
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Abstract <see cref="getAllProducts"/> get all the products
    /// </summary>
    /// <returns>
    /// list of available <see cref="Product"/>
    /// </returns>
    public List<Product> getAllProducts();

    /// <summary>
    /// <see cref="addProduct(Product)"/> add new product
    /// </summary>
    /// <param name="newProduct">
    /// <see cref="Product"/> new product to add
    /// </param>
    /// <returns>true if product added else false</returns>
    public bool addProduct(Product newProduct);

    /// <summary>
    /// <see cref="checkId(int)"/>  checks the id present in the <see cref="ProductRepository.allProducts"/>
    /// </summary>
    /// <param name="id"> id of the product</param>
    /// <returns>true if id present else false</returns>
    public bool checkId(int id);

    /// <summary>
    ///  <see cref="deleteProduct(int)"/> delete product with id"/>
    /// </summary>
    /// <param name="id">id of the product</param>
    /// <returns>true if deleted else false</returns>
    public bool deleteProduct(int id);

    /// <summary>
    /// <see cref="findById(int)"/> finds the <see cref="Product"/> with id 
    /// </summary>
    /// <param name="id">id of the product</param>
    /// <returns><see cref="Product"/> if found else null</returns>
    public Product findById(int id);

    /// <summary>
    /// <see cref="getByName(string)"/> find the product with name
    /// </summary>
    /// <param name="name">name of the product</param>
    /// <returns><see cref="Product"/> if found else null</returns>
    public Product getByName(string name);
}

