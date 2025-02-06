
namespace Linq
{
    /// <summary>
    /// Build custom linq using Fluent API pattern
    /// </summary>
    public class Task5
    {
        private QueryBuilder queryBuilder;

        /// <summary>
        /// Constructor for Task5
        /// </summary>
        public Task5()
        {
            queryBuilder = new QueryBuilder();
        }

        /// <summary>
        /// Perfom all the queries
        /// </summary>
        public void Run()
        {
            Console.WriteLine("\nProducts with price greater than 100 and sorted by price and performed Inner join with Supplier using Supplier ID");
            Console.WriteLine("_________________________________________________________________________________________________________________");
            var ProductsPriceGreaterThan100 = queryBuilder.Filter(p => p.Price > 100).SortBy(func => func.Price).Join((p, s) => p.SupplierId == s.SupplierId).Execute();
            foreach (var item in ProductsPriceGreaterThan100)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("\nProducts with price lesser than 100 and sorted by price");
            Console.WriteLine("__________________________________________________________");
            var ProductsPriceLessThan100 = queryBuilder.Filter(p => p.Price < 100).Execute();
            foreach (var item in ProductsPriceLessThan100)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("\nProducts Name starts with S");
            Console.WriteLine("_____________________________");
            var ProductsNameStartWithA = queryBuilder.Filter(p => p.ProductName.StartsWith('S')).SortBy(func => func.Price).Execute();
            foreach (var item in ProductsNameStartWithA)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("\nProduct Name contains e");
            Console.WriteLine("_________________________");
            var ProductsNameContainsA = queryBuilder.Filter(p => p.ProductName.Contains('e')).SortBy(func => func.Price).Execute();
            foreach (var item in ProductsNameContainsA)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    /// <summary>
    /// Query Builder class to build custom linq queries
    /// </summary>
    public class QueryBuilder
    {
        /// <summary>
        /// Stores the list of products
        /// </summary>
        public List<Product> ProductList { get; set; }

        /// <summary>
        /// Stores the list of suppliers
        /// </summary>
        public List<Supplier> SupplierList { get; set; }

        /// <summary>
        /// Stores the Result of the queries
        /// </summary>
        public IEnumerable<object> Result { get; set; }

        /// <summary>
        /// Constructor for QueryBuilder
        /// </summary>
        public QueryBuilder()
        {
            ProductList = new List<Product>() {
               new Product("Laptop",1,"Electronics",50000,1),
                new Product("Mobile",2,"Electronics",2000,3),
                new Product("Shirt",3,"Clothing",100,5),
                new Product("Trousers",4,"Clothing",10,7),
                new Product("Shoes",5,"Footwear",3000,8),
                new Product("Sneakers",6,"Footwear",25,9)
            };

            SupplierList = new List<Supplier>()
            {
                new Supplier("Lenova",1,1),
                new Supplier("Samsung",3,2),
                new Supplier("Levis",5,3),
                new Supplier("Jockey",7,4),
                new Supplier("Bata",8,6),
                new Supplier("Puma",9,5)
            };
            Result = ProductList;
        }

        /// <summary>
        /// Filter the products based on the condition
        /// </summary>
        /// <param name="func">Condition to perform filtering</param>
        /// <returns>Returns the current class instance</returns>
        public QueryBuilder Filter(Func<Product, bool> func)
        {
            var source = Result as IEnumerable<Product>;
            Result = source.Where(func);

            return this;
        }

        /// <summary>
        /// Sort the products based on the condition
        /// </summary>
        /// <param name="func">Condition to perform sorting</param>
        /// <returns>Returns the current class instance</returns>
        public QueryBuilder SortBy(Func<Product, decimal> func)
        {
            var source = (IEnumerable<Product>)Result;
            Result = source.OrderBy(func);

            return this;
        }

        /// <summary>
        /// Join the products with suppliers based on the condition
        /// </summary>
        /// <param name="func">Condition to perform inner join</param>
        /// <returns>Returns the current class instance</returns>
        public QueryBuilder Join(Func<Product, Supplier, bool> func)
        {
            var source = Result as IEnumerable<Product>;
            Result = from p in source from s in SupplierList where func(p, s) select new { p.ProductId, p.ProductName, s.SupplierName, p.Price };

            return this;
        }

        /// <summary>
        /// Execute the query
        /// </summary>
        /// <returns>Returns the result</returns>
        public IEnumerable<object> Execute()
        {
            var temp = Result;
            Result = ProductList;

            return temp;
        }
    }
}
