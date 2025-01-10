/// <summary>
///  Used for the interaction with the contact list
/// </summary>
public interface IContactRepository
{
    /// <summary>
    /// Get the new contact details and return as contact object
    /// </summary>
    /// <returns></returns>
    public ContactInformation addNewContact();
    /// <summary>
    /// Edit name,phone no,email and notes of  the existing contact with any detail 
    /// </summary>
    /// <param name="contact"></param>
    public void editExisitingContact(ContactInformation contact);
    /// <summary>
    /// Delete the existing contact with any one detail of the contact
    /// </summary>
    /// <param name="contact"></param>
    /// <param name="contacts"></param>
    public void deleteExisitingContact(ContactInformation contact,List<ContactInformation> contacts);
    /// <summary>
    /// Return contact from the lsit pf list by the user
    /// </summary>
    /// <param name="filteredList"></param>
    /// <returns></returns>
    public ContactInformation SelectContactBasedOnIndex(List<ContactInformation> filteredList);
    /// <summary>
    /// Filter the contacts based on the provoided information
    /// </summary>
    /// <param name="anyInfo"></param>
    /// <param name="contacts"></param>
    /// <returns></returns>
    
    public List<ContactInformation> FilterContacts(string anyInfo, List<ContactInformation> contacts);

}
