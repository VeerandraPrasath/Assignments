/// <summary>
/// Abstract Class with common properties of employee
/// </summary>
public abstract class Employee
{
    public int BonusPercentage { get; init; }
    protected string Name { get; set; }
    protected decimal Salary { get; set; }

    /// <summary>
    /// Constructor initialize the name and salary of the Employee
    /// </summary>
    /// <param name="name"></param>
    /// <param name="salary"></param>
    protected Employee(string name, decimal salary)
    {

        Name = name;
        Salary = salary;
    }

    /// <summary>
    /// Abstract method that calculate the Bonus 
    /// </summary>
    /// <returns></returns>
    public abstract decimal calculateBonus();

    /// <summary>
    /// Method prints the Details of the Employee
    /// </summary>
    public void printDetails()
    {
        Console.WriteLine($"Details :\nName :{Name}\nSalary :{Salary}\nBonus:{calculateBonus()}");

    }

}

