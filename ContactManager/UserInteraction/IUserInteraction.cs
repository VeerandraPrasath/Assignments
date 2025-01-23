using ContactManager.Model;

namespace ContactManager.UserInteraction;

/// <summary>
/// Used to interact with the user
/// </summary>
public interface IUserInteraction
{
    /// <summary>
    /// Display the available options
    /// </summary>
    public void DisplayOption();

    /// <summary>
    /// Displays available contacts
    /// </summary>
    /// <param name="contacts">List of contacts</param>
    
    public void DisplayContacts(IEnumerable<ContactInformation> contacts);

    /// <summary>
    /// Display message
    /// </summary>
    /// <param name="message">message to print</param>
    public void DisplayMessage(string message);
}