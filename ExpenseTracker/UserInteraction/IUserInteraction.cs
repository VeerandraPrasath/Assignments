/// <summary>
/// <see cref="IUserInteraction"/> handles the interaction with User
/// </summary>
public interface IUserInteraction
{
    /// <summary>
    /// <see cref="displayMessage(string)"/> prints the message
    /// </summary>
    /// <param name="message">message need to print</param>
    void displayMessage(string message);

    /// <summary>
    /// <see cref="stringAsInput(string)"/> get string as input
    /// </summary>
    /// <param name="message">message to be printed</param>
    /// <returns>returns string</returns>
    string stringAsInput(string message);

    /// <summary>
    /// <see cref="intAsInput(string)"/> get integer as input
    /// </summary>
    /// <param name="message">message to be printed</param>
    /// <returns>eturns integer</returns>
    int intAsInput(string message);

    /// <summary>
    /// <see cref="dateAsInput(string)"/> get dateTime as input
    /// </summary>
    /// <param name="message">message to be printed</param>
    /// <returns>returns the dateTime</returns>
    public DateTime dateAsInput(string message);

    /// <summary>
    /// <see cref="displayFeatures"/> prints the available features
    /// </summary>
    void displayFeatures();

    /// <summary>
    /// <see cref="getIncomeDetails(User)"/> get <see cref="Income"/> details
    /// </summary>
    /// <param name="user">On which <see cref="User"/></param>
    /// <returns>returns <see cref="Income"/></returns>
    Income getIncomeDetails(User user);

    /// <summary>
    /// <see cref="getExpenseDetails(User)"/> get <see cref="Expense"/> details
    /// </summary>
    /// <param name="user">On which <see cref="User"/></param>
    /// <returns>returns <see cref="Expense"/></returns>
    Expense getExpenseDetails(User user);

    /// <summary>
    /// <see cref="displayAllRecords(List{Date})"/> displays all the records
    /// </summary>
    /// <param name="dates">All <see cref="Date"/></param>
    public void displayAllRecords(List<Date> dates);

    /// <summary>
    /// <see cref="displayRecordsOnSpecificDate(Date)"/> display records based on specific date
    /// </summary>
    /// <param name="date">On which date</param>
    public void displayRecordsOnSpecificDate(Date date);
}

