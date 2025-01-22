
using ExpenseTracker.Application;
using ExpenseTracker.ConsoleInteraction;
using ExpenseTracker.Controller;
using ExpenseTracker.FileInteraction;
using ExpenseTracker.Manager;

var userInteraction = new UserInteraction();
var fileInteraction = new FileInteraction();
var repositoryInteraction = new RepositoryInteraction(userInteraction, fileInteraction, "C:\\Users\\veerandra.prasath\\source\\repos\\ContactManager\\ExpenseTracker\\DataBase\\UserList.json");
var manageTracker = new ManagerTracker(userInteraction, repositoryInteraction);
App app = new App(userInteraction, manageTracker, repositoryInteraction);
app.Run();


