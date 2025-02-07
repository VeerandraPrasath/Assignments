using ExpenseTracker.Record;

namespace ExpenseTracker.UserData
{
    /// <summary>
    /// Stores <see cref="TransactionDate"/> and <see cref="RecordList"/>
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Transaction of the RecordList
        /// </summary>
        public DateTime TransactionDate { get; set; }
        /// <summary>
        /// List of RecordList
        /// </summary>
        public List<IRecord> RecordList { get; set; }

        /// <summary>
        /// Constructor for Transaction
        /// </summary>
        /// <param name="date">Transaction and Time</param>
        public Transaction(DateTime date)
        {
            TransactionDate = date;
            RecordList = new List<IRecord>();
        }
    }
}