﻿/// <summary>
/// <see cref="ManagerTracker"/> handles all the functionalities 
/// </summary>
public class ManagerTracker : IManageTracker
{
    public User _user;


    private readonly IUserInteraction _userInteraction;
    private readonly IRepositoryInteraction _repositoryInteraction;

    /// <summary>
    /// <see cref="ManagerTracker"/> injects <see cref="IUserInteraction"/> <see cref="IRepositoryInteraction"/>
    /// </summary>
    /// <param name="userInteraction"></param>
    /// <param name="repositoryInteraction"></param>
    public ManagerTracker(IUserInteraction userInteraction, IRepositoryInteraction repositoryInteraction)
    {

        _userInteraction = userInteraction;
        _user = null;
        _repositoryInteraction = repositoryInteraction;
    }



    public void CheckExisitingUser()
    {
        string userName = _userInteraction.stringAsInput("Username");
        _user = _repositoryInteraction.isUserPresent(userName);
        string message = _user != null ? $"Logged into {userName}  !" : "Invalid User !";
        _userInteraction.displayMessage(message);
        if (_user != null)
        {

            login();

        }


    }

    public void login()
    {

        bool Exit = false;
        while (!Exit)
        {
            _userInteraction.displayFeatures();
            string userChoice = _userInteraction.stringAsInput("Option ");
            switch (userChoice)
            {
                case "v":
                case "V":
                    viewRecords();
                    break;
                case "i":
                case "I":
                    addIncomeRecord();
                    _repositoryInteraction.writeToFile();
                    break;
                case "E":
                case "e":
                    addExpenseRecord();
                    _repositoryInteraction.writeToFile();
                    break;
                case "M":
                case "m":
                    editRecord();
                    _repositoryInteraction.writeToFile();
                    break;
                case "D":
                case "d":
                    deleteRecordBasedOnDate();
                    _repositoryInteraction.writeToFile();
                    break;

                case "F":
                case "f":
                    financialSummary();
                    break;
                case "l":
                case "L":
                    Exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid Option !");
                    break;

            }
        }
    }

    /// <summary>
    /// <see cref="viewRecords"/> display all the records
    /// </summary>
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
                    Exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid Option !");
                    break;


            }

        }

    }

    /// <summary>
    /// <see cref="addIncomeRecord"/> adds the income record details
    /// </summary>
    void addIncomeRecord()
    {
        DateTime userInputDate = _userInteraction.dateAsInput("to add Income record");
        Date IncomeDate = _repositoryInteraction.isDatePresent(userInputDate, _user);

        if (IncomeDate is null)
        {
            IncomeDate = new Date(userInputDate);
            _user.Dates.Add(IncomeDate);

        }

        IRecord record = _userInteraction.getIncomeDetails(_user);

        _repositoryInteraction.addRecord(record, IncomeDate);

        _userInteraction.displayMessage("Record added successfully !!!!!!");
    }


    /// <summary>
    /// <see cref="addExpenseRecord"/> adds the expense record details
    /// </summary>
    void addExpenseRecord()
    {
        DateTime userInputDate = _userInteraction.dateAsInput("to add Expense record");
        Date ExpenseDate = _repositoryInteraction.isDatePresent(userInputDate, _user);

        if (ExpenseDate is null)
        {
            ExpenseDate = new Date(userInputDate);
            _user.Dates.Add(ExpenseDate);

        }

        IRecord record = _userInteraction.getExpenseDetails(_user);

        _repositoryInteraction.addRecord(record, ExpenseDate);

        _userInteraction.displayMessage("Record added successfully !!!!!!");


    }

    /// <summary>
    /// <see cref="deleteRecordBasedOnDate"/> deletes the record based on given date
    /// </summary>
    void deleteRecordBasedOnDate()
    {
        DateTime userInputDate = _userInteraction.dateAsInput("to add Income record");
        Date IncomeDate = _repositoryInteraction.isDatePresent(userInputDate, _user);
        if (IncomeDate is not null)
        {

            _userInteraction.displayRecordsOnSpecificDate(IncomeDate);
            int userOption = _userInteraction.intAsInput("Index of Record to delete");
            if (userOption <= IncomeDate.records.Count && userOption > 0)
            {

                _repositoryInteraction.deleteRecord(IncomeDate.records, userOption - 1, _user);
                _userInteraction.displayMessage("Record Deleted Sucessfully !");

            }
            else
            {
                _userInteraction.displayMessage("Invalid Transaction ID");
            }
        }
        else
        {
            _userInteraction.displayMessage($"No Transactions on date {userInputDate.ToString()}");
        }
    }

    /// <summary>
    /// <see cref="financialSummary"/> displays the summary of the <see cref="User"/>
    /// </summary>
    void financialSummary()
    {
        bool Exit = false;
        while (!Exit)
        {
            _userInteraction.displayMessage("[O]verAll Summary\n[S]pecific Summary\n[E]xit");
            string userOption = _userInteraction.stringAsInput("option");
            switch (userOption)
            {
                case "o":
                case "O":
                    _userInteraction.displayMessage($"***OverAll Summary of {_user.Name}***");
                    _userInteraction.displayMessage($"Balance : {_user.CurrentBalance}");
                    _userInteraction.displayMessage($"Total income :{_user.TotalIncome}");
                    _userInteraction.displayMessage($"Total expense :{_user.TotalExpense}");

                    break;
                case "S":
                case "s":
                    DateTime userInputDate = _userInteraction.dateAsInput("to view Summary");
                    Date Date = _repositoryInteraction.isDatePresent(userInputDate, _user);

                    if (Date is not null)
                    {
                        calculateSummaryOnSpecificDate(Date);
                    }
                    else
                    {
                        _userInteraction.displayMessage($"No Transactions on date {userInputDate.ToString()}");

                    }
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
    /// <see cref="calculateSummaryOnSpecificDate(Date)"/> calculate the summary for specific <see cref="Date.CurrentDate"/>
    /// </summary>
    /// <param name="date"></param>
    void calculateSummaryOnSpecificDate(Date date)
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
        _userInteraction.displayMessage($"****Summary on {date.CurrentDate}***");
        _userInteraction.displayMessage($"Net Balance : {TotalIncome - TotalExpense}");
        _userInteraction.displayMessage($"TotalIncome : {TotalIncome}");
        _userInteraction.displayMessage($"TotalExpense : {TotalExpense}");
        _userInteraction.displayMessage("********************************************");

    }

    /// <summary>
    /// <see cref="editRecord"/> modify the details of the existing record
    /// </summary>
    void editRecord()
    {
        DateTime userInputDate = _userInteraction.dateAsInput("to add edit record");
        Date editDate = _repositoryInteraction.isDatePresent(userInputDate, _user);
        if (editDate is not null)
        {

            _userInteraction.displayRecordsOnSpecificDate(editDate);
            int userOption = _userInteraction.intAsInput("Index of Record to edit");
            if (userOption <= editDate.records.Count && userOption > 0)
            {
                IRecord record = editDate.records[userOption - 1];
                IRecord updateRecord;
                if (record is Income)
                {
                    updateRecord = _userInteraction.getIncomeDetails(_user);

                }
                else
                {
                    updateRecord = _userInteraction.getExpenseDetails(_user);
                }
                _repositoryInteraction.updateRecord(updateRecord, record, _user);
                _userInteraction.displayMessage("Record edited Sucessfully !");

            }
            else
            {
                _userInteraction.displayMessage("Invalid Transaction ID");
            }
        }


    }

}


