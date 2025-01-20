/// <summary>
/// Class inherit features of the Employee
/// </summary>
public class Developer : Employee
{
    /// <summary>
    /// Initialize the name and salary to the base Class Employee
    /// </summary>
    /// <param name="name"></param>
    /// <param name="salary"></param>
    public Developer(string name, decimal salary) : base(name, salary)
    {
        BonusPercentage = 50;
    }

    /// <summary>
    /// Calculate the bonus for Developer class
    /// </summary>
    /// <returns></returns>
    public override decimal calculateBonus()
    {
        return (decimal)(base.Salary * BonusPercentage) / 100;
    }
}

