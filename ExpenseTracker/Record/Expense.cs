// See https://aka.ms/new-console-template for more information
public class Expense :IRecord
{
    public int Amount { get; set; }
    public string Category { get; set; }

    public Expense()
    {
        
    }
    public Expense(User user, int amount, string category)
    {
        Amount = amount;
        Category = category;
        
        user.CurrentBalance -= amount;
        user.TotalExpense += amount;
    }
    public override string ToString()
    {
        return $" {nameof(Expense)}  Category {Category} INR :{Amount}";
    }
}

