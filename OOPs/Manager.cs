public class Manager:Employee
{
    
    public Manager(string name,decimal salary):base( name,salary)
    {
        BonusPercentage = 40;
    }
    public override decimal calculateBonus()
    {
        
        return (decimal)(base.Salary * BonusPercentage)/100;
    }
}

