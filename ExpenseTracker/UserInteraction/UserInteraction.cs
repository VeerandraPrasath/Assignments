// See https://aka.ms/new-console-template for more information
public class UserInteraction : IUserInteraction
{
    public string stringAsInput(string message)
    {
        string? userInput;


        do
        {
            Console.WriteLine($"Enter {message} :");
            userInput = Console.ReadLine();
            if (userInput == "" || userInput is null)
            {
                Console.WriteLine("******Input should not be null ****");
            }
        } while (userInput == "" || userInput is null);
        return userInput;
    }
    public int intAsInput(string message)
    {
        bool isValidDigit = false;
        int intValue;
        do
        {

            isValidDigit = int.TryParse(stringAsInput(message), out intValue);
            if (!isValidDigit)
            {
                Console.WriteLine("***Input should be number***");
            }
        } while (!isValidDigit);
        return intValue;
    }
    public DateTime dateAsInput(string message)
    {
        bool isValidDate=false;
        DateTime date;
        do
        {

        string userInput = stringAsInput($"date(format: yyyy - MM - dd) {message}");

        isValidDate = DateTime.TryParse(userInput, out date);
        if (!isValidDate)
        {
            Console.WriteLine("Invalid date format. Please try again.");
        }

        }while(!isValidDate);
        return date;
    }
   public  void displayMessage(string message)
    {
        Console.WriteLine(message);
    }
    public void displayFeatures()
    {
        Console.WriteLine("[V]iew Records \nAdd [I]ncome Record \nAdd [E]xpense Record \n[M]odify Record \n[D]elete \n[F]inancial summary\n[L]og out");
    }
   public Income getIncomeDetails(User user)
    {

        int amount = intAsInput("amount");
        string category = stringAsInput("the category ");
        return new Income(user, amount, category);
    }
    public Expense getExpenseDetails(User user)
    {

        int amount = intAsInput("amount");
        string category = stringAsInput("the category ");
        return new Expense(user, amount, category);
    }
    public void displayAllRecords(List<Date> dates)
    {
        int count = 1;
        if (dates.Count == 0)
        {
            Console.WriteLine("No Transactions !!!");
            return;
        }
        foreach (Date date in dates)
        {
            foreach(IRecord record in date.records)
            {
                Console.WriteLine($"{count}.{date.CurrentDate.ToString()} { record}");
                count++;
            }
        }
    }
    public void displayRecordsOnSpecificDate(Date date)
    {
        int count = 1;
        if (date.records.Count == 0)
        {
            Console.WriteLine("No Transactions !!!");
            return;
        }
        Console.WriteLine($"Transactions on {date.CurrentDate.ToString()}");
        foreach (IRecord record in date.records )
        {
            Console.WriteLine($"{count}.{date.CurrentDate.ToString()} {record}");
            count++;
        }
    }
}

