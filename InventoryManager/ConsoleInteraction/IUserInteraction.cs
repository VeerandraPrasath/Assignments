using InventoryManager.Model;

namespace InventoryManager.ConsoleInteraction
{
    /// <summary>
    /// Used to interact with user
    /// </summary>
    public interface IUserInteraction
    {
        /// <summary>
        /// Display options
        /// </summary>
        public void DisplayMenuOptions();

        /// <summary>
        /// Display edit options
        /// </summary>
        public void DisplayEditMenuOptions();

        /// <summary>
        /// Display all <see cref="Product"/>
        /// </summary>
        /// <param name="productList">Product List</param>
        public void DisplayAllProducts(List<Product> productList);

        /// <summary>
        /// Get product details
        /// </summary>
        /// <returns>returns product</returns>
        public Product GetProductDetails();

        /// <summary>
        /// Validates input string
        /// </summary>
        /// <param name="message">message</param>
        /// <returns>returns string</returns>
        public string GetInputString(string message);

        /// <summary>
        /// Validates input integer
        /// </summary>
        /// <param name="message">message</param>
        /// <returns>returns integer</returns>
        public int GetInputInt(string message);

        /// <summary>
        /// Get Unique Name
        /// </summary>
        /// <returns>returns string</returns>
        public string GetUniqueName();

        /// <summary>
        /// Get Unique Id
        /// </summary>
        /// <returns>returns int</returns>
        public int GetUniqueId();
    }
}