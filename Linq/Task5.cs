
using Linq.Model;

namespace Linq
{
    /// <summary>
    /// Build custom linq using Fluent API pattern
    /// </summary>
    public class Task5
    {
        private QueryBuilder<Product> queryBuilder;

        /// <summary>
        /// Constructor for Task5
        /// </summary>
        public Task5()
        {
            queryBuilder = new QueryBuilder<Product>();
        }

        /// <summary>
        /// Perfom all the queries
        /// </summary>
        public void ExecuteTask5Queries()
        {
            Console.WriteLine("\nProducts with price greater than 100 and sorted by price and performed Inner join with Supplier using Supplier ID");
            Console.WriteLine("_________________________________________________________________________________________________________________");
            var ProductsPriceGreaterThan100 = queryBuilder
                .Filter(p => p.Price > 100)
                .SortBy(func => func.Price)
                .Join((p, s) => p.ProductId == s.ProductId)
                .Execute();

            foreach (var item in ProductsPriceGreaterThan100)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("\nProducts with price lesser than 100 and sorted by price");
            Console.WriteLine("__________________________________________________________");
            var ProductsPriceLessThan100 = queryBuilder
                .Filter(p => p.Price < 100)
                .Execute();

            foreach (var item in ProductsPriceLessThan100)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("\nProducts Name starts with S");
            Console.WriteLine("_____________________________");
            var ProductsNameStartWithA = queryBuilder
                .Filter(p => p.ProductName
                .StartsWith('S'))
                .SortBy(func => func.Price)
                .Execute();

            foreach (var item in ProductsNameStartWithA)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("\nProduct Name contains e");
            Console.WriteLine("_________________________");
            var ProductsNameContainsA = queryBuilder
                .Filter(p => p.ProductName.Contains('e'))
                .SortBy(func => func.Price)
                .Execute();

            foreach (var item in ProductsNameContainsA)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    /// <summary>
    /// Query Builder class to build custom linq queries
    /// </summary>
    public class QueryBuilder<T>
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
        /// Stores the QueryResult of the queries
        /// </summary>
        public IEnumerable<object> QueryResult { get; set; }

        /// <summary>
        /// Stores the Query and QueryType
        /// </summary>
        public List<Tuple<object, QUERYTYPE>> QueryList { get; set; } = new List<Tuple<object, QUERYTYPE>>();

        /// <summary>
        /// Constructor for QueryBuilder
        /// </summary>
        public QueryBuilder()
        {
            ProductList = new List<Product>() {
               new Product("Laptop",1,"Electronics",50000),
                new Product("Mobile",2,"Electronics",2000),
                new Product("Shirt",3,"Clothing",100),
                new Product("Trousers",4,"Clothing",10),
                new Product("Shoes",5,"Footwear",3000),
                new Product("Sneakers",6,"Footwear",25)
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
            QueryResult = ProductList;
        }

        /// <summary>
        /// Filter the products based on the condition
        /// </summary>
        /// <param name="func">Condition to perform filtering</param>
        /// <returns>Returns the current class instance</returns>
        public QueryBuilder<T> Filter(Func<Product, bool> func)
        {
            QueryList.Add(new Tuple<object, QUERYTYPE>(func, QUERYTYPE.FILTER));

            return this;
        }

        /// <summary>
        /// Sort the products based on the condition
        /// </summary>
        /// <param name="func">Condition to perform sorting</param>
        /// <returns>Returns the current class instance</returns>
        public QueryBuilder<T> SortBy(Func<Product, decimal> func)
        {
            QueryList.Add(new Tuple<object, QUERYTYPE>(func, QUERYTYPE.SORTBY));

            return this;
        }

        /// <summary>
        /// Join the products with suppliers based on the condition
        /// </summary>
        /// <param name="func">Condition to perform inner join</param>
        /// <returns>Returns the current class instance</returns>
        public QueryBuilder<T> Join(Func<Product, Supplier, bool> func)
        {
            QueryList.Add(new Tuple<object, QUERYTYPE>(func, QUERYTYPE.JOIN));

            return this;
        }

        /// <summary>
        /// Execute the query
        /// </summary>
        /// <returns>Returns the result</returns>
        public IEnumerable<object> Execute()
        {
            foreach (var query in QueryList)
            {
                if (query.Item2 == QUERYTYPE.FILTER)
                {
                    var source = (IEnumerable<Product>)QueryResult;
                    QueryResult = source
                        .Where((Func<Product, bool>)query.Item1)
                        .ToList();
                }
                else if (query.Item2 == QUERYTYPE.SORTBY)
                {
                    var source = (IEnumerable<Product>)QueryResult;
                    QueryResult = source
                        .OrderBy((Func<Product, decimal>)query.Item1)
                        .ToList();
                }
                else
                {
                    var source = (IEnumerable<Product>)QueryResult;
                    QueryResult = from p in source
                                  from s in SupplierList
                                  where ((Func<Product, Supplier, bool>)query.Item1)(p, s)
                                  select new { p.ProductId, p.ProductName, s.SupplierName, p.Price };
                }
            }
            QueryList.Clear();
            var result = QueryResult;
            QueryResult = ProductList;

            return result;
        }
    }

    public enum QUERYTYPE
    {
        SORTBY,
        FILTER,
        JOIN
    }
}

