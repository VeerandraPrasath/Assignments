namespace ExpenseTracker.Record
{

    /// <summary>
    /// <see cref="Expense"/> implements <see cref="IRecord"/>
    /// </summary>
    public class Expense : IRecord
    {
        /// <summary>
        /// Amount of the record
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Category of the record
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// <see cref="Expense"/> initialize the <see cref="User"/> ,amount and category
        /// </summary>
        /// <param name="amount">Amount of the expense</param>
        /// <param name="category">On which category</param>
        public Expense(int amount, string category)
        {
            Amount = amount;
            Category = category;
        }

        /// <summary>
        /// Overriden <see cref="ToString"/> to get all the details
        /// </summary>
        /// <returns>string with all information</returns>
        public override string ToString()
        {
            return $" {nameof(Expense)}  Category {Category} INR :{Amount}";
        }
    }
}