// See https://aka.ms/new-console-template for more information
using static System.Runtime.InteropServices.JavaScript.JSType;

public class RepositoryInteraction :IRepositoryInteraction
{
    private List<User> _users;
    private readonly IFileInteraction _fileInteraction;
    private readonly IUserInteraction _userInteraction;
    public RepositoryInteraction(IUserInteraction userInteraction,IFileInteraction fileInteraction)
    {
        _fileInteraction = fileInteraction;
        _userInteraction = userInteraction;
        _users = new List<User>();
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
        _users = _fileInteraction.readAlldata();
    }
    public Date isDatePresent(DateTime Checkdate,User user)
    {
        foreach(Date Date in user.Dates)
        {
            //if(DateTime.Compare(Date.CurrentDate, Checkdate)==1)
            //{
            //    return Date;
            //}
            if (Date.CurrentDate.Date == Checkdate.Date)
            {
                return Date;
            }
        }
        return null;
        
    }
}

