/// <summary>
///  Used for the interaction with the contact list
/// </summary>
public interface IrepositoryInteraction
{
    public ContactInformation addNewContact();
    public void editExisitingContact(ContactInformation contact);
    public void deleteExisitingContact(ContactInformation contact,List<ContactInformation> contacts);
   
    public ContactInformation SelectContactBasedOnIndex(List<ContactInformation> filteredList);
    public List<ContactInformation> FilterContacts(string anyInfo, List<ContactInformation> contacts);

}
