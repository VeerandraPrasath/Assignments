using ExpenseTracker.ConsoleInteraction;
using ExpenseTracker.Controller;
using ExpenseTracker.Record;
using ExpenseTracker.UserData;

namespace ExpenseTracker.Manager
{
    /// <summary>
    /// Implements <see cref="IManageTracker"/>
    /// </summary>
    public class ManageTracker : IManageTracker
    {
        private User _currentUser;
        private readonly IUserInteraction _userInteraction;
        private readonly IRepositoryInteraction _repositoryInteraction;

        /// <summary>
        /// Constructor for ManageTracker
        /// </summary>
        public ManageTracker(IUserInteraction userInteraction, IRepositoryInteraction repositoryInteraction)
        {
            _userInteraction = userInteraction;
            _currentUser = null;
            _repositoryInteraction = repositoryInteraction;
        }

        public void CheckExisitingUser()
        {
            string userName = _userInteraction.GetStringInput("Username");
            _currentUser = _repositoryInteraction.IsUserPresent(userName);
            if (_currentUser != null)
            {
                Console.Clear();
            }
            _userInteraction.DisplayMessage("________________________________________________");
            string message = _currentUser != null ? $"          Logged into {userName}" : "Invalid User !";
            _userInteraction.DisplayMessage(message);
            _userInteraction.DisplayMessage("________________________________________________");
            if (_currentUser != null)
            {
                Login();
            }
        }

        public void Login()
        {
            bool Exit = false;
            while (!Exit)
            {
                _userInteraction.DisplayFeatures();
                string userChoice = _userInteraction.GetStringInput("Option ");
                switch (userChoice)
                {
                    case "1":
                        ViewRecords();
                        break;
                    case "2":
                        AddIncomeRecord();
                        break;
                    case "3":
                        AddExpenseRecord();
                        break;
                    case "4":
                        _userInteraction.DisplayMessage("________________________________________________");
                        _userInteraction.DisplayMessage("\nLogged out Successfully !\n");
                        _userInteraction.DisplayMessage("________________________________________________");
                        Exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Option !");
                        break;
                }
            }
        }

        /// <summary>
        /// Displays all records
        /// </summary>
        public void ViewRecords()
        {
            bool exit = false;
            if (_currentUser.Dates.Count == 0)
            {
                _userInteraction.DisplayMessage("___________________________________");
                _userInteraction.DisplayMessage("\n   No Transactions found ");
                _userInteraction.DisplayMessage("___________________________________");

                return;
            }
            while (!exit)
            {
                _userInteraction.DisplayMessage("\n[1] All records\n[2] Specific Date\n[3] Exit\n");
                string userOption = _userInteraction.GetStringInput("option");
                switch (userOption)
                {
                    case "1":
                        _userInteraction.DisplayMessage("--------------------------------------------");
                        _userInteraction.DisplayMessage("          ALL Transactions");
                        _userInteraction.DisplayMessage("--------------------------------------------");
                        _userInteraction.DisplayAllRecords(_currentUser.Dates);
                        _userInteraction.DisplayMessage("--------------------------------------------");
                        exit = true;
                        break;
                    case "2":
                        DateTime userInputDate = _userInteraction.GetDateInput("to view Transactions");
                        Date Date = _repositoryInteraction.IsDatePresent(userInputDate, _currentUser);
                        if (Date is not null)
                        {
                            _userInteraction.DisplayDateRecords(Date);
                        }
                        else
                        {
                            _userInteraction.DisplayMessage("________________________________________________");
                            _userInteraction.DisplayMessage($"No Transactions on date {userInputDate.ToString()}\n");
                            _userInteraction.DisplayMessage("________________________________________________");
                        }
                        exit = true;
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Option !\n");
                        break;
                }
            }
        }

        /// <summary>
        /// Adds income record details
        /// </summary>
        public void AddIncomeRecord()
        {
            DateTime userInputDate = _userInteraction.GetDateInput("to add Income record");
            Date IncomeDate = _repositoryInteraction.IsDatePresent(userInputDate, _currentUser);
            if (IncomeDate is null)
            {
                IncomeDate = new Date(userInputDate);
                _currentUser.Dates.Add(IncomeDate);
            }
            IRecord record = _userInteraction.GetIncomeDetails();
            _repositoryInteraction.AddRecord(record, IncomeDate, _currentUser);
            _userInteraction.DisplayMessage("Record added successfully !!!!!!");
        }

        /// <summary>
        /// Adds expense record details
        /// </summary>
        public void AddExpenseRecord()
        {
            DateTime userInputDate = _userInteraction.GetDateInput("to add Expense record");
            Date ExpenseDate = _repositoryInteraction.IsDatePresent(userInputDate, _currentUser);
            if (ExpenseDate is null)
            {
                ExpenseDate = new Date(userInputDate);
                _currentUser.Dates.Add(ExpenseDate);
            }
            IRecord record = _userInteraction.GetExpenseDetails();
            _repositoryInteraction.AddRecord(record, ExpenseDate, _currentUser);
            _userInteraction.DisplayMessage("Record added successfully !!!!!!");
        }
    }
}