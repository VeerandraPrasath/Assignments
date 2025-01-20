/// <summary>
/// <see cref="Income"/> implements <see cref="IRecord"/>
/// </summary>
public class Income : IRecord
{

    public int Amount { get; set; }
    public string Category { get; set; }

    /// <summary>
    /// <see cref="Income"/> initialize the <see cref="User"/> ,amount and category
    /// </summary>
    /// <param name="user">Which <see cref="User"/></param>
    /// <param name="amount">Amount to be added</param>
    /// <param name="category">On which category</param>
    public Income(User user, int amount, string category)
    {
        Amount = amount;
        Category = category;
        user.CurrentBalance += amount;
        user.TotalIncome += amount;
    }

    /// <summary>
    /// Overriden <see cref="ToString"/> to get all the details
    /// </summary>
    /// <returns>string with all information</returns>
    public override string ToString()
    {
        return $" {nameof(Income)}  Category {Category} INR :{Amount}";
    }
}

