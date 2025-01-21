using InventoryManager.Model;

namespace InventoryManager.Manager
{

    /// <summary>
    ///  IInverntoryManager interface used to handle the features
    /// </summary>
    public interface IManageInventory
    {
        /// <summary>
        /// <see cref="AddNewProduct"/> to add new product <see cref="Product"/>
        /// </summary>
        public void AddNewProduct();

        /// <summary>
        /// <see cref="DeleteExistingProduct"/> deletes the exisiting product <see cref="Product"/>
        /// </summary>
        public void DeleteExistingProduct();

        /// <summary>
        /// <see cref="EditExistingProduct"/> edits the exisiting product <see cref="Product"/>
        /// </summary>
        void EditExistingProduct();

        /// <summary>
        /// <see cref="SearchProduct"/> which searches the product <see cref="Product"/>
        /// </summary>
        void SearchProduct();

    }
}