namespace Linq
{
    /// <summary>
    /// Stores the details of the Supplier
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// Name of the Supplier
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// Id of the Supplier
        /// </summary>
        public int SupplierId { get; set; }

        /// <summary>
        /// Id of the Product
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Constructor for Supplier
        /// </summary>
        /// <param name="name">Name of the Supplier</param>
        /// <param name="supplierId">Id of the Supplier</param>
        /// <param name="productId">Id of the Product</param>
        public Supplier(string name, int supplierId, int productId)
        {
            SupplierName = name;
            SupplierId = supplierId;
            ProductId = productId;
        }
    }
}
