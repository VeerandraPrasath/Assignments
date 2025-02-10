using ExpenseTracker.UserInteraction;
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
            string userName = _userInteraction.GetValidString("Username");
            _currentUser = _repositoryInteraction.FindUserByUsername(userName);
            if (_currentUser != null)
            {
                Console.Clear();
            }
            _userInteraction.DisplayMessage("________________________________________________");
            string message = _currentUser != null ? $"Logged into {userName}" : "Invalid User !";
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
                _userInteraction.DisplayMainMenu();
                string userChoice = _userInteraction.GetValidString("Option ");
                switch (userChoice)
                {
                    case "1":
                        ViewTransactionRecords();
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
                        EditRecordByTransactionDate();
                        _repositoryInteraction.WriteToFile();
                        break;
                    case "5":
                        DeleteRecordByTransactionDate();
                        _repositoryInteraction.WriteToFile();
                        break;
                    case "6":
                        DisplayFinancialSummary();
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
        private void ViewTransactionRecords()
        {
            bool exit = false;
            if (_currentUser.TransactionList.Count == 0)
            {
                _userInteraction.DisplayMessage("___________________________________");
                _userInteraction.DisplayMessage("\n   No Transactions found ");
                _userInteraction.DisplayMessage("___________________________________");

                return;
            }
            while (!exit)
            {
                _userInteraction.DisplayMessage("\n[1] All records\n[2] Specific transaction\n[3] Exit\n");
                string userOption = _userInteraction.GetValidString("option");
                switch (userOption)
                {
                    case "1":
                        _userInteraction.DisplayMessage("--------------------------------------------");
                        _userInteraction.DisplayMessage("          ALL Transactions");
                        _userInteraction.DisplayMessage("--------------------------------------------");
                        _userInteraction.DisplayAllRecords(_currentUser.TransactionList);
                        _userInteraction.DisplayMessage("--------------------------------------------");
                        exit = true;
                        break;
                    case "2":
                        DateTime userInputDate = _userInteraction.GetValidDate("to view Transactions");
                        Transaction transaction = _repositoryInteraction.FindTransactionByTransactionDate(userInputDate, _currentUser);
                        if (transaction is not null)
                        {
                            _userInteraction.DisplayRecordsByDate(transaction);
                        }
                        else
                        {
                            _userInteraction.DisplayMessage("________________________________________________");
                            _userInteraction.DisplayMessage($"No Transactions on transaction {userInputDate.ToString()}\n");
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
        private void AddIncomeRecord()
        {
            DateTime userInputDate = _userInteraction.GetValidDate("to add Income record");
            Transaction transaction = _repositoryInteraction.FindTransactionByTransactionDate(userInputDate, _currentUser);
            if (transaction is null)
            {
                transaction = new Transaction(userInputDate);
                _currentUser.TransactionList.Add(transaction);
            }
            IRecord record = _userInteraction.GetIncomeDetails();
            _repositoryInteraction.AddRecord(record, transaction, _currentUser);
            _userInteraction.DisplayMessage("Record added successfully !!!!!!");
        }

        /// <summary>
        /// Adds expense record details
        /// </summary>
        private void AddExpenseRecord()
        {
            DateTime userInputDate = _userInteraction.GetValidDate("to add Expense record");
            Transaction transaction = _repositoryInteraction.FindTransactionByTransactionDate(userInputDate, _currentUser);
            if (transaction is null)
            {
                transaction = new Transaction(userInputDate);
                _currentUser.TransactionList.Add(transaction);
            }
            IRecord record = _userInteraction.GetExpenseDetails();
            _repositoryInteraction.AddRecord(record, transaction, _currentUser);
            _userInteraction.DisplayMessage("Record added successfully !!!!!!");
        }

        /// <summary>
        /// Deletes record based on transaction
        /// </summary>
        private void DeleteRecordByTransactionDate()
        {
            if (_currentUser.TransactionList.Count == 0)
            {
                _userInteraction.DisplayMessage("___________________________________");
                _userInteraction.DisplayMessage("\n   No Transactions found ");
                _userInteraction.DisplayMessage("___________________________________");

                return;
            }
            DateTime userInputDate = _userInteraction.GetValidDate("to add Income record");
            Transaction transaction = _repositoryInteraction.FindTransactionByTransactionDate(userInputDate, _currentUser);
            if (transaction is not null)
            {
                _userInteraction.DisplayRecordsByDate(transaction);
                int userOption = _userInteraction.GetValidInt("Index of Record to delete");
                if (userOption <= transaction.RecordList.Count && userOption > 0)
                {
                    _repositoryInteraction.DeleteRecord(transaction.RecordList, userOption - 1, _currentUser);
                    _userInteraction.DisplayMessage("Record Deleted Sucessfully !");
                }
                else
                {
                    _userInteraction.DisplayMessage("Invalid Transaction ID");
                }
            }
            else
            {
                _userInteraction.DisplayMessage($"No Transactions on transaction {userInputDate.ToString()}");
            }
        }

        /// <summary>
        /// Displays summary of <see cref="User"/>
        /// </summary>
        private void DisplayFinancialSummary()
        {
            bool Exit = false;
            if (_currentUser.TransactionList.Count == 0)
            {
                _userInteraction.DisplayMessage("___________________________________");
                _userInteraction.DisplayMessage("\n   No Transactions found ");
                _userInteraction.DisplayMessage("___________________________________");

                return;
            }
            while (!Exit)
            {
                _userInteraction.DisplayMessage("[1] OverAll Summary\n[2] Specific Summary\n[3] Exit");
                string userOption = _userInteraction.GetValidString("option");
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
                        DateTime userInputDate = _userInteraction.GetValidDate("to view Summary");
                        Transaction transaction = _repositoryInteraction.FindTransactionByTransactionDate(userInputDate, _currentUser);
                        if (transaction is not null)
                        {
                            CalculateSummaryByTransactionDate(transaction);
                        }
                        else
                        {
                            _userInteraction.DisplayMessage($"No Transactions on transaction {userInputDate.ToString()}");
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
        /// <param name="transaction">transaction of the record</param>
        private void CalculateSummaryByTransactionDate(Transaction transaction)
        {
            decimal TotalIncome = 0;
            decimal TotalExpense = 0;
            foreach (IRecord record in transaction.RecordList)
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
            _userInteraction.DisplayMessage($"    Summary on {transaction.TransactionDate}");
            _userInteraction.DisplayMessage("--------------------------------------------");
            _userInteraction.DisplayMessage($"Net Balance  : {TotalIncome - TotalExpense}\n");
            _userInteraction.DisplayMessage($"TotalIncome  : {TotalIncome}\n");
            _userInteraction.DisplayMessage($"TotalExpense : {TotalExpense}\n");
            _userInteraction.DisplayMessage("--------------------------------------------");
        }

        /// <summary>
        /// Modify record details
        /// </summary>
        private void EditRecordByTransactionDate()
        {
            if (_currentUser.TransactionList.Count == 0)
            {
                _userInteraction.DisplayMessage("___________________________________");
                _userInteraction.DisplayMessage("\n   No Transactions found ");
                _userInteraction.DisplayMessage("___________________________________");

                return;
            }
            DateTime userInputDate = _userInteraction.GetValidDate("to add edit record");
            Transaction editTransaction = _repositoryInteraction.FindTransactionByTransactionDate(userInputDate, _currentUser);
            if (editTransaction is not null)
            {
                if (editTransaction.RecordList.Count == 0 || editTransaction.RecordList is null)
                {
                    _userInteraction.DisplayMessage($"\nNo Transactions on {editTransaction.ToString()}\n");
                }
                _userInteraction.DisplayRecordsByDate(editTransaction);
                int userOption = _userInteraction.GetValidInt("Index of Record to edit");
                if (userOption <= editTransaction.RecordList.Count && userOption > 0)
                {
                    IRecord record = editTransaction.RecordList[userOption - 1];
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
                _userInteraction.DisplayMessage("\nInvalid transaction !\n");
            }
        }
    }
}