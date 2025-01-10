

using userinteraction;


try
{

var userInteraction = new UserInteraction();
var contactManager = new ContactManager(userInteraction, new ContactRepository(userInteraction));
contactManager.run();
Console.ReadKey();
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

/// <summary>
/// Used to define the main flow of the app 
/// </summary>
public class ContactManager
{
    List<ContactInformation> contacts;
    private bool isExit = false;
    private readonly IuserInteraction _IuserInteraction;
    private readonly IContactRepository _IrepositoryInteraction;

    public ContactManager(IuserInteraction iuserInteraction, IContactRepository irepositoryInteraction)
    {
        _IuserInteraction = iuserInteraction;
        _IrepositoryInteraction = irepositoryInteraction;
        contacts = new List<ContactInformation>();


    }
    /// <summary>
    ///  Start the main flow 
    /// </summary>
    public void run()
    {
        while (!isExit)
        {
            _IuserInteraction.displayOption();
            var userOption = Console.ReadLine();
            switch (userOption)
            {
                case "V":
                case "v":
                    {

                        _IuserInteraction.displayContacts(contacts);
                        break;
                    }
                case "A":
                case "a":
                    {
                        contacts.Add(_IrepositoryInteraction.addNewContact());
                        break;
                    }
                case "E":
                case "e":
                    {
                        var filteredContacts = getAnyContactInfoAndReturnFilteredResults();
                        if (filteredContacts.Count() > 0)
                        {
                            var selectedContact = _IrepositoryInteraction.SelectContactBasedOnIndex(filteredContacts);
                            _IrepositoryInteraction.editExisitingContact(selectedContact);
                        }
                        break;

                    }
                case "D":
                case "d":
                    {
                        var filteredContacts = getAnyContactInfoAndReturnFilteredResults();
                        if (filteredContacts.Count() > 0)
                        {

                            var selectedContact = _IrepositoryInteraction.SelectContactBasedOnIndex(filteredContacts);
                            _IrepositoryInteraction.deleteExisitingContact(selectedContact, contacts);
                        }
                        break;

                    }
                case "S":
                case "s":
                    {
                        getAnyContactInfoAndReturnFilteredResults();
                        break;
                    }
                case "CL":
                case "cl":
                    Console.Clear();
                    break;
                case "C":
                case "c":
                    {
                        isExit = true;
                        break;
                    }
                default:
                    Console.WriteLine("Invalid option !!!");
                    break;


            }
        }
    }
    /// <summary>
    /// Get any information of the contact and provide the matching results
    /// </summary>
    /// <returns></returns>
    private List<ContactInformation> getAnyContactInfoAndReturnFilteredResults()
    {
        Console.WriteLine("Enter any detail of the contact detail to search");
        var anyInfoOfContact = Console.ReadLine();
        var filteredContacts = _IrepositoryInteraction.FilterContacts(anyInfoOfContact!, contacts);
        _IuserInteraction.displayContacts(filteredContacts);
        return filteredContacts;
    }
}

