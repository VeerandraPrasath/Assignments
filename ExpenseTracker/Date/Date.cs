using ExpenseTracker.Record;

namespace ExpenseTracker.UserData
{
    /// <summary>
    /// Stores <see cref="CurrentDate"/> and <see cref="records"/>
    /// </summary>
    public class Date
    {
        /// <summary>
        /// Date of the records
        /// </summary>
        public DateTime CurrentDate { get; set; }
        /// <summary>
        /// List of records
        /// </summary>
        public List<IRecord> records { get; set; }

        /// <summary>
        /// Constructor for Date
        /// </summary>
        /// <param name="date">Date and Time</param>
        public Date(DateTime date)
        {
            CurrentDate = date;
            records = new List<IRecord>();
        }
    }
}