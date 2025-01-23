using Newtonsoft.Json;
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
        /// <param name="filePath">Path of the file</param>
        /// <returns>returns list of <see cref="User"/>/></returns>
        public List<User> ReadAlldata(string filePath);

        /// <summary>
        /// Writes all contents to file
        /// </summary>
        /// <param name="filePath">Path of the file</param>
        /// <param name="users">Content which written to the file</param>
        public void WriteData(string filePath, List<User> users);
    }

    /// <summary>
    /// Implements <see cref="IFileInteraction"/>
    /// </summary>
    public class FileInteraction : IFileInteraction
    {

        public List<User> ReadAlldata(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<User>();
            }
            var vSettings = new JsonSerializerSettings();
            vSettings.TypeNameHandling = TypeNameHandling.Objects;
            var vJsonStr = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<List<User>>(vJsonStr, vSettings);
        }

        public void WriteData(string filePath, List<User> userList)
        {

            var vSettings = new JsonSerializerSettings();
            vSettings.TypeNameHandling = TypeNameHandling.Objects;
            var vJsonStr = JsonConvert.SerializeObject(userList, Formatting.Indented, vSettings);
            File.WriteAllText(filePath, vJsonStr);
        }
    }
}