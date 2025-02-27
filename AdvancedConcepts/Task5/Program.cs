namespace Task5
{
    public delegate int SortDelegate(Product p1, Product p2);

    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
              {
                new Product("Laptop", "Electronics", 999.99m),
                new Product("Chair", "Furniture", 49.99m),
                new Product("Coffee", "Groceries", 5.99m),
                new Product("Desk", "Furniture", 199.99m),
                new Product("Smartphone", "Electronics", 699.99m)
            };

            SortDelegate sortByName = SortByName;
            SortDelegate sortByCategory = SortByCategory;
            SortDelegate sortByPrice = SortByPrice;

            Console.WriteLine("Sorted by Name:");
            SortAndDisplay(sortByName, products);

            Console.WriteLine("Sorted by Category:");
            SortAndDisplay(sortByCategory, products);

            Console.WriteLine("Sorted by Price:");
            SortAndDisplay(sortByPrice, products);
            Console.ReadLine();
        }
        public static int SortByName(Product p1, Product p2)
        {
            return string.Compare(p1.Name, p2.Name);
        }

        public static int SortByCategory(Product p1, Product p2)
        {
            return string.Compare(p1.Category, p2.Category);
        }

        public static int SortByPrice(Product p1, Product p2)
        {
            return p1.Price.CompareTo(p2.Price);
        }

        public static void SortAndDisplay(SortDelegate sortMethod, List<Product> products)
        {
            products.Sort(new Comparison<Product>(sortMethod));

            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public Product(string name, string category, decimal price)
        {
            Name = name;
            Category = category;
            Price = price;
        }

        public override string ToString()
        {
            return $"Name : {Name},Category : {Category},Price : ${Price}";
        }
    }
}