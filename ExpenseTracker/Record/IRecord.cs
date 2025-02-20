namespace ExpenseTracker.Record
{
    /// <summary>
    /// Stores the details of the record
    /// </summary>
    public interface IRecord
    {
        /// <summary>
        /// Amount of the record
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Category of the record
        /// </summary>
        public string Category { get; set; }
    }
}