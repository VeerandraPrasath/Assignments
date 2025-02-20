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
        public void ExecuteTask1Queries()
        {
            Task1Queries("Electronics", 500);
        }

        /// <summary>
        /// Get Product based on the given category and price greater than 500 and calculate the average price
        /// </summary>
        /// <param name="category">Category of the product</param>
        private void Task1Queries(string category, decimal price)
        {
            //Query 1.1
            List<Product> filteredProductsByCategoryAndPrice = ProductList
            .Where(p => p.Category == category && p.Price > price)
            .ToList();
            var ListWithProductNameAndPrice = filteredProductsByCategoryAndPrice
            .Select(p => new { p.ProductName, p.Price })
            .ToList();

            //Query 1.2
            var orderListByDescending = ListWithProductNameAndPrice
                .OrderByDescending(p => p.Price)
                .ToList();

            //Query 1.3
            decimal averagePrice = orderListByDescending
                .Average(p => p.Price);

            Console.WriteLine($"\nAverage Price  is {averagePrice}");
        }
    }
}
