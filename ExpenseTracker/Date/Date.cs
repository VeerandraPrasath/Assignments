// See https://aka.ms/new-console-template for more information
public class Date
{
    public DateTime CurrentDate;
    public List<IRecord> records;
    public Date()
    {
            
    }
    public Date(DateTime date)
    {
        CurrentDate = date;
        records=new List<IRecord>();    
    }
}

