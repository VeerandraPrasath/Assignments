/// <summary>
/// <see cref="Expense"/> implements <see cref="IRecord"/>
/// </summary>
public class Expense : IRecord
{
    public int Amount { get; set; }
    public string Category { get; set; }

    /// <summary>
    /// <see cref="Expense"/> initialize the <see cref="User"/> ,amount and category
    /// </summary>
    /// <param name="user">Shows which <see cref="User"/> </param>
    /// <param name="amount">Amount of the expense</param>
    /// <param name="category">On which category</param>
    public Expense(User user, int amount, string category)
    {
        Amount = amount;
        Category = category;

        user.CurrentBalance -= amount;
        user.TotalExpense += amount;
    }

    /// <summary>
    /// Overriden <see cref="ToString"/> to get all the details
    /// </summary>
    /// <returns>string with all information</returns>
    public override string ToString()
    {
        return $" {nameof(Expense)}  Category {Category} INR :{Amount}";
    }
}

