
namespace Linq
{
    public  class Task1
    {
        public List<Product> productList {  get; set; }

        public Task1()
        {
            productList = new List<Product>() {
                new Product("Laptop",1,"Electronics",50000,1),
                new Product("Mobile",2,"Electronics",20000,3),
                new Product("Shirt",3,"Clothing",1000,5),
                new Product("Trousers",4,"Clothing",1500,7),
                new Product("Shoes",5,"Footwear",3000,8),
                new Product("Sneakers",6,"Footwear",2500,9)
            };
        }

        public void Run()
        {
            GetProductByCategory("Electronics");
           
        }

        public void GetProductByCategory(string category)
        {
            List<Product> filteredProduct = productList.Where(p => p.Category == category && p.Price > 500).ToList(); 

            var objectListOnlyWithNameAndPrice=filteredProduct.Select(p => new { p.ProductName, p.Price }).OrderByDescending((a)=>a.Price);
            decimal averageOfProductPrice=objectListOnlyWithNameAndPrice.Average(p=>p.Price);  

            Console.WriteLine($"Average Price of {category} is {averageOfProductPrice}");
        }   

            
    }
}
