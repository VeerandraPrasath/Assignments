
public class ContactInformation
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Notes { get; set; }

    public ContactInformation(string name, string email, string phone, string notes)
    {
        Name = name;
        Email = email;
        Phone = phone;
        Notes = notes;

    }
    public override string ToString()
    {
        return $"Name :{Name} , Email :{Email} ,Phone :{Phone} ,Notes :{Notes}";
    }




}
