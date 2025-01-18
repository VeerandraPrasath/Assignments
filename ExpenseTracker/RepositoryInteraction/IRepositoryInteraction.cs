// See https://aka.ms/new-console-template for more information
public interface IRepositoryInteraction
{
    public User isUserPresent(string username);
    public bool CreateNewUser();
    public void loadAllData();
    public Date isDatePresent(DateTime date,User user);
    public bool deleteRecord(List<IRecord> records, int index,User user);
    void addRecord(IRecord record,Date date);
    void updateRecord(IRecord newRecord,IRecord oldRecord,User user);
    public void writeToFile();

}

