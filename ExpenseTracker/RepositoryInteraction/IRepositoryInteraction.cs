/// <summary>
/// <see cref="IRepositoryInteraction"/> handles all the interaction with the repository
/// </summary>
public interface IRepositoryInteraction
{
    /// <summary>
    /// <see cref="isUserPresent(string)"/> checks wheather the <see cref="User"/> present
    /// </summary>
    /// <param name="username">Name of the <see cref="User"/></param>
    /// <returns>returns User if found else null</returns>
    public User isUserPresent(string username);

    /// <summary>
    /// <see cref="CreateNewUser"/> creates a new <see cref="User"/>
    /// </summary>
    /// <returns>returns true is <see cref="User"/> created else false</returns>
    public bool CreateNewUser();

    /// <summary>
    /// <see cref="loadAllData"/> Load all the date from file
    /// </summary>
    public void loadAllData();

    /// <summary>
    /// <see cref="isDatePresent(DateTime, User)"/> checks wheather the date is present
    /// </summary>
    /// <param name="date">date to be search</param>
    /// <param name="user"><see cref="User"/> to search</param>
    /// <returns>returnt the date if present else null</returns>
    public Date isDatePresent(DateTime date, User user);

    /// <summary>
    /// <see cref="deleteRecord(List{IRecord}, int, User)"/> deletes the exisiting <see cref="IRecord"/>
    /// </summary>
    /// <param name="records">List of <see cref="IRecord"/></param>
    /// <param name="index">Index of the <see cref="IRecord"/></param>
    /// <param name="user">On which <see cref="User"/></param>
    /// <returns></returns>
    public bool deleteRecord(List<IRecord> records, int index, User user);

    /// <summary>
    /// <see cref="addRecord(IRecord, Date)"/> adds <see cref="IRecord"/> on specific date
    /// </summary>
    /// <param name="record"><see cref="IRecord"/> to be added</param>
    /// <param name="date">On which date</param>
    void addRecord(IRecord record, Date date);

    /// <summary>
    /// <see cref="updateRecord(IRecord, IRecord, User)"/> updates the existing <see cref="IRecord"/>
    /// </summary>
    /// <param name="newRecord"><see cref="IRecord"/> to update</param>
    /// <param name="oldRecord"><see cref="IRecord"/> to change</param>
    /// <param name="user">On which <see cref="User"/></param>
    void updateRecord(IRecord newRecord, IRecord oldRecord, User user);

    /// <summary>
    /// <see cref="writeToFile"/> writes the content to file
    /// </summary>
    public void writeToFile();

}

