using ExpenseTracker.ConsoleInteraction;
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
        public RepositoryInteraction(IUserInteraction userInteraction, IFileInteraction fileInteraction, string filePath)
        {
            _fileInteraction = fileInteraction;
            _userInteraction = userInteraction;
            _users = new List<User>();
            FilePath = filePath;
        }

        public User FindUserByUsername(string username)
        {
            return _users.Find(user => user.Name.Equals(username)); 
        }

        public void CreateNewUser()
        {
            string newUser;
            do
            {
                newUser = _userInteraction.GetStringInput("New Username");
                if (FindUserByUsername(newUser) is not null)
                {
                    _userInteraction.DisplayMessage("\nUsername already exist !\n");
                }
            } while (FindUserByUsername(newUser) is not null);
            _users.Add(new User(newUser));
            _userInteraction.DisplayMessage("\nAccount created successfully ! please Login !\n");
        }

        public void LoadFileData()
        {
            _users = _fileInteraction.ReadFileData();
        }

        public Transaction FindTransactionByDate(DateTime Checkdate, User user)
        {
            foreach (Transaction Date in user.Dates)
            {
                if (Date.TransactionDate.Date == Checkdate.Date)
                {
                    return Date;
                }
            }

            return null;
        }

        public void AddRecord(IRecord record, Transaction date, User user)
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
            date.RecordList.Add(record);
        }
    }
}