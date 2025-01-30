using ExpenseTracker.UserData;

namespace ExpenseTracker.FileInteraction
{
    /// <summary>
    /// Handles the file interaction
    /// </summary>
    public interface IFileInteraction
    {
        /// <summary>
        /// Reads all content from file
        /// </summary>
        /// <returns>returns list of <see cref="User"/>/></returns>
        public List<User> ReadAlldata();


        /// <summary>
        /// Writes all contents to file
        /// </summary>
        public bool WriteData();
    }

    /// <summary>
    /// Implements <see cref="IFileInteraction"/>
    /// </summary>
    public class FileInteraction : IFileInteraction
    {


        public List<User> ReadAlldata()
        {
            return new List<User>();
        }

        public bool WriteData()
        {
            return true;
        }
    }
}
