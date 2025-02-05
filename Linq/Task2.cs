using ConsoleTables;

namespace Linq
{
    public class Task2
    {
       public List<Product> productList { get; set; }

        public List<Supplier> supplierList { get; set; }

        public Task2()
        {
            productList = new List<Product>() {
                new Product("Laptop",1,"Electronics",50000,1),
                new Product("Mobile",2,"Electronics",20000,3),
                new Product("Shirt",3,"Clothing",1000,5),
                new Product("Trousers",4,"Clothing",1500,7),
                new Product("Shoes",5,"Footwear",3000,8),
                new Product("Sneakers",6,"Footwear",2500,9)
            };
            supplierList = new List<Supplier>()
            {
                new Supplier("Lenova",1,1),
                new Supplier("Samsung",3,2),
                new Supplier("Levis",5,3),
                new Supplier("Jockey",7,4),
                new Supplier("Bata",8,6),
                new Supplier("Puma",9,5)
            };
        }

        public void GroupByCategory()
        {
            bool isFirst = false;
            var GroupByCategory=productList.GroupBy(x => x.Category);
            foreach(var category in GroupByCategory)
            {
                isFirst = true;
                Console.WriteLine($" Category {category.FirstOrDefault().Category} Count : {category.Count()}");
                Console.WriteLine("-------------------------------------------------");
                foreach (var item in category.OrderByDescending(x => x.Price))
                {
                    if (isFirst)
                    {

                        Console.WriteLine($"{item.ToString()} ------>  Most expensive Product");
                        isFirst = false;
                    }
                    else
                    {
                    Console.WriteLine(item.ToString());

                    }
                }
                Console.WriteLine("-------------------------------------------------");
            }
        }

        public void JoinWithProductId()
        {
            var joinObject = productList.Join(supplierList, p => p.ProductId, s => s.ProductId, (p, s) =>new  { p.ProductName ,s.SupplierName,s.SupplierId}).ToList();
            Console.WriteLine("Inner Join");
            Console.WriteLine("-------------------------------------------------");
            var table = new ConsoleTable("ProductName", "SupplierName", "SuplierId");
            foreach (var item in joinObject)
            {
                table.AddRow(item.ProductName,item.SupplierName,item.SupplierId);
            }
            Console.WriteLine(table);
        }
    }
}
