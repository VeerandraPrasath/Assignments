 public abstract  class Employee
  {
    public int BonusPercentage { get; init; }
    public string Name { get; set; }
    public decimal Salary { get; set; }
    protected Employee(string name ,decimal salary)
    {
       
        Name = name;
        Salary = salary;
    }

    public abstract decimal calculateBonus();
    public void printDetails()
    { 
        Console.WriteLine($"Details :\nName :{Name}\nSalary :{Salary}\nBonus:{calculateBonus()}");

    }

    }
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

