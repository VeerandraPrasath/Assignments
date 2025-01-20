/// <summary>
/// <see cref="User"/> holds the details
/// </summary>
public class User
{
    public string Name { get; set; }
    public int CurrentBalance { get; set; }
    public int TotalIncome { get; set; }
    public int TotalExpense { get; set; }
    public List<Date> Dates { get; set; }

    /// <summary>
    /// <see cref="User"/> initialize the name
    /// </summary>
    /// <param name="name"></param>
    public User(string name)
    {
        Name = name;
        Dates = new List<Date>();
        CurrentBalance = 0;
        TotalIncome = 0;
        TotalExpense = 0;
    }
}

