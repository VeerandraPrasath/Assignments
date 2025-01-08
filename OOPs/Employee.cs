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

