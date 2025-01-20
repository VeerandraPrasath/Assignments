
using System.Text.Json;

/// <summary>
/// <see cref="IFileInteraction"/> handles the file read and write
/// </summary>
public interface IFileInteraction
{

    /// <summary>
    /// <see cref="readAlldata(string)"/> reads the content from file
    /// </summary>
    /// <param name="filePath">Location of the file</param>
    /// <returns>List of <see cref="User"/>/></returns>
    public List<User> readAlldata(string filePath);

    /// <summary>
    /// <see cref="writeData(string, List{User})"/> write the content to file
    /// </summary>
    /// <param name="filePath">Location of the file</param>
    /// <param name="users">Content to be written to the file</param>
    public void writeData(string filePath, List<User> users);
}

/// <summary>
/// <see cref="FileInteraction"/> implements <see cref="IFileInteraction"/>
/// </summary>
public class FileInteraction : IFileInteraction
{
    public List<User> readAlldata(string filePath)
    {
        var fileContents = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<User>>(fileContents);
    }

    public void writeData(string filePath, List<User> users)
    {


        string json = JsonSerializer.Serialize(users[2].Dates[0], new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);

    }
}
