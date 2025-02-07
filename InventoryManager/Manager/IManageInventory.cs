using InventoryManager.Model;

namespace InventoryManager.Manager
{
    /// <summary>
    ///  Used to handle features
    /// </summary>
    public interface IManageInventory
    {
        /// <summary>
        /// Adds new Product
        /// </summary>
        public void AddNewProduct();

        /// <summary>
        /// Deletes exisiting Product
        /// </summary>
        public void DeleteExistingProduct();

        /// <summary>
        /// Edits  exisiting Product
        /// </summary>
        public void EditExistingProduct();

        /// <summary>
        /// Searches Product
        /// </summary>
        public Product SearchProducts();
    }
}