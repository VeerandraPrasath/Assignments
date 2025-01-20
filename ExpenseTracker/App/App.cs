/// <summary>
/// <see cref="App"/> starts the main flow of the application
/// </summary>
public class App
{

    private readonly IUserInteraction _userInteraction;
    private readonly IManageTracker _manageTracker;
    private readonly IRepositoryInteraction _repositoryInteraction;
    public bool Exit = false;

    /// <summary>
    /// <see cref="App"/> injects the interfaces <see cref="IManageTracker"/> <see cref="IUserInteraction"/> <see cref="IRepositoryInteraction"/>
    /// </summary>
    /// <param name="userInteraction"></param>
    /// <param name="manageTracker"></param>
    /// <param name="repositoryInteraction"></param>
    public App(IUserInteraction userInteraction, IManageTracker manageTracker, IRepositoryInteraction repositoryInteraction)
    {
        _userInteraction = userInteraction;
        _manageTracker = manageTracker;
        _repositoryInteraction = repositoryInteraction;

    }

    /// <summary>
    /// <see cref="run"/> initialize the workFlow
    /// </summary>
    public void run()
    {
        _repositoryInteraction.loadAllData();
        _userInteraction.displayMessage("***Welcome to the Expense Tracker Application***");
        while (!Exit)
        {
            _userInteraction.displayMessage("[N]ew User\n[E]xisting User\n[C]lose App");
            string userOption = _userInteraction.stringAsInput("option");
            switch (userOption)
            {
                case "n":
                case "N":
                    _repositoryInteraction.CreateNewUser();
                    _repositoryInteraction.writeToFile();
                    break;
                case "e":
                case "E":
                    _manageTracker.CheckExisitingUser();
                    break;
                case "C":
                case "c":
                    Exit = true;
                    break;
                default:
                    _userInteraction.displayMessage("Invalid option !");
                    break;
            }
        }

    }
}

