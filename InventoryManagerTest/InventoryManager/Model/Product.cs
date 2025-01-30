namespace InventoryManager.Model
{
    /// <summary>
    /// Stores Product information
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Product Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Product Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Product Quantity
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Product Price
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Initialize Product values 
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">Name</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="price">Price</param>
        public Product(int id, string name, int quantity, int price)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        /// <summary>
        /// Gives Product Information
        /// </summary>
        /// <returns>returns string</returns>
        public override string ToString()
        {
            return $"ID :{Id}  Name : {Name} Quantity : {Quantity} Price : {Price} ";
        }
    }
}