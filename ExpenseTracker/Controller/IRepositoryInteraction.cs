using ExpenseTracker.Record;
using ExpenseTracker.UserData;

namespace ExpenseTracker.Controller
{
    /// <summary>
    /// Handles interaction with repository
    /// </summary>
    public interface IRepositoryInteraction
    {
        /// <summary>
        /// Checks wheather User present or not
        /// </summary>
        /// <param name="username">User Name</param>
        /// <returns>returns User if found else null</returns>
        public User FindByUsername(string username);

        /// <summary>
        /// Creates new <see cref="User"/>
        /// </summary>
        /// <returns>returns true if <see cref="User"/> created else false</returns>
        public void CreateNewUser();

        /// <summary>
        /// Load all Data from file
        /// </summary>
        public void LoadData();

        /// <summary>
        /// Checks wheather Date presents
        /// </summary>
        /// <param name="transactionDate">Date to search</param>
        /// <param name="user"><see cref="User"/> to search</param>
        /// <returns>returns Date if present else null</returns>
        public Transaction FindByTransactionDate(DateTime transactionDate, User user);

        /// <summary>
        /// Deletes exisiting <see cref="IRecord"/>
        /// </summary>
        /// <param name="recordList">List of <see cref="IRecord"/></param>
        /// <param name="index">Index of the <see cref="IRecord"/></param>
        /// <param name="user">Current User</param>
        /// <returns>returns true if record deleted else false</returns>
        public void DeleteRecord(List<IRecord> recordList, int index, User user);

        /// <summary>
        /// Adds <see cref="IRecord"/> on specific transactionDate
        /// </summary>
        /// <param name="record"><see cref="IRecord"/> to add</param>
        /// <param name="date">Date</param>
        public void AddRecord(IRecord record, Transaction date, User user);

        /// <summary>
        /// Updates existing <see cref="IRecord"/>
        /// </summary>
        /// <param name="newRecord"><see cref="IRecord"/> to update</param>
        /// <param name="oldRecord"><see cref="IRecord"/> to change</param>
        /// <param name="user">Current <see cref="User"/></param>
        public void UpdateRecord(IRecord newRecord, IRecord oldRecord, User user);

        /// <summary>
        /// Writes content to file
        /// </summary>
        public void WriteToFile();
    }
}