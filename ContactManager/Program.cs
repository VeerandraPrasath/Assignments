using ContactManager.Controller;
using ContactManager.Manager;
using ContactManager.UserInteraction;
try
{

    var userInteraction = new UserInteraction();
var contactManager = new App(userInteraction, new ContactRepository(userInteraction));
contactManager.run();
Console.ReadKey();
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

