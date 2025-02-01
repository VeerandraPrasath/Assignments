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
        public ManageTracker(IUserInteraction userInteraction, IRepositoryInteraction repositoryInteraction,User user)
        {
            _userInteraction = userInteraction;
            _currentUser = user;
            _repositoryInteraction = repositoryInteraction;
        }

        public void CheckExisitingUser()
        {
            string userName = _userInteraction.GetStringInput("Username");
            _currentUser = _repositoryInteraction.IsUserPresent(userName);
            if (_currentUser != null)
            {
                //Console.Clear();
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
                        _repositoryInteraction.WriteToFile();
                        break;
                    case "3":
                        AddExpenseRecord();
                        _repositoryInteraction.WriteToFile();
                        break;
                    case "4":
                        EditRecord();
                        _repositoryInteraction.WriteToFile();
                        break;
                    case "5":
                        DeleteRecordOnDate();
                        _repositoryInteraction.WriteToFile();
                        break;
                    case "6":
                        FinancialSummary();
                        break;
                    case "7":
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

        /// <summary>
        /// Deletes record based on Date
        /// </summary>
        public void DeleteRecordOnDate()
        {
            if (_currentUser.Dates.Count == 0)
            {
                _userInteraction.DisplayMessage("___________________________________");
                _userInteraction.DisplayMessage("\n   No Transactions found ");
                _userInteraction.DisplayMessage("___________________________________");

                return;
            }
            DateTime userInputDate = _userInteraction.GetDateInput("to add Income record");
            Date IncomeDate = _repositoryInteraction.IsDatePresent(userInputDate, _currentUser);
            if (IncomeDate is not null)
            {
                _userInteraction.DisplayDateRecords(IncomeDate);
                int userOption = _userInteraction.GetIntInput("Index of Record to delete");
                if (userOption <= IncomeDate.records.Count && userOption > 0)
                {
                    _repositoryInteraction.DeleteRecord(IncomeDate.records, userOption - 1, _currentUser);
                    _userInteraction.DisplayMessage("Record Deleted Sucessfully !");
                }
                else
                {
                    _userInteraction.DisplayMessage("Invalid Transaction ID");
                }
            }
            else
            {
                _userInteraction.DisplayMessage($"No Transactions on date {userInputDate.ToString()}");
            }
        }

        /// <summary>
        /// Displays summary of <see cref="User"/>
        /// </summary>
        public void FinancialSummary()
        {
            bool Exit = false;
            if (_currentUser.Dates.Count == 0)
            {
                _userInteraction.DisplayMessage("___________________________________");
                _userInteraction.DisplayMessage("\n   No Transactions found ");
                _userInteraction.DisplayMessage("___________________________________");

                return;
            }
            while (!Exit)
            {
                _userInteraction.DisplayMessage("[1] OverAll Summary\n[2] Specific Summary\n[3] Exit");
                string userOption = _userInteraction.GetStringInput("option");
                switch (userOption)
                {
                    case "1":
                        _userInteraction.DisplayMessage("--------------------------------------------");
                        _userInteraction.DisplayMessage($"     OverAll Summary of {_currentUser.Name}");
                        _userInteraction.DisplayMessage("--------------------------------------------");
                        _userInteraction.DisplayMessage($"Balance       : {_currentUser.CurrentBalance}\n");
                        _userInteraction.DisplayMessage($"Total income  : {_currentUser.TotalIncome}\n");
                        _userInteraction.DisplayMessage($"Total expense : {_currentUser.TotalExpense}\n");
                        _userInteraction.DisplayMessage("--------------------------------------------");
                        Exit = true;
                        break;
                    case "2":
                        DateTime userInputDate = _userInteraction.GetDateInput("to view Summary");
                        Date Date = _repositoryInteraction.IsDatePresent(userInputDate, _currentUser);
                        if (Date is not null)
                        {
                            CalculateSummaryOnDate(Date);
                        }
                        else
                        {
                            _userInteraction.DisplayMessage($"No Transactions on date {userInputDate.ToString()}");
                        }
                        Exit = true;
                        break;
                    case "3":
                        Exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Option !");
                        break;
                }
            }
        }

        /// <summary>
        /// CalculateS summary on <see cref="Date.CurrentDate"/>
        /// </summary>
        /// <param name="date">Date of the record</param>
        public void CalculateSummaryOnDate(Date date)
        {
            int TotalIncome = 0;
            int TotalExpense = 0;
            foreach (IRecord record in date.records)
            {
                if (record is Income)
                {
                    TotalIncome += record.Amount;
                }
                else
                {
                    TotalExpense += record.Amount;
                }
            }
            _userInteraction.DisplayMessage("--------------------------------------------");
            _userInteraction.DisplayMessage($"    Summary on {date.CurrentDate}");
            _userInteraction.DisplayMessage("--------------------------------------------");
            _userInteraction.DisplayMessage($"Net Balance  : {TotalIncome - TotalExpense}\n");
            _userInteraction.DisplayMessage($"TotalIncome  : {TotalIncome}\n");
            _userInteraction.DisplayMessage($"TotalExpense : {TotalExpense}\n");
            _userInteraction.DisplayMessage("--------------------------------------------");
        }

        /// <summary>
        /// Modify record details
        /// </summary>
        public void EditRecord()
        {
            if (_currentUser.Dates.Count == 0)
            {
                _userInteraction.DisplayMessage("___________________________________");
                _userInteraction.DisplayMessage("\n   No Transactions found ");
                _userInteraction.DisplayMessage("___________________________________");

                return;
            }
            DateTime userInputDate = _userInteraction.GetDateInput("to add edit record");
            Date editDate = _repositoryInteraction.IsDatePresent(userInputDate, _currentUser);
            if (editDate is not null)
            {
                if (editDate.records.Count == 0 || editDate.records is null)
                {
                    _userInteraction.DisplayMessage($"\nNo Transactions on {editDate.ToString()}\n");
                }
                _userInteraction.DisplayDateRecords(editDate);
                int userOption = _userInteraction.GetIntInput("Index of Record to edit");
                if (userOption <= editDate.records.Count && userOption > 0)
                {
                    IRecord record = editDate.records[userOption - 1];
                    IRecord updateRecord;
                    if (record is Income)
                    {
                        updateRecord = _userInteraction.GetIncomeDetails();
                    }
                    else
                    {
                        updateRecord = _userInteraction.GetExpenseDetails();
                    }
                    _repositoryInteraction.UpdateRecord(updateRecord, record, _currentUser);
                    _userInteraction.DisplayMessage("Record edited Sucessfully !");
                }
                else
                {
                    _userInteraction.DisplayMessage("Invalid Transaction ID");
                }
            }
            else
            {
                _userInteraction.DisplayMessage("\nInvalid Date !\n");
            }
        }
    }
}