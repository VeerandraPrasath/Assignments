using ContactManager.ConsoleInteraction;
using ContactManager.Model;
using ContactManager.Controller;
namespace ContactManager.Manager
{

    /// <summary>
    /// <see cref="App"/> starts the flow of application
    /// </summary>
    public class App
    {
        List<ContactInformation> contacts;
        private bool isExit = false;
        private readonly IUserInteraction _IUserInteraction;
        private readonly IContactRepository _IRepositoryInteraction;

        /// <summary>
        /// <see cref="App"/> injects <see cref="IUserInteraction"/> ,<see cref="IContactRepository"/>
        /// </summary>
        /// <param name="iuserInteraction"></param>
        /// <param name="irepositoryInteraction"></param>
        public App(IUserInteraction iuserInteraction, IContactRepository irepositoryInteraction)
        {
            _IUserInteraction = iuserInteraction;
            _IRepositoryInteraction = irepositoryInteraction;
            contacts = new List<ContactInformation>();


        }


        /// <summary>
        /// <see cref="run"/> initialize  the main flow 
        /// </summary>
        public void run()
        {
            while (!isExit)
            {
                _IUserInteraction.DisplayOption();
                var userOption = Console.ReadLine();
                switch (userOption.ToLower())
                {
                    case "v":
                        _IUserInteraction.DisplayContacts(contacts);
                        break;
                    case "a":
                        contacts.Add(_IRepositoryInteraction.AddNewContact());
                        break;
                    case "e":
                        var filteredEditContacts = SearchContacts();
                        if (filteredEditContacts.Count() > 0)
                        {
                            var selectedContact = _IRepositoryInteraction.SelectContactBasedOnIndex(filteredEditContacts);
                            _IRepositoryInteraction.EditExisitingContact(selectedContact);
                        }
                        break;
                    case "d":
                        var filteredDeleteContacts = SearchContacts();
                        if (filteredDeleteContacts.Count() > 0)
                        {

                            var selectedContact = _IRepositoryInteraction.SelectContactBasedOnIndex(filteredDeleteContacts);
                            _IRepositoryInteraction.DeleteExisitingContact(selectedContact, contacts);
                        }
                        break;
                    case "s":
                        SearchContacts();
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


        /// <summary>
        /// <see cref="SearchContacts"/ > gets any information of the contact and provide the matching contacts
        /// </summary>
        /// <returns>returns list of <see cref="ContactInformation"/></returns>
        private List<ContactInformation> SearchContacts()
        {
            Console.WriteLine("Enter any one detail of the contact to search :");
            var anyInfoOfContact = Console.ReadLine();
            var filteredContacts = _IRepositoryInteraction.FilteredContacts(anyInfoOfContact!, contacts);
            _IUserInteraction.DisplayContacts(filteredContacts);
            return filteredContacts;
        }
    }
}