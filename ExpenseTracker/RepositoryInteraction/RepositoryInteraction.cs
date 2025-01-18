// See https://aka.ms/new-console-template for more information
using static System.Runtime.InteropServices.JavaScript.JSType;

public class RepositoryInteraction :IRepositoryInteraction
{
    string FilePath { get; set; }
    private List<User> _users;
    private readonly IFileInteraction _fileInteraction;
    private readonly IUserInteraction _userInteraction;
    public RepositoryInteraction(IUserInteraction userInteraction,IFileInteraction fileInteraction,string filePath)
    {
        _fileInteraction = fileInteraction;
        _userInteraction = userInteraction;
        _users = new List<User>();
        FilePath = filePath;
    }
    public User isUserPresent(string username)
    {
        foreach (User user in _users)
        {
            if (user.Name.Equals(username)) return user;
        }
        return null;
    }
    public bool CreateNewUser()
    {
        string newUser = _userInteraction.stringAsInput("New Username");
        _users.Add(new User(newUser));
        _userInteraction.displayMessage("Account created successfully ! please Login !");
        return true;

    }
    public void loadAllData()
    {
        _users = _fileInteraction.readAlldata(FilePath);
    }
    public Date isDatePresent(DateTime Checkdate,User user)
    {
        foreach(Date Date in user.Dates)
        {

            if (Date.CurrentDate.Date == Checkdate.Date)
            {
                return Date;
            }
        }
        return null;
        
    }
    public bool deleteRecord(List<IRecord> records, int index,User user)
    {
        IRecord record = records[index];
        user.CurrentBalance=record is Income?user.CurrentBalance-record.Amount:user.CurrentBalance+record.Amount;
        records.Remove(record);
        return true ;
        
    }
      public void addRecord(IRecord record, Date date)
    {
        
        date.records.Add(record);

    }
    public void updateRecord(IRecord newRecord, IRecord oldRecord,User user)
    {
        if (oldRecord is Income)
        {
            user.CurrentBalance-=oldRecord.Amount;
            user.TotalIncome-=oldRecord.Amount;
        }
        else
        {
            user.CurrentBalance+=oldRecord.Amount;
            user.CurrentBalance += oldRecord.Amount;
        }
        oldRecord.Category = newRecord.Category;
        oldRecord.Amount= newRecord.Amount;

    }
    public void writeToFile()
    {
        _fileInteraction.writeData(FilePath, _users);
    }

}

