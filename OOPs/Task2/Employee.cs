namespace OOPs.Task2
{
    /// <summary>
    /// Stores Employee details
    /// </summary>
    public abstract class Employee
    {
        public int BonusPercentage { get; init; }

        protected string Name { get; set; }

        protected decimal Salary { get; set; }

        /// <summary>
        /// Initialize the values
        /// </summary>
        /// <param name="name"></param>
        /// <param name="salary"></param>
        protected Employee(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
        }

        /// <summary>
        /// Calculate the Bonus 
        /// </summary>
        /// <returns>returns decimal</returns>
        public abstract decimal calculateBonus();

        /// <summary>
        /// Display employee details
        /// </summary>
        public virtual void printDetails()
        {
            Console.WriteLine($"Details :\nName :{Name}\nSalary :{Salary}\nBonus:{calculateBonus()}");
        }
    }
}