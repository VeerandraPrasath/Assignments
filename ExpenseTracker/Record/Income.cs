using ExpenseTracker.Record;

/// <summary>
/// Implements <see cref="IRecord"/>
/// </summary>
public class Income :IRecord
{
    /// <summary>
    /// Amount of the record
    /// </summary>
    public int Amount { get; set; }

    /// <summary>
    /// Category of the record
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// Constructor for Income
    /// </summary>
    /// <param name="amount">Amount of the income</param>
    /// <param name="category">Category of the income</param>
    public Income(int amount, string category)
    {
        Amount = amount;
        Category = category;
    }

    /// <summary>
    /// Gives all the income details
    /// </summary>
    /// <returns>returns string</returns>
    public override string ToString()
    {
        return $" {nameof(Income)}  Category {Category} INR :{Amount}";
    }
}