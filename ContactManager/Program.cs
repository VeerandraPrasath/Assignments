using ContactManager.Controller;
using ContactManager.Model;
using ContactManager.UserInteraction;

UserInteraction userInteraction = new UserInteraction();
App app = new App(userInteraction, new ContactRepository(userInteraction));
app.run();
Console.ReadKey();

/// <summary>
/// Starts the flow of application
/// </summary>
public class App
{
    List<ContactInformation> contacts;
    private bool isExit = false;
    private readonly IUserInteraction _userInteraction;
    private readonly IContactRepository _repositoryInteraction;

    /// <summary>
    /// Injects <see cref="IUserInteraction"/> ,<see cref="IContactRepository"/>
    /// </summary>
    /// <param name="userInteraction">User Interaction</param>
    /// <param name="repositoryInteraction">Repository Interaction</param>
    public App(IUserInteraction userInteraction, IContactRepository repositoryInteraction)
    {
        _userInteraction = userInteraction;
        _repositoryInteraction = repositoryInteraction;
        contacts = new List<ContactInformation>();
    }

    /// <summary>
    /// Initialize  the main flow 
    /// </summary>
    public void run()
    {
        while (!isExit)
        {
            _userInteraction.DisplayOption();
            var userOption = Console.ReadLine();
            switch (userOption.ToLower())
            {
                case "v":
                    _userInteraction.DisplayContacts(contacts);
                    break;
                case "a":
                    contacts.Add(_repositoryInteraction.AddNewContact());
                    break;
                case "e":
                    if (contacts.Count != 0)
                    {
                        var filteredEditContacts = SearchContacts();
                        if (filteredEditContacts.Count() > 0)
                        {
                            var selectedContact = _repositoryInteraction.SelectContactBasedOnIndex(filteredEditContacts);
                            _repositoryInteraction.EditExisitingContact(selectedContact);
                        }
                    }
                    else
                    {
                        _userInteraction.DisplayMessage("No contacts to edit !");
                    }
                    break;
                case "d":
                    if (contacts.Count != 0)
                    {
                        var filteredDeleteContacts = SearchContacts();
                        if (filteredDeleteContacts.Count() > 0)
                        {
                            var selectedContact = _repositoryInteraction.SelectContactBasedOnIndex(filteredDeleteContacts);
                            _repositoryInteraction.DeleteExisitingContact(selectedContact, contacts);
                        }
                    }
                    else
                    {
                        _userInteraction.DisplayMessage("No contacts to delete !");
                    }
                    break;
                case "s":
                    if (contacts.Count != 0)
                    {
                        SearchContacts();
                    }
                    else
                    {
                        _userInteraction.DisplayMessage("NO contacts to search !");
                    }
                    break;
                case "cl":
                    Console.Clear();
                    break;
                case "c":
                    isExit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option !!!");
                    break;
            }
        }
    }

    private List<ContactInformation> SearchContacts()
    {
        Console.WriteLine("Enter any one detail of the contact to search :");
        var anyInfoOfContact = Console.ReadLine();
        var filteredContacts = _repositoryInteraction.FilteredContacts(anyInfoOfContact!, contacts);
        _userInteraction.DisplayContacts(filteredContacts);

        return filteredContacts;
    }
}