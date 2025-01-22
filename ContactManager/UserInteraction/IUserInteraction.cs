using ContactManager.Model;
namespace ContactManager.UserInteraction;

/// <summary>
/// <see cref="IUserInteraction"/> used to handle the interaction with the user
/// </summary>
public interface IUserInteraction
{
    /// <summary>
    /// <see cref="DisplayOption"/> displays the available feature as option
    /// </summary>
    public void DisplayOption();

    /// <summary>
    ///<see cref="DisplayContacts(IEnumerable{ContactInformation})"/> displays available contacts
    /// </summary>
    /// <param name="contacts">List of contacts</param>
    /// 
    public void DisplayContacts(IEnumerable<ContactInformation> contacts);

    /// <summary>
    ///<see cref="DisplayMessage(string)"/> displays message to the console
    /// </summary>
    /// <param name="message">message to print</param>
    public void DisplayMessage(string message);
}