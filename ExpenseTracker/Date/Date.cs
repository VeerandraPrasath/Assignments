using ExpenseTracker.Record;

namespace ExpenseTracker.UserData
{

    /// <summary>
    /// <see cref="Date"/> holds the <see cref="CurrentDate"/> and <see cref="records"/>
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
        /// Initialize the date for <see cref="CurrentDate"/>
        /// </summary>
        /// <param name="date"></param>
        public Date(DateTime date)
        {
            CurrentDate = date;
            records = new List<IRecord>();
        }
    }
}