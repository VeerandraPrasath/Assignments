
using ExpenseTracker.Record;

/// <summary>
/// <see cref="Income"/> implements <see cref="IRecord"/>
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

    /// <param name="Amount"> Amount of record </param>
    /// <param name="Category"> Category of record </param>
    public Income(int amount, string category)
    {

        Amount  = amount;   
        Category = category;    

    }
    /// <summary>
    /// Overriden <see cref="ToString"/> to get all the details
    /// </summary>
    /// <returns>string with all information</returns>
    /// 

    public override string ToString()
    {
        return $" {nameof(Income)}  Category {Category} INR :{Amount}";
    }
  
}

