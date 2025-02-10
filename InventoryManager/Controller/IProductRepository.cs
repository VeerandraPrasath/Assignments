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
        public void AddProduct(Product newProduct);

        /// <summary>
        /// Checks id present in <see cref="ProductRepository._productList"/>
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>returns true if id unique else false</returns>
        public bool IsIdUnique(int id);

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="product">Product to delete</param>
        /// <returns>returns true if deleted else false</returns>
        public bool DeleteProduct(Product product);

        /// <summary>
        /// Check Product Name is Unique
        /// </summary>
        /// <param name="name">Product Name</param>
        /// <returns>returns true if unique else false</returns>
        public bool IsNameUnique(string name);

        /// <summary>
        /// Find Product
        /// </summary>
        /// <param name="productInformation">Product Information</param>
        /// <returns>returns Product if present else null</returns>
        public Product FindProduct(string productInformation);
    }
}