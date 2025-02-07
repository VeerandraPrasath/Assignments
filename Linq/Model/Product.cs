namespace Linq.Model
{
    /// <summary>
    /// Stores the details of the Product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Name of the Product
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Id of the Product
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Category of the Product
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Price of the Product
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Id of the Supplier
        /// </summary>
        public int SupplierId { get; set; }

        /// <summary>
        /// Constructor for Product
        /// </summary>
        /// <param name="name">Name of the Product</param>
        /// <param name="id">Id of the Product</param>
        /// <param name="category">Category of the Product</param>
        /// <param name="price">Price of </param>
        /// <param name="suppilerId">Id of the Supplier</param>
        public Product(string name, int id, string category, decimal price, int suppilerId)
        {
            ProductName = name;
            ProductId = id;
            Category = category;
            Price = price;
            SupplierId = suppilerId;
        }

        /// <summary>
        /// Ovveride the ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Name : {ProductName}  ProductId : {ProductId} Price  : {Price}  Category : {Category}";
        }
    }
}
