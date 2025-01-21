using ContactManager.Model;
namespace ContactManager.Controller
{

    /// <summary>
    /// <see cref="IContactRepository"/> used for the interaction with the contact list
    /// </summary>
    public interface IContactRepository
    {
        /// <summary>
        ///<see cref="AddNewContact"/> Get contact details from user and add as new <see cref="ContactInformation"/>
        /// </summary>
        /// <returns>returns <see cref="ContactInformation"/></returns>
        public ContactInformation AddNewContact();

        /// <summary>
        ///  <see cref="EditExisitingContact(ContactInformation)"/> edits the name,email,phone no and notes of the exisiting contact  
        /// </summary>
        /// <param name="contact">Contact need to be edited</param>
        public void EditExisitingContact(ContactInformation contact);

        /// <summary>
        /// <see cref="DeleteExisitingContact(ContactInformation, List{ContactInformation})"/>  deletes the already existing contact from the contact list
        /// </summary>
        /// <param name="contact">Contact to be deleted</param>
        /// <param name="contactList">All the exisitng contactList</param>
        public void DeleteExisitingContact(ContactInformation contact, List<ContactInformation> contactList);

        /// <summary>
        /// <see cref="SelectContactBasedOnIndex(List{ContactInformation})"/> selects the specific contact based on the index of <see cref="ContactInformation"/>
        /// </summary>
        /// <param name="filteredList">list of <see cref="ContactInformation"/></param>
        /// <returns>returns <see cref="ContactInformation"/></returns>
        public ContactInformation SelectContactBasedOnIndex(List<ContactInformation> filteredList);

        /// <summary>
        /// <see cref="FilteredContacts(string, List{ContactInformation})"/> filters  the contactList which matches the given information
        /// </summary>
        /// <param name="anyInfo">Any detail of the Contact</param>
        /// <param name="contacts">All exisiting contact</param>
        /// <returns>retuns list of <see cref="ContactInformation"/></returns>
        public List<ContactInformation> FilteredContacts(string anyInfo, List<ContactInformation> contacts);

    }
}