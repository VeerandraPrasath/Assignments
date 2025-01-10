// See https://aka.ms/new-console-template for more information

namespace userinteraction
{
    /// <summary>
    ///  Used to handle the interaction with the user
    /// </summary>
    public interface IuserInteraction
    {
        /// <summary>
        /// Display the available feature as option
        /// </summary>
        public void displayOption();
        /// <summary>
        /// Display available contacts
        /// </summary>
        /// <param name="contacts"></param>
        public void displayContacts(IEnumerable<ContactInformation> contacts);
        /// <summary>
        /// Display message to the console
        /// </summary>
        /// <param name="message"></param>
        public void displayMessage(string message);
    }
}