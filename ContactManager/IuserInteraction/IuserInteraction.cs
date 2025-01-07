// See https://aka.ms/new-console-template for more information



public interface IuserInteraction
{
    public void displayOption();
    
    public void displayContacts(IEnumerable<ContactInformation> contacts);
    public void displayMessage(string message);
}
