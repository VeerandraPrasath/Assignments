/// <summary>
/// Class inherit the features of the Employee Class
/// </summary>
public class Manager : Employee
{
    /// <summary>
    /// Constructor initialize the name and salary of Employee
    /// </summary>
    /// <param name="name"></param>
    /// <param name="salary"></param>
    public Manager(string name, decimal salary) : base(name, salary)
    {
        BonusPercentage = 40;
    }

    /// <summary>
    /// Method calculate the Bonus 
    /// </summary>
    /// <returns></returns>
    public override decimal calculateBonus()
    {

        return (decimal)(base.Salary * BonusPercentage) / 100;
    }
}

