// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Contracts;
using System.Globalization;
var userInteraction=new UserInteraction();
var fileInteraction=new FileInteraction();  
var repositoryInteraction=new RepositoryInteraction(userInteraction,fileInteraction);
var manageTracker=new ManagerTracker(userInteraction,repositoryInteraction); 
App app=new App(userInteraction,manageTracker,repositoryInteraction);
app.run(args);  
Console.WriteLine("Hello, World!");

