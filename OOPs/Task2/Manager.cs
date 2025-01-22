namespace OOPs.Task2
{

    /// <summary>
    /// Inherits  Employee Class
    /// </summary>
    public class Manager : Employee
    {
        /// <summary>
        /// Initialize the information
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="salary">Salary</param>
        public Manager(string name, decimal salary) : base(name, salary)
        {
            BonusPercentage = 40;
        }

        /// <summary>
        /// Calculate the Bonus 
        /// </summary>
        /// <returns>returns decimal value</returns>
        public override decimal calculateBonus()
        {
            return Salary * BonusPercentage / 100;
        }

        /// <summary>
        /// Display all details
        /// </summary>
        public override void printDetails()
        {
            Console.WriteLine($"Name :{Name}\nPosition :{nameof(Manager)}\nSalary :{Salary}\nBonus:{calculateBonus()}");

        }
    }
}