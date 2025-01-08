public class Developer : Employee
{
    
    public Developer(string name, decimal salary) : base(name, salary)
    {
        BonusPercentage = 30;
    }
    public override decimal calculateBonus()
    {
        return (decimal)(base.Salary * BonusPercentage) / 100;
    }
}

