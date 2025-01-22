namespace ExpenseTracker.Record
{

    /// <summary>
    /// <see cref="IRecord"/> holds the details of date and the list of record
    /// </summary>
    public interface IRecord
    {
        /// <summary>
        /// Amount of the record
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Category of the record
        /// </summary>
        public string Category { get; set; }

    }
}