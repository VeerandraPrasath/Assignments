
namespace Linq
{
    public class Product
    {
        public string ProductName { get; set; }    
        public int ProductId { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public int SupplierId { get; set; }

        public Product(string name,int id,string category,decimal price,int suppilerId)
        {
            ProductName = name;
            ProductId = id;
            Category = category;
            Price = price;
            SupplierId = suppilerId;
        }

        public override string ToString()
        {
            return $"Name : {ProductName}  ProductId : {ProductId} Price  : {Price}  Category : {Category}";
        }
    }
}
