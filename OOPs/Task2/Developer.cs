namespace OOPs.Task2
{

    /// <summary>
    /// Inherits Employee class
    /// </summary>
    public class Developer : Employee
    {
        /// <summary>
        /// Initialize the values
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="salary">Salary</param>
        public Developer(string name, decimal salary) : base(name, salary)
        {
            BonusPercentage = 50;
        }

        /// <summary>
        /// Calculate the bonus
        /// </summary>
        /// <returns>returns decimal value</returns>
        public override decimal calculateBonus()
        {
            return Salary * BonusPercentage / 100 ;
        }
    }
}