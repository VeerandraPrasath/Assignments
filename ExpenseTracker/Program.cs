using ExpenseTracker.UserInteraction;
using ExpenseTracker.Controller;
using ExpenseTracker.FileInteractions;
using ExpenseTracker.Manager;

var userInteraction = new UserInteraction();
var fileInteraction = new FileInteraction();
var repositoryInteraction = new RepositoryInteraction(userInteraction, fileInteraction, "UserList.json");
var manageTracker = new ManageTracker(userInteraction, repositoryInteraction);
App app = new App(userInteraction, manageTracker, repositoryInteraction);
app.Run();

/// <summary>
/// Starts the main flow
/// </summary>
public class App
{
    private readonly IUserInteraction _userInteraction;
    private readonly IManageTracker _manageTracker;
    private readonly IRepositoryInteraction _repositoryInteraction;

    public bool Exit = false;

    /// <summary>
    /// Constructor for App
    /// </summary>
    /// <param name="userInteraction">User Interaction</param>
    /// <param name="manageTracker">Manage Tracker</param>
    /// <param name="repositoryInteraction">Repository Interaction</param>
    public App(IUserInteraction userInteraction, IManageTracker manageTracker, IRepositoryInteraction repositoryInteraction)
    {
        _userInteraction = userInteraction;
        _manageTracker = manageTracker;
        _repositoryInteraction = repositoryInteraction;
    }

    /// <summary>
    /// Initialize the workFlow
    /// </summary>
    public void Run()
    {
        _repositoryInteraction.LoadAllFileData();
        _userInteraction.DisplayMessage("_________________________________________________________");
        _userInteraction.DisplayMessage("      Welcome to the Expense Tracker Application");
        _userInteraction.DisplayMessage("__________________________________________________________");
        while (!Exit)
        {
            _userInteraction.DisplayMessage("[1] New User\n[2] Existing User\n[3] Close App\n");
            string userOption = _userInteraction.GetValidString("option");
            switch (userOption)
            {
                case "1":
                    _repositoryInteraction.CreateNewUser();
                    _repositoryInteraction.WriteToFile();
                    break;
                case "2":
                    _manageTracker.CheckExisitingUser();
                    break;
                case "3":
                    Exit = true;
                    break;
                default:
                    _userInteraction.DisplayMessage("Invalid option !\n");
                    break;
            }
        }
    }
}