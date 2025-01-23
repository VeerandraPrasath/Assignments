using InventoryManager.Model;

namespace InventoryManager.ConsoleInteraction
{
    /// <summary>
    /// Used to interact with user
    /// </summary>
    public interface IUserInteraction
    {
        /// <summary>
        /// Display all the available <see cref="Product"/>
        /// </summary>
        public void DisplayOptions();

        /// <summary>
        /// Display the edit options
        /// </summary>
        public void DisplayEditOptions();

        /// <summary>
        /// Display all the <see cref="Product"/>
        /// </summary>
        /// <param name="productList">Product List</param>
        public void DisplayAllProducts(List<Product> productList);

        /// <summary>
        /// Get product details
        /// </summary>
        /// <returns>returns product</returns>
        public Product GetNewProductDetail();

        /// <summary>
        /// Validates input string
        /// </summary>
        /// <param name="message">message</param>
        /// <returns>returns string</returns>
        public string GetAndValidateStringInput(string message);

        /// <summary>
        ///  Validates input integer
        /// </summary>
        /// <param name="message">message</param>
        /// <returns>returns integer</returns>
        public int GetAndValidateIntInput(string message);
    }
}