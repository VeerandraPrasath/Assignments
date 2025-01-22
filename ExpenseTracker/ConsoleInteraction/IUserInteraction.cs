using ExpenseTracker.Record;
using ExpenseTracker.UserData;

namespace ExpenseTracker.ConsoleInteraction
{

    /// <summary>
    /// <see cref="IUserInteraction"/> handles the interaction with User
    /// </summary>
    public interface IUserInteraction
    {
        /// <summary>
        /// <see cref="DisplayMessage(string)"/> prints the message
        /// </summary>
        /// <param name="message">message need to print</param>
        void DisplayMessage(string message);

        /// <summary>
        /// <see cref="StringAsInput(string)"/> get string as input
        /// </summary>
        /// <param name="message">message to be printed</param>
        /// <returns>returns string</returns>
        string StringAsInput(string message);

        /// <summary>
        /// <see cref="IntAsInput(string)"/> get integer as input
        /// </summary>
        /// <param name="message">message to be printed</param>
        /// <returns>eturns integer</returns>
        int IntAsInput(string message);

        /// <summary>
        /// <see cref="DateAsInput(string)"/> get dateTime as input
        /// </summary>
        /// <param name="message">message to be printed</param>
        /// <returns>returns the dateTime</returns>
        public DateTime DateAsInput(string message);

        /// <summary>
        /// <see cref="DisplayFeatures"/> prints the available features
        /// </summary>
        void DisplayFeatures();

        /// <summary>
        /// <see cref="getIncomeDetails(User)"/> get <see cref="Income"/> details
        /// </summary>
        /// <param name="user">On which <see cref="User"/></param>
        /// <returns>returns <see cref="Income"/></returns>
        Income GetIncomeDetails();

        /// <summary>
        /// <see cref="getExpenseDetails(User)"/> get <see cref="Expense"/> details
        /// </summary>
        /// <param name="user">On which <see cref="User"/></param>
        /// <returns>returns <see cref="Expense"/></returns>
        Expense GetExpenseDetails();

        /// <summary>
        /// <see cref="DisplayAllRecords(List{Date})"/> displays all the records
        /// </summary>
        /// <param name="dates">All <see cref="Date"/></param>
        public void DisplayAllRecords(List<Date> dates);

        /// <summary>
        /// <see cref="DisplayRecordsOnSpecificDate(Date)"/> display records based on specific date
        /// </summary>
        /// <param name="date">On which date</param>
        public void DisplayRecordsOnSpecificDate(Date date);
    }
}