using ExpenseTracker.Record;
using ExpenseTracker.UserData;

namespace ExpenseTracker.ConsoleInteraction
{
    /// <summary>
    /// Handles interaction with User
    /// </summary>
    public interface IUserInteraction
    {
        /// <summary>
        /// Display message
        /// </summary>
        /// <param name="message">Message</param>
        public void DisplayMessage(string message);

        /// <summary>
        /// Gets string input
        /// </summary>
        /// <param name="message">Message</param>
        /// <returns>returns string</returns>
        public string GetStringInput(string message);

        /// <summary>
        /// <see cref="GetIntInput(string)"/> get integer as input
        /// </summary>
        /// <param name="message">message to be printed</param>
        /// <returns>returns integer</returns>
        public int GetIntInput(string message);

        /// <summary>
        /// Gets dateTime input
        /// </summary>
        /// <param name="message">Message</param>
        /// <returns>returns dateTime</returns>
        public DateTime GetDateInput(string message);

        /// <summary>
        /// Displays features
        /// </summary>
        public void DisplayMainMenu();

        /// <summary>
        /// Gets Income details
        /// </summary>
        /// <returns>returns <see cref="Income"/></returns>
        public Income GetIncomeDetails();

        /// <summary>
        /// Gets Expense details
        /// </summary>
        /// <returns>returns <see cref="Expense"/></returns>
        public Expense GetExpenseDetails();

        /// <summary>
        /// Displays all RecordList
        /// </summary>
        /// <param name="dates">List of Dates</param>
        public void DisplayAllRecords(List<Transaction> dates);

        /// <summary>
        /// Display RecordList on Transaction
        /// </summary>
        /// <param name="date">Transaction</param>
        public void DisplayRecordsByDate(Transaction date);
    }
}