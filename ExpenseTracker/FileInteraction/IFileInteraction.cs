using ExpenseTracker.UserData;

namespace ExpenseTracker.FileInteractions
{
    /// <summary>
    /// Handles the file interaction
    /// </summary>
    public interface IFileInteraction
    {
        /// <summary>
        /// Reads all content from file
        /// </summary>
        /// <param name="filePath">Path of the file</param>
        /// <returns>returns list of <see cref="User"/>/></returns>
        public List<User> ReadFiledata(string filePath);

        /// <summary>
        /// Writes all contents to file
        /// </summary>
        /// <param name="filePath">Path of the file</param>
        /// <param name="users">Content which written to the file</param>
        public void WriteData(string filePath, List<User> users);
    }
}