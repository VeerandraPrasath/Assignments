// See https://aka.ms/new-console-template for more information
public interface IUserInteraction
{
    void displayMessage(string message);

    string stringAsInput(string message);
    int intAsInput(string message);

    public DateTime dateAsInput(string message);

    void displayFeatures();

    Income getIncomeDetails(User user);
   Expense getExpenseDetails(User user);
    public void displayAllRecords(List<Date> dates);
    public void displayRecordsOnSpecificDate(Date date);
}

