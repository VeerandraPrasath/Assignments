using ConsoleTables;
using Linq.Model;

namespace Linq
{
    /// <summary>
    /// Group products by Category and Perform inner join between Products and Suppliers based on the product Id
    /// </summary>
    public class Task2
    {
        /// <summary>
        /// Stores list of Product
        /// </summary>
        public List<Product> ProductList { get; set; }

        /// <summary>
        /// Stores list of Supplier
        /// </summary>
        public List<Supplier> SupplierList { get; set; }

        /// <summary>
        /// Constructor for Task2
        /// </summary>
        public Task2()
        {
            ProductList = new List<Product>() {
                new Product("Laptop",1,"Electronics",50000),
                new Product("Mobile",2,"Electronics",20000),
                new Product("Shirt",3,"Clothing",1000),
                new Product("Trousers",4,"Clothing",1500),
                new Product("Shoes",5,"Footwear",3000),
                new Product("Sneakers",6,"Footwear",2500)
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
        }

        /// <summary>
        /// Initialize all the methods
        /// </summary>
        public void ExecuteTask2Queries()
        {
            //Query 2.1
            GroupByCategory();
            //Query 2.2
            JoinWithProductId();
        }

        /// <summary>
        /// Group the Product list based on Category
        /// </summary>
        private void GroupByCategory()
        {
            var GroupByCategory = ProductList
                .GroupBy(x => x.Category);
            foreach (var category in GroupByCategory)
            {
                string expensiveProduct = category
                    .Where(c => c.Price == category.Max(p => p.Price))
                    .FirstOrDefault()
                    .ProductName;
                Console.WriteLine($" Category {category.FirstOrDefault().Category}\n Count : {category.Count()}\n MostExpensive Product :{expensiveProduct}");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Products in sorted order");
                Console.WriteLine("-------------------------------------------------");
                foreach (var item in category.OrderBy(x => x.Price))
                {
                    Console.WriteLine(item.ToString());
                }
                Console.WriteLine("-------------------------------------------------");
            }
        }

        /// <summary>
        /// Perform inner join between Product list and Supplier list based on Product Id
        /// </summary>
        private void JoinWithProductId()
        {
            var joinObject = ProductList
                .Join(SupplierList, p => p.ProductId, s => s.ProductId, (p, s) => new { p.ProductName, s.SupplierName, s.SupplierId })
                .ToList();
            Console.WriteLine("Performed Inner Join between Product List and Supplier List using the Product Id");
            Console.WriteLine("-------------------------------------------------");
            var table = new ConsoleTable("ProductName", "SupplierName", "SuplierId");
            foreach (var item in joinObject)
            {
                table.AddRow(item.ProductName, item.SupplierName, item.SupplierId);
            }
            Console.WriteLine(table);
        }
    }
}
