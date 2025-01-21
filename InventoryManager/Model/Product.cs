namespace InventoryManager.Model
{

    /// <summary>
    /// <see cref="Product"/> bind the details of a product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Id of product
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the product
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Quantity of product
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Price of the product
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// <see cref="Product"/> constructor initialize the id,name,quantity and prize 
        /// </summary>
        /// <param name="id">id of the <see cref="Product"/></param>
        /// <param name="name">name of the <see cref="Product"/></param>
        /// <param name="quantity">quantity of the <see cref="Product"/></param>
        /// <param name="price">price of the <see cref="Product"/></param>
        public Product(int id, string name, int quantity, int price)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        /// <summary>
        /// <see cref="ToString"/> combines all the details of <see cref="Product"/> into string
        /// </summary>
        /// <returns>string with all the <see cref="Product"/> details</returns>
        public override string ToString()
        {
            return $"ID :{Id}  Name : {Name} Quantity : {Quantity} Price : {Price} ";
        }
    }
}