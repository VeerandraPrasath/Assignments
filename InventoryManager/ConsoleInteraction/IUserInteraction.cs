using InventoryManager.Model;

namespace InventoryManager.ConsoleInteraction
{

    /// <summary>
    /// <see cref="IUserInteraction"/> used to interact with the user
    /// </summary>
    public interface IUserInteraction
    {
        /// <summary>
        /// <see cref="DisplayOptions"/> display all the available <see cref="Product"/>
        /// </summary>
        public void DisplayOptions();

        /// <summary>
        /// <see cref="DisplayEditOptions"/> display the edit options
        /// </summary>
        public void DisplayEditOptions();

        /// <summary>
        /// <see cref="DisplayAllProducts(List{Product})"/> display all the <see cref="Product"/>
        /// </summary>
        /// <param name="productList">all the available <see cref="Product"/></param>
        public void DisplayAllProducts(List<Product> productList);

        /// <summary>
        /// <see cref="GetNewProductDetail"/> get new product details
        /// </summary>
        /// <returns>New <see cref="Product"/> with deatils</returns>
        public Product GetNewProductDetail();

        /// <summary>
        /// <see cref="GetAndValidateStringInput(string)"/> validate the user input string
        /// </summary>
        /// <param name="message">message to be printed</param>
        /// <returns>user input string</returns>
        public string GetAndValidateStringInput(string message);

        /// <summary>
        /// <see cref="GetAndValidateIntInput(string)"/> validate the user input integer
        /// </summary>
        /// <param name="message">message to be printed</param>
        /// <returns>user input integer</returns>
        public int GetAndValidateIntInput(string message);

    }
}