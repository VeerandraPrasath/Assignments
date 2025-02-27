using ExpenseTracker.Record;
using ExpenseTracker.UserData;

namespace ExpenseTracker.UserInteraction
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
        public string GetValidString(string message);

        /// <summary>
        /// <see cref="GetValidInt(string)"/> get integer as input
        /// </summary>
        /// <param name="message">message to be printed</param>
        /// <returns>returns integer</returns>
        public int GetValidInt(string message);

        /// <summary>
        /// Gets dateTime input
        /// </summary>
        /// <param name="message">Message</param>
        /// <returns>returns dateTime</returns>
        public DateTime GetValidDate(string message);

        /// <summary>
        /// Displays main menu
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
        /// <param name="transactionList">List of TransactionList</param>
        public void DisplayAllRecords(List<Transaction> transactionList);

        /// <summary>
        /// Display Records on given transaction
        /// </summary>
        /// <param name="transaction">Transaction</param>
        public void DisplayRecordsByDate(Transaction transaction);
    }
}