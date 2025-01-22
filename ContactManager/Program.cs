using ContactManager.Controller;
using ContactManager.Manager;
using ContactManager.UserInteraction;

UserInteraction userInteraction = new UserInteraction();
App app = new App(userInteraction, new ContactRepository(userInteraction));
app.run();
Console.ReadKey();