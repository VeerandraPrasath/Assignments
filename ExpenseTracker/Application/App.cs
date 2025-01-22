using ExpenseTracker.ConsoleInteraction;
using ExpenseTracker.Controller;
using ExpenseTracker.Manager;

namespace ExpenseTracker.Application
{

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
        /// <see cref="Run"/> initialize the workFlow
        /// </summary>
        public void Run()
        {
            _repositoryInteraction.LoadAllData();
            _userInteraction.DisplayMessage("_________________________________________________________");
            _userInteraction.DisplayMessage("      Welcome to the Expense Tracker Application");
            _userInteraction.DisplayMessage("__________________________________________________________");
            while (!Exit)
            {
                _userInteraction.DisplayMessage("[N]ew User\n[E]xisting User\n[C]lose App\n");
                string userOption = _userInteraction.StringAsInput("option");
                switch (userOption.ToLower())
                {
                    case "n":
                        _repositoryInteraction.CreateNewUser();
                        _repositoryInteraction.WriteToFile();
                        break;
                    case "e":
                        _manageTracker.CheckExisitingUser();
                        break;
                    case "c":
                        Exit = true;
                        break;
                    default:
                        _userInteraction.DisplayMessage("Invalid option !\n");
                        break;
                }
            }

        }
    }
}