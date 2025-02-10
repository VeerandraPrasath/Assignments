using Newtonsoft.Json;
using ExpenseTracker.UserData;

namespace ExpenseTracker.FileInteractions
{
    /// <summary>
    /// Implements <see cref="IFileInteraction"/>
    /// </summary>
    public class FileInteraction : IFileInteraction
    {
        public List<User> ReadFiledata(string filePath)
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