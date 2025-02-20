using Linq.Model;

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
                 new Product("Laptop",1,"Electronics",50000),
                new Product("Mobile",2,"Electronics",20000),
                new Product("Shirt",3,"Clothing",1000),
                new Product("Trousers",4,"Clothing",1500),
                new Product("Shoes",5,"Footwear",3000),
                new Product("Sneakers",6,"Footwear",2500),
                new Product("Headphones",7,"Electronics",1500),
                new Product("Psychology of money",8,"Books",500),
                new Product("T-Shirt",9,"Clothing",500),
                new Product("Rich Dad ,Poor Dad",10,"Books",2000),
                new Product("Sandals",11,"Footwear",1000)
            };
        }

        /// <summary>
        /// Initialize the methods
        /// </summary>
        public void ExecuteTask4Queries()
        {
            //Query 4.1
            GetProductByCategoryAndOrderByDescendingBasedOnPrice("Books");
            //Query 4.2
            OptimalSolution("Books");
        }

        private void GetProductByCategoryAndOrderByDescendingBasedOnPrice(string category)
        {
            Console.WriteLine($"\nProducts in {category} Category Ordered by  Descending  based on Product Price\n");
            List<Product> OrderBooksByPrice = ProductList
                          .Where(p => p.Category == category)
                          .OrderByDescending(x => x.Price)
                          .ToList();
            OrderBooksByPrice
            .ForEach(p => Console.WriteLine(p));
        }

        private void OptimalSolution(string category)
        {
            Console.WriteLine($"\nProducts in {category} Category Ordered by  Descending  based on Product Price in optimal way\n");
            List<Product> OrderBooksByPrice = ProductList
                          .AsParallel()
                          .Where(p => p.Category == category)
                          .OrderByDescending(x => x.Price)
                          .ToList();
            OrderBooksByPrice
           .ForEach(p => Console.WriteLine(p));
        }
    }
}
