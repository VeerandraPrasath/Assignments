namespace Linq
{
    /// <summary>
    /// Get products based on category and perform sorting
    /// </summary>
    public class Task4
    {
        /// <summary>
        /// Stores the list of products
        /// </summary>
        public List<Product> ProductList { get; set; }

        /// <summary>
        /// Constructor for Task4
        /// </summary>
        public Task4()
        {
            ProductList = new List<Product>() {
                 new Product("Laptop",1,"Electronics",50000,1),
                new Product("Mobile",2,"Electronics",20000,3),
                new Product("Shirt",3,"Clothing",1000,5),
                new Product("Trousers",4,"Clothing",1500,7),
                new Product("Shoes",5,"Footwear",3000,8),
                new Product("Sneakers",6,"Footwear",2500,9),
                new Product("Headphones",7,"Electronics",1500,10),
                new Product("Psychology of money",8,"Books",500,11),
                new Product("T-Shirt",9,"Clothing",500,12),
                new Product("Rich Dad ,Poor Dad",10,"Books",2000,13),
                new Product("Sandals",11,"Footwear",1000,14),
            };
        }

        /// <summary>
        /// Initialize the methods
        /// </summary>
        public void Run()
        {
            GetProductByCategoryAndOrderByDescendingBasedOnPrice("Books");
        }

        /// <summary>
        /// Get the products based on category and order by descending based on product price
        /// </summary>
        /// <param name="category"></param>
        public void GetProductByCategoryAndOrderByDescendingBasedOnPrice(string category)
        {
            Console.WriteLine($"\nProducts in {category} Category Ordered by  Descending  based on Product Price\n");
            List<Product> OrderBooksByPrice = ProductList.Where(p => p.Category == category).OrderByDescending(x => x.Price).ToList();
            OrderBooksByPrice.ForEach(p => Console.WriteLine(p));
        }
    }
}
