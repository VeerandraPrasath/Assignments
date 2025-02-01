﻿using ExpenseTracker.ConsoleInteraction;
using ExpenseTracker.FileInteraction;
using ExpenseTracker.Record;
using ExpenseTracker.UserData;

namespace ExpenseTracker.Controller
{
    /// <summary>
    /// Implements <see cref="IRepositoryInteraction"/>
    /// </summary>
    public class RepositoryInteraction : IRepositoryInteraction
    {
        private List<User> _users;
        private readonly IFileInteraction _fileInteraction;
        private readonly IUserInteraction _userInteraction;

        /// <summary>
        /// Path of the file
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Constructor for RepositoryInteraction
        /// </summary>
        /// <param name="userInteraction">User Interaction</param>
        /// <param name="fileInteraction">File Interaction</param>
        /// <param name="filePath">Path of the File</param>
        public RepositoryInteraction(IUserInteraction userInteraction, IFileInteraction fileInteraction, string filePath,List<User> userList)
        {
            _fileInteraction = fileInteraction;
            _userInteraction = userInteraction;
            _users = userList;
            FilePath = filePath;
        }

        public User IsUserPresent(string username)
        {
            foreach (User user in _users)
            {
                if (user.Name.Equals(username)) return user;
            }

            return null;
        }

        public bool CreateNewUser()
        {
            string newUser;
            do
            {
                newUser = _userInteraction.GetStringInput("New Username");
                if (IsUserPresent(newUser) is not null)
                {
                    _userInteraction.DisplayMessage("\nUsername already exist !\n");
                }
            } while (IsUserPresent(newUser) is not null);
            _users.Add(new User(newUser));
            _userInteraction.DisplayMessage("\nAccount created successfully ! please Login !\n");

            return true;
        }

        public void LoadAllData()
        {
            _users = _fileInteraction.ReadAlldata(FilePath);
        }

        public Date IsDatePresent(DateTime Checkdate, User user)
        {
            foreach (Date Date in user.Dates)
            {
                if (Date.CurrentDate.Date == Checkdate.Date)
                {
                    return Date;
                }
            }

            return null;
        }

        public bool DeleteRecord(List<IRecord> records, int index, User user)
        {
            IRecord record = records[index];
            user.CurrentBalance = record is Income ? user.CurrentBalance - record.Amount : user.CurrentBalance + record.Amount;
            return records.Remove(record);
        }

        public void AddRecord(IRecord record, Date date, User user)
        {
            if (record is Income)
            {
                user.CurrentBalance += record.Amount;
                user.TotalIncome += record.Amount;
            }
            else
            {
                user.CurrentBalance -= record.Amount;
                user.TotalExpense += record.Amount;
            }
            date.records.Add(record);
        }

        public void UpdateRecord(IRecord newRecord, IRecord oldRecord, User user)
        {
            if (oldRecord is Income)
            {
                user.CurrentBalance -= oldRecord.Amount;
                user.TotalIncome -= oldRecord.Amount;
            }
            else
            {
                user.CurrentBalance += oldRecord.Amount;
                user.TotalExpense += oldRecord.Amount;
            }
            oldRecord.Category = newRecord.Category;
            oldRecord.Amount = newRecord.Amount;
        }

        public void WriteToFile()
        {
            _fileInteraction.WriteData(FilePath, _users);
        }
    }
}