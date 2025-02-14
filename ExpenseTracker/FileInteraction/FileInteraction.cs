using ExpenseTracker.UserData;

namespace ExpenseTracker.FileInteraction
{
    /// <summary>
    /// Implements <see cref="IFileInteraction"/>
    /// </summary>
    public class FileInteraction : IFileInteraction
    {
        public List<User> ReadFileData()
        {
            return new List<User>();
        }

        public bool WriteData()
        {
            return true;
        }
    }
}
