/// <summary>
///  IInverntoryManager interface used to handle the features
/// </summary>
public interface IInventoryManager
{
    /// <summary>
    /// <see cref="addNewProduct"/> to add new product <see cref="Product"/>
    /// </summary>
    public void addNewProduct();

    /// <summary>
    /// <see cref="deleteExistingProduct"/> deletes the exisiting product <see cref="Product"/>
    /// </summary>
    public void deleteExistingProduct();

    /// <summary>
    /// <see cref="editExistingProduct"/> edits the exisiting product <see cref="Product"/>
    /// </summary>
    void editExistingProduct();

    /// <summary>
    /// <see cref="searchProduct"/> which searches the product <see cref="Product"/>
    /// </summary>
    void searchProduct();

}

