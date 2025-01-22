using ContactManager.Model;

namespace ContactManager.Controller
{
    /// <summary>
    /// Used for the interaction with the <see cref="ContactInformation"/> list
    /// </summary>
    public interface IContactRepository
    {
        /// <summary>
        ///Create  new <see cref="ContactInformation"/>
        /// </summary>
        /// <returns>returns <see cref="ContactInformation"/></returns>
        public ContactInformation AddNewContact();

        /// <summary>
        ///  Edits the details the exisiting contact  
        /// </summary>
        /// <param name="contact">Contact need to be edited</param>
        public void EditExisitingContact(ContactInformation contact);

        /// <summary>
        /// Deletes the existing contact 
        /// </summary>
        /// <param name="contact">Contact to be deleted</param>
        /// <param name="contactList">All the exisitng contactList</param>
        public void DeleteExisitingContact(ContactInformation contact, List<ContactInformation> contactList);

        /// <summary>
        /// Selects the specific  <see cref="ContactInformation"/>
        /// </summary>
        /// <param name="filteredList">list of <see cref="ContactInformation"/></param>
        /// <returns>returns <see cref="ContactInformation"/></returns>
        public ContactInformation SelectContactBasedOnIndex(List<ContactInformation> filteredList);

        /// <summary>
        /// Filters  the contactList
        /// </summary>
        /// <param name="anyInfo">Any detail of the Contact</param>
        /// <param name="contacts">All exisiting contact</param>
        /// <returns>retuns list of <see cref="ContactInformation"/></returns>
        public List<ContactInformation> FilteredContacts(string anyInfo, List<ContactInformation> contacts);
    }
}