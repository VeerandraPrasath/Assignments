namespace ExpenseTracker.UserData
{
    /// <summary>
    /// Stores the User details
    /// </summary>
    public class User
    {
        /// <summary>
        /// Name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Current Balance of the user
        /// </summary>
        public decimal CurrentBalance { get; set; }

        /// <summary>
        /// Total income of the user
        /// </summary>
        public decimal TotalIncome { get; set; }

        /// <summary>
        /// Total expense of the user
        /// </summary>
        public decimal TotalExpense { get; set; }

        /// <summary>
        /// List of dates
        /// </summary>
        public List<Transaction> TransactionList { get; set; }

        /// <summary>
        /// Constructor for User
        /// </summary>
        /// <param name="name">Name of the user</param>
        public User(string name)
        {
            Name = name;
            TransactionList = new List<Transaction>();
        }
    }
}