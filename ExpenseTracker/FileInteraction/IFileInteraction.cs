// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System.Xml;

public interface IFileInteraction
{
    public List<User> readAlldata(string filePath);
     public void writeData(string filePath, List<User> users);
}
public class FileInteraction : IFileInteraction
{
    public List<User> readAlldata(string filePath)
    {
       var fileContents=File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<User>>(fileContents);
    }

    public void writeData(string filePath,List<User> users)
    {
        //File.WriteAllText(filePath,JsonSerializer.Serialize(users));

        string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }
}
