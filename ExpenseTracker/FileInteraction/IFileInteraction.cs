using Newtonsoft.Json;
using ExpenseTracker.UserData;
namespace ExpenseTracker.FileInteraction
{

    /// <summary>
    /// <see cref="IFileInteraction"/> handles the file read and write
    /// </summary>
    public interface IFileInteraction
    {

        /// <summary>
        /// <see cref="ReadAlldata(string)"/> reads the content from file
        /// </summary>
        /// <param name="filePath">Location of the file</param>
        /// <returns>List of <see cref="User"/>/></returns>
        public List<User> ReadAlldata(string filePath);

        /// <summary>
        /// <see cref="WriteData(string, List{User})"/> write the content to file
        /// </summary>
        /// <param name="filePath">Location of the file</param>
        /// <param name="users">Content to be written to the file</param>
        public void WriteData(string filePath, List<User> users);
    }

    /// <summary>
    /// <see cref="FileInteraction"/> implements <see cref="IFileInteraction"/>
    /// </summary>
    public class FileInteraction : IFileInteraction
    {
        public List<User> ReadAlldata(string filePath)
        {
            var vSettings = new JsonSerializerSettings();
            vSettings.TypeNameHandling = TypeNameHandling.Objects;
            var vJsonStr = File.ReadAllText(filePath);
            if (string.IsNullOrWhiteSpace(vJsonStr))
            {
                return new List<User>();
            }
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