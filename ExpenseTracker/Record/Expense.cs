namespace ExpenseTracker.Record
{
    /// <summary>
    /// Implements <see cref="IRecord"/>
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
        /// Constructor for Expense
        /// </summary>
        /// <param name="amount">Amount of the expense</param>
        /// <param name="category">Category of the expense</param>
        public Expense(int amount, string category)
        {
            Amount = amount;
            Category = category;
        }

        /// <summary>
        /// Gives all the expense details
        /// </summary>
        /// <returns>returns string</returns>
        public override string ToString()
        {
            return $" {nameof(Expense)}  Category {Category} INR :{Amount}";
        }
    }
}