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
        public List<User> ReadFileData();

        /// <summary>
        /// Writes all contents to file
        /// </summary>
        public bool WriteData();
    }
}
