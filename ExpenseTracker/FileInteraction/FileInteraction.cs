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
            var serializationSettings = new JsonSerializerSettings();
            serializationSettings.TypeNameHandling = TypeNameHandling.Objects;
            var jsonString = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<List<User>>(jsonString, serializationSettings);
        }

        public void WriteData(string filePath, List<User> userList)
        { 
            var serializationSettings = new JsonSerializerSettings();
            serializationSettings.TypeNameHandling = TypeNameHandling.Objects;
            var jsonString = JsonConvert.SerializeObject(userList, Formatting.Indented, serializationSettings);
            File.WriteAllText(filePath, jsonString);
        }
    }
}