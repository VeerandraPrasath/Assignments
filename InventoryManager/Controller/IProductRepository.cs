using InventoryManager.Model;

namespace InventoryManager.Controller
{

    /// <summary>
    /// <see cref="IProductRepository"/> Interface is used to interact with the <see cref="ProductRepository._productList"/>
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Abstract <see cref="GetAllProducts"/> get all the products
        /// </summary>
        /// <returns>
        /// list of available <see cref="Product"/>
        /// </returns>
        public List<Product> GetAllProducts();

        /// <summary>
        /// <see cref="AddProduct(Product)"/> add new product
        /// </summary>
        /// <param name="newProduct">
        /// <see cref="Product"/> new product to add
        /// </param>
        /// <returns>true if product added else false</returns>
        public bool AddProduct(Product newProduct);

        /// <summary>
        /// <see cref="CheckId(int)"/>  checks the id present in the <see cref="ProductRepository._productList"/>
        /// </summary>
        /// <param name="id"> id of the product</param>
        /// <returns>true if id present else false</returns>
        public bool CheckId(int id);

        /// <summary>
        ///  <see cref="DeleteProduct(int)"/> delete product with id"/>
        /// </summary>
        /// <param name="id">id of the product</param>
        /// <returns>true if deleted else false</returns>
        public bool DeleteProduct(int id);

        /// <summary>
        /// <see cref="FindById(int)"/> finds the <see cref="Product"/> with id 
        /// </summary>
        /// <param name="id">id of the product</param>
        /// <returns><see cref="Product"/> if found else null</returns>
        public Product FindById(int id);

        /// <summary>
        /// <see cref="GetByName(string)"/> find the product with name
        /// </summary>
        /// <param name="name">name of the product</param>
        /// <returns><see cref="Product"/> if found else null</returns>
        public Product GetByName(string name);
    }
}