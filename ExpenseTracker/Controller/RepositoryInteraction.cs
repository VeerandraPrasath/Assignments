using ExpenseTracker.UserInteraction;
using ExpenseTracker.FileInteractions;
using ExpenseTracker.Record;
using ExpenseTracker.UserData;

namespace ExpenseTracker.Controller
{
    /// <summary>
    /// Implements <see cref="IRepositoryInteraction"/>
    /// </summary>
    public class RepositoryInteraction : IRepositoryInteraction
    {
        private List<User> _userList;
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
        public RepositoryInteraction(IUserInteraction userInteraction, IFileInteraction fileInteraction, string filePath)
        {
            _fileInteraction = fileInteraction;
            _userInteraction = userInteraction;
            _userList = new List<User>();
            FilePath = filePath;
        }

        public User FindByUsername(string username)
        {
           return  _userList.Find(x => x.Name.Equals(username));
        }

        public void CreateNewUser()
        {
            string newUser;
            do
            {
                newUser = _userInteraction.GetValidString("New Username");
                if (FindByUsername(newUser) is not null)
                {
                    _userInteraction.DisplayMessage("\nUsername already exist !\n");
                }
            } while (FindByUsername(newUser) is not null);
            _userList.Add(new User(newUser));
            _userInteraction.DisplayMessage("\nAccount created successfully ! please Login !\n");
        }

        public void LoadData()
        {
            _userList = _fileInteraction.ReadFiledata(FilePath);
        }

        public Transaction FindByTransactionDate(DateTime transactionDate, User user)
        {
            foreach (Transaction Date in user.TransactionList)
            {
                if (Date.TransactionDate.Date == transactionDate.Date)
                {
                    return Date;
                }
            }

            return null;
        }

        public void DeleteRecord(List<IRecord> recordList, int index, User user)
        {
            IRecord record = recordList[index];
            user.CurrentBalance = record is Income ? user.CurrentBalance - record.Amount : user.CurrentBalance + record.Amount;
            recordList.Remove(record);
        }

        public void AddRecord(IRecord record, Transaction transaction, User user)
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
            transaction.RecordList.Add(record);
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
            _fileInteraction.WriteData(FilePath, _userList);
        }
    }
}