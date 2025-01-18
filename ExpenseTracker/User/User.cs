// See https://aka.ms/new-console-template for more information
public class User
{
    public string Name { get; set; }
    public int CurrentBalance { get; set; }
    public int TotalIncome { get; set; }
    public int TotalExpense { get; set; }
    public List<Date> Dates { get; set; }
    public User(string name)
    {
            Name = name;
            Dates = new List<Date>();
           CurrentBalance = 0; 
           TotalIncome = 0;
        TotalExpense = 0;
    }
}

