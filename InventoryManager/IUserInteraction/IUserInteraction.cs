/// <summary>
/// <see cref="IUserInteraction"/> used to interact with the user
/// </summary>
public interface IUserInteraction
{
    /// <summary>
    /// <see cref="displayOptions"/> display all the available <see cref="Product"/>
    /// </summary>
    public void displayOptions();

    /// <summary>
    /// <see cref="displayEditOptions"/> display the edit options
    /// </summary>
    public void displayEditOptions();

    /// <summary>
    /// <see cref="displayAllProducts(List{Product})"/> display all the <see cref="Product"/>
    /// </summary>
    /// <param name="allProducts">all the available <see cref="Product"/></param>
    public void displayAllProducts(List<Product> allProducts);

    /// <summary>
    /// <see cref="getNewProductDetail"/> get new product details
    /// </summary>
    /// <returns>New <see cref="Product"/> with deatils</returns>
    public Product getNewProductDetail();

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

