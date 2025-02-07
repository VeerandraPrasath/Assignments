using Linq.Model;

namespace Linq
{
    /// <summary>
    /// Get the average price of products in a category where price is greater than 500
    /// </summary>
    public class Task1
    {
        /// <summary>
        /// List to store the Product
        /// </summary>
        public List<Product> ProductList { get; set; }

        /// <summary>
        /// Constructor for Task1
        /// </summary>
        public Task1()
        {
            ProductList = new List<Product>() {
                new Product("Laptop",1,"Electronics",50000,1),
                new Product("Mobile",2,"Electronics",20000,3),
                new Product("Shirt",3,"Clothing",1000,5),
                new Product("Trousers",4,"Clothing",1500,7),
                new Product("Shoes",5,"Footwear",3000,8),
                new Product("Sneakers",6,"Footwear",2500,9)
            };
        }

        /// <summary>
        /// Initialize the methods
        /// </summary>
        public void Run()
        {
            GetProductByCategoryAndPriceGreaterThan500("Electronics");
        }

        /// <summary>
        /// Get Product based on the given category and price greater than 500 and calculate the average price
        /// </summary>
        /// <param name="category">Category of the product</param>
        public void GetProductByCategoryAndPriceGreaterThan500(string category)
        {
            List<Product> filteredProductsByCategoryAndPriceGreaterThan500 = ProductList.Where(p => p.Category == category && p.Price > 500).ToList();
            var objectListOnlyWithNameAndPrice = filteredProductsByCategoryAndPriceGreaterThan500.Select(p => new { p.ProductName, p.Price }).OrderByDescending((a) => a.Price);
            decimal averagePrice = objectListOnlyWithNameAndPrice.Average(p => p.Price);
            Console.WriteLine($"\nAverage Price of {category} is {averagePrice}");
        }
    }
}
