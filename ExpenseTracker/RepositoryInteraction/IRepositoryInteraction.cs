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
        public User IsUserPresent(string username);

        /// <summary>
        /// Creates new <see cref="User"/>
        /// </summary>
        /// <returns>returns true if <see cref="User"/> created else false</returns>
        public bool CreateNewUser();

        /// <summary>
        /// Load all Data from file
        /// </summary>
        public void LoadAllData();

        /// <summary>
        /// Checks wheather Date presents
        /// </summary>
        /// <param name="date">Date to search</param>
        /// <param name="user"><see cref="User"/> to search</param>
        /// <returns>returns Date if present else null</returns>
        public Date IsDatePresent(DateTime date, User user);

        /// <summary>
        /// Adds <see cref="IRecord"/> on specific date
        /// </summary>
        /// <param name="record"><see cref="IRecord"/> to add</param>
        /// <param name="date">Date</param>
        public void AddRecord(IRecord record, Date date, User user);
    }
}