// See https://aka.ms/new-console-template for more information

namespace userinteraction
{
    /// <summary>
    ///  used to handle the interaction with the user
    /// </summary>
    public interface IuserInteraction
    {
        public void displayOption();

        public void displayContacts(IEnumerable<ContactInformation> contacts);
        public void displayMessage(string message);
    }
}