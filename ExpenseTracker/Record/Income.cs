// See https://aka.ms/new-console-template for more information
public class Income :IRecord
{

    public int Amount { get; set; }
    public string Category { get; set; }

    public Income()
    {
            
    }
    public Income(User user,int amount,string category)
    {
        Amount = amount;    
        Category = category;
        user.CurrentBalance += amount;
        user.TotalIncome += amount; 
      

        

    }
    public override string ToString()
    {
        return $" {nameof(Income)}  Category {Category} INR :{Amount}";
    }
}

