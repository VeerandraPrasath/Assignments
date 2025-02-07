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
        /// Checks wheather User present
        /// </summary>
        /// <param name="username">User Name</param>
        /// <returns>returns User if found else null</returns>
        public User FindUserByUsername(string username);

        /// <summary>
        /// Creates new <see cref="User"/>
        /// </summary>
        /// <returns>returns true if <see cref="User"/> created else false</returns>
        public void CreateNewUser();

        /// <summary>
        /// Load all Data from file
        /// </summary>
        public void LoadFileData();

        /// <summary>
        /// Checks wheather Transaction presents
        /// </summary>
        /// <param name="date">Transaction to search</param>
        /// <param name="user"><see cref="User"/> to search</param>
        /// <returns>returns Transaction if present else null</returns>
        public Transaction FindTransactionByDate(DateTime date, User user);

        /// <summary>
        /// Adds <see cref="IRecord"/> on specific date
        /// </summary>
        /// <param name="record"><see cref="IRecord"/> to add</param>
        /// <param name="date">Transaction</param>
        public void AddRecord(IRecord record, Transaction date, User user);
    }
}