/// <summary>
/// Bind the information of the contact into single unit
/// </summary>
public class ContactInformation
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Notes { get; set; }

    /// <summary>
    /// Initialize all the information
    /// </summary>
    /// <param name="name"></param>
    /// <param name="email"></param>
    /// <param name="phone"></param>
    /// <param name="notes"></param>
    public ContactInformation(string name, string email, string phone, string notes)
    {
        Name = name;
        Email = email;
        Phone = phone;
        Notes = notes;

    }

    /// <summary>
    /// Override string method to get all the details of the contact 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"Name :{Name} , Email :{Email} ,Phone :{Phone} ,Notes :{Notes}";
    }
}
