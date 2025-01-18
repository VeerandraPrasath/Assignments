// See https://aka.ms/new-console-template for more information
public class App
{
    
    private readonly IUserInteraction _userInteraction;
    private readonly IManageTracker _manageTracker;
    private readonly IRepositoryInteraction _repositoryInteraction;
    public  bool Exit=false;
   
    public App(IUserInteraction userInteraction,IManageTracker manageTracker,IRepositoryInteraction repositoryInteraction)
    {
        _userInteraction = userInteraction;
        _manageTracker = manageTracker;
        _repositoryInteraction = repositoryInteraction;
           
    }
    public  void run()
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

