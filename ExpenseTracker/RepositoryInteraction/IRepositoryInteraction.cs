// See https://aka.ms/new-console-template for more information
public interface IRepositoryInteraction
{
    public User isUserPresent(string username);
    public bool CreateNewUser();
    public void loadAllData();
    public Date isDatePresent(DateTime date,User user);

}

