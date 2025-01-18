// See https://aka.ms/new-console-template for more information
public class ManagerTracker : IManageTracker
{
    public User _user;
    
    private readonly IUserInteraction _userInteraction;
    private readonly IRepositoryInteraction _repositoryInteraction;
   
    public ManagerTracker(IUserInteraction userInteraction, IRepositoryInteraction repositoryInteraction)
    {
       
        _userInteraction = userInteraction;
        _user = null;
        _repositoryInteraction = repositoryInteraction;
    }
  

   
    public void CheckExisitingUser()
    {
        string userName = _userInteraction.stringAsInput("Username");
        _user=_repositoryInteraction.isUserPresent(userName);
        string message= _user != null ? $"Logged into {userName}  !" : "Invalid User !";
        _userInteraction.displayMessage(message);
        if (_user != null)
        {

            login();
            
        }


    }

     public  void login()
    {
       
        bool Exit = false;
        while (!Exit)
        {
            _userInteraction.displayFeatures();
           string userChoice= _userInteraction.stringAsInput("Option ");
            switch (userChoice)
            {
                case "v":
                case "V":
                    viewRecords();
                    break;
                case "i":
                case "I":
                    addIncomeRecord();
                    break;
                case "E":
                case "e":
                    addExpenseRecord();
                    break;
                case "M":
                case "m":
                    break;
                case "D":
                case "d":
                    break;
                case "F":
                case "f":
                    break;
                case "l":
                case "L":
                    Exit=true;
                    break;
                default:
                    Console.WriteLine("Invalid Option !");
                    break;

            }
        }
    }

    void viewRecords()
    {
        bool Exit = false;
        while (!Exit)
        {
            _userInteraction.displayMessage("[A]ll records\n[S]pecific Date\n[E]xit");
            string userOption = _userInteraction.stringAsInput("option");
            switch (userOption)
            {
                case "a":
                case "A":
                    _userInteraction.displayMessage("**** ALL Transactions ***");
                    _userInteraction.displayAllRecords(_user.Dates);
                    break;
                case "s":
                case "S":
                   DateTime userInputDate = _userInteraction.dateAsInput("to view Transactions");
                   Date Date = _repositoryInteraction.isDatePresent(userInputDate, _user);

                    if (Date is not null)
                    {
                        _userInteraction.displayRecordsOnSpecificDate(Date);    
                    }
                    else
                    {
                        _userInteraction.displayMessage($"No Transactions on date {userInputDate.ToString()}");

                    }
                    break;
                case "e":
                case "E":
                    Exit=true;
                    break;
                default:
                    Console.WriteLine("Invalid Option !");
                    break;


            }

        }

    }
    void addIncomeRecord()
    {
        DateTime userInputDate = _userInteraction.dateAsInput("to add Income record");
        Date IncomeDate = _repositoryInteraction.isDatePresent(userInputDate, _user);

        if (IncomeDate is not null)
        {
            IncomeDate.records.Add(_userInteraction.getIncomeDetails(_user));
        }
        else
        {
            var newDate = new Date(userInputDate);
            newDate.records.Add(_userInteraction.getIncomeDetails(_user));
            _user.Dates.Add(newDate);

        }
        _userInteraction.displayMessage("Record added successfully !!!!!!");
    }
    void addExpenseRecord()
    {
       DateTime userInputDate = _userInteraction.dateAsInput("to add Expense record");
        Date expenseDate = _repositoryInteraction.isDatePresent(userInputDate, _user);

        if (expenseDate is not null)
        {
            expenseDate.records.Add(_userInteraction.getExpenseDetails(_user));
        }
        else
        {
            var newDate = new Date(userInputDate);
            newDate.records.Add(_userInteraction.getExpenseDetails(_user));
            _user.Dates.Add(newDate);

        }
        _userInteraction.displayMessage("Record added successfully !!!!!!");


    }

}

