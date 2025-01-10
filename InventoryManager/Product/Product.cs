public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }

    public Product(int id, string name, int quantity, int price)
    {
        Id = id;
        Name = name;
        Quantity = quantity;

        Price = price;
    }
    public override string ToString()
    {
        return $"ID :{Id}  Name : {Name} Quantity : {Quantity} Price : {Price} ";
    }
}

