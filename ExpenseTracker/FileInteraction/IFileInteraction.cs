// See https://aka.ms/new-console-template for more information
public interface IFileInteraction
{
    List<User> readAlldata();
    bool writeData();
}
public class FileInteraction : IFileInteraction
{
    public List<User> readAlldata()
    {
       return new List<User>();
    }

    public bool writeData()
    {
        return true;
    }
}
