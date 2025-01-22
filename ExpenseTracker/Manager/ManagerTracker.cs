using ExpenseTracker.ConsoleInteraction;
using ExpenseTracker.Controller;
using ExpenseTracker.Record;
using ExpenseTracker.UserData;

namespace ExpenseTracker.Manager
{

    /// <summary>
    /// <see cref="ManagerTracker"/> handles all the functionalities 
    /// </summary>
    public class ManagerTracker : IManageTracker
    {
        private User _currentUser;


        private readonly IUserInteraction _userInteraction;
        private readonly IRepositoryInteraction _repositoryInteraction;

        /// <summary>
        /// <see cref="ManagerTracker"/> injects <see cref="IUserInteraction"/> <see cref="IRepositoryInteraction"/>
        /// </summary>
        public ManagerTracker(IUserInteraction userInteraction, IRepositoryInteraction repositoryInteraction)
        {

            _userInteraction = userInteraction;
            _currentUser = null;
            _repositoryInteraction = repositoryInteraction;
        }



        public void CheckExisitingUser()
        {
            string userName = _userInteraction.StringAsInput("Username");
            _currentUser = _repositoryInteraction.IsUserPresent(userName);
            if (_currentUser != null) Console.Clear();
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
                string userChoice = _userInteraction.StringAsInput("Option ");
                switch (userChoice)
                {
                    case "v":
                    case "V":
                        ViewRecords();
                        break;
                    case "i":
                    case "I":
                        AddIncomeRecord();
                        _repositoryInteraction.WriteToFile();
                        break;
                    case "E":
                    case "e":
                        AddExpenseRecord();
                        _repositoryInteraction.WriteToFile();
                        break;
                    case "M":
                    case "m":
                        EditRecord();
                        _repositoryInteraction.WriteToFile();
                        break;
                    case "D":
                    case "d":
                        DeleteRecordBasedOnDate();
                        _repositoryInteraction.WriteToFile();
                        break;

                    case "F":
                    case "f":
                        FinancialSummary();
                        break;
                    case "l":
                    case "L":
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
        /// <see cref="ViewRecords"/> display all the records
        /// </summary>
        void ViewRecords()
        {
            bool exit = false;
            while (!exit)
            {
                _userInteraction.DisplayMessage("\n[A]ll records\n[S]pecific Date\n[E]xit\n");
                string userOption = _userInteraction.StringAsInput("option");
                switch (userOption)
                {
                    case "a":
                    case "A":
                        _userInteraction.DisplayMessage("--------------------------------------------");
                        _userInteraction.DisplayMessage("          ALL Transactions");
                        _userInteraction.DisplayMessage("--------------------------------------------");
                        _userInteraction.DisplayAllRecords(_currentUser.Dates);
                        _userInteraction.DisplayMessage("--------------------------------------------");
                        exit = true;
                        break;
                    case "s":
                    case "S":
                        DateTime userInputDate = _userInteraction.DateAsInput("to view Transactions");
                        Date Date = _repositoryInteraction.IsDatePresent(userInputDate, _currentUser);

                        if (Date is not null)
                        {
                            _userInteraction.DisplayRecordsOnSpecificDate(Date);
                        }
                        else
                        {
                            _userInteraction.DisplayMessage("________________________________________________");
                            _userInteraction.DisplayMessage($"No Transactions on date {userInputDate.ToString()}\n");
                            _userInteraction.DisplayMessage("________________________________________________");
                        }
                        exit = true;
                        break;
                    case "e":
                    case "E":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Option !\n");
                        break;


                }

            }

        }

        /// <summary>
        /// <see cref="AddIncomeRecord"/> adds the income record details
        /// </summary>
        void AddIncomeRecord()
        {
            DateTime userInputDate = _userInteraction.DateAsInput("to add Income record");
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
        /// <see cref="AddExpenseRecord"/> adds the expense record details
        /// </summary>
        void AddExpenseRecord()
        {
            DateTime userInputDate = _userInteraction.DateAsInput("to add Expense record");
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
        /// <see cref="DeleteRecordBasedOnDate"/> deletes the record based on given date
        /// </summary>
        void DeleteRecordBasedOnDate()
        {
            DateTime userInputDate = _userInteraction.DateAsInput("to add Income record");
            Date IncomeDate = _repositoryInteraction.IsDatePresent(userInputDate, _currentUser);
            if (IncomeDate is not null)
            {

                _userInteraction.DisplayRecordsOnSpecificDate(IncomeDate);
                int userOption = _userInteraction.IntAsInput("Index of Record to delete");
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
        /// <see cref="FinancialSummary"/> displays the summary of the <see cref="User"/>
        /// </summary>
        void FinancialSummary()
        {
            bool Exit = false;
            while (!Exit)
            {
                _userInteraction.DisplayMessage("[O]verAll Summary\n[S]pecific Summary\n[E]xit");
                string userOption = _userInteraction.StringAsInput("option");
                switch (userOption)
                {
                    case "o":
                    case "O":
                        _userInteraction.DisplayMessage("--------------------------------------------");
                        _userInteraction.DisplayMessage($"     OverAll Summary of {_currentUser.Name}");
                        _userInteraction.DisplayMessage("--------------------------------------------");
                        _userInteraction.DisplayMessage($"Balance       : {_currentUser.CurrentBalance}\n");
                        _userInteraction.DisplayMessage($"Total income  : {_currentUser.TotalIncome}\n");
                        _userInteraction.DisplayMessage($"Total expense : {_currentUser.TotalExpense}\n");
                        _userInteraction.DisplayMessage("--------------------------------------------");
                        Exit = true;
                        break;
                    case "S":
                    case "s":
                        DateTime userInputDate = _userInteraction.DateAsInput("to view Summary");
                        Date Date = _repositoryInteraction.IsDatePresent(userInputDate, _currentUser);

                        if (Date is not null)
                        {
                            CalculateSummaryOnSpecificDate(Date);
                        }
                        else
                        {
                            _userInteraction.DisplayMessage($"No Transactions on date {userInputDate.ToString()}");

                        }
                        Exit = true;
                        break;
                    case "e":
                    case "E":
                        Exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Option !");
                        break;


                }

            }
        }

        /// <summary>
        /// <see cref="CalculateSummaryOnSpecificDate(Date)"/> calculate the summary for specific <see cref="Date.CurrentDate"/>
        /// </summary>
        /// <param name="date">Date of the record</param>
        void CalculateSummaryOnSpecificDate(Date date)
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
        /// <see cref="EditRecord"/> modify the details of the existing record
        /// </summary>
        void EditRecord()
        {
            DateTime userInputDate = _userInteraction.DateAsInput("to add edit record");
            Date editDate = _repositoryInteraction.IsDatePresent(userInputDate, _currentUser);
            if (editDate is not null)
            {
                if (editDate.records.Count == 0 || editDate.records is null)
                {
                    _userInteraction.DisplayMessage($"\nNo Transactions on {editDate.ToString()}\n");
                }
                _userInteraction.DisplayRecordsOnSpecificDate(editDate);
                int userOption = _userInteraction.IntAsInput("Index of Record to edit");
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