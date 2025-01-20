/// <summary>
/// <see cref="Date"/> holds the <see cref="CurrentDate"/> and <see cref="records"/>
/// </summary>
public class Date
{
    public DateTime CurrentDate;
    public int temp = 10;
    public List<IRecord> records;

    /// <summary>
    /// Initialize the date for <see cref="CurrentDate"/>
    /// </summary>
    /// <param name="date"></param>
    public Date(DateTime date)
    {
        CurrentDate = date;
        records = new List<IRecord>();
    }
}

