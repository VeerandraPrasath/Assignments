using InventoryManager.Model;

namespace InventoryManager.Controller
{
    /// <summary>
    /// Interact with <see cref="ProductRepository._productList"/>
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Get Product List
        /// </summary>
        /// <returns>returns Product List</returns>
        public List<Product> GetAllProducts();

        /// <summary>
        /// Add Product to Product List
        /// </summary>
        /// <param name="newProduct">New Product</param>
        /// <returns>returns true if product added else false</returns>
        public bool AddProduct(Product newProduct);

        /// <summary>
        /// Checks id present in <see cref="ProductRepository._productList"/>
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>returns true if id present else false</returns>
        public bool CheckId(int id);

        /// <summary>
        /// Delete Product with Id"/>
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>returns true if Product deleted else false</returns>
        public bool DeleteProduct(int id);

        /// <summary>
        /// Finds Product with Id 
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>returns Product if present else null</returns>
        public Product FindById(int id);

        /// <summary>
        /// Find Product with Name
        /// </summary>
        /// <param name="name">Product Name</param>
        /// <returns>returns Product if present else null</returns>
        public Product GetByName(string name);
    }
}