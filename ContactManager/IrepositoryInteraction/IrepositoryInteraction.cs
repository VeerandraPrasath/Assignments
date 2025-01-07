// See https://aka.ms/new-console-template for more information



public interface IrepositoryInteraction
{
    public ContactInformation addNewContact();
    public void editExisitingContact(ContactInformation contact);
    public void deleteExisitingContact(ContactInformation contact,List<ContactInformation> contacts);
   
    public ContactInformation SelectContactBasedOnIndex(List<ContactInformation> filteredList);
    public List<ContactInformation> FilterContacts(string anyInfo, List<ContactInformation> contacts);

}
