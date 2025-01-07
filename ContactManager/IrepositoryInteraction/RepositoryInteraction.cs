
using System.Reflection;

public class RepositoryInteraction : IrepositoryInteraction
{
    private readonly IuserInteraction _IuserInteraction;
    public RepositoryInteraction(IuserInteraction IuserInteraction)
    {
        _IuserInteraction = IuserInteraction;
    }
    public ContactInformation addNewContact()
    {
        Console.WriteLine("Provide the below details:");
        Console.WriteLine("Name :");
        var name = Console.ReadLine();
        Console.WriteLine("Email :");
        var email = Console.ReadLine();
        Console.WriteLine("Ph no:");
        var phoneNo = Console.ReadLine();
        Console.WriteLine("Notes :");
        var address = Console.ReadLine();
        return new ContactInformation(name!, email!, phoneNo!, address!);
    }

    public void deleteExisitingContact(ContactInformation contact, List<ContactInformation> contacts)
    {

        contacts.Remove(contact);
        var message = "Contact  details deleted successfully";
        _IuserInteraction.displayMessage(message);


    }

    public void editExisitingContact(ContactInformation contact)
    {
        bool isContinue = true;
        while (isContinue)
        {

            var displayEditOption = "Select which info need to change \n [N]name \n [E]mail \n [P]hone no \n[A]ddess \nEnter option:";
            _IuserInteraction.displayMessage(displayEditOption);

            var userOption = Console.ReadLine();
            switch (userOption)
            {
                case "n":
                case "N":
                    {
                        Console.WriteLine("Enter new Name :");
                        contact.Name = Console.ReadLine()!;
                        break;
                    }
                case "e":
                case "E":
                    {
                        Console.WriteLine("Enter new Email :");
                        contact.Email = Console.ReadLine()!;
                        break;
                    }
                case "p":
                case "P":
                    {
                        Console.WriteLine("Enter new Phone number :");
                        contact.Phone = Console.ReadLine()!;
                        break;
                    }
                case "a":
                case "A":
                    {
                        Console.WriteLine("Enter new Notes :");
                        contact.Notes = Console.ReadLine()!;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid option !!");
                        break;
                    }
            }
            Console.WriteLine("To continue edit press Y or N :");
            string UserOptionToContinueEdit = Console.ReadLine()!;

            isContinue = UserOptionToContinueEdit != "Y" && UserOptionToContinueEdit != "y" ? false : true;

        }

        var message = "Contact details are successfully updated !!";
        _IuserInteraction.displayMessage(message);


    }


    public List<ContactInformation> FilterContacts(string anyInfo, List<ContactInformation> contacts)
    {

        return contacts.Where(contact => contact.Name.Contains(anyInfo) || contact.Email.Contains(anyInfo) || contact.Phone.Contains(anyInfo) || contact.Notes.Contains(anyInfo)).OrderBy(a=>a.Name).ToList();


    }

    public ContactInformation SelectContactBasedOnIndex(List<ContactInformation> filteredList)
    {
        int index;
        bool isNumber = false;
        bool isValidIndex = false;
        if (filteredList.Count() == 1)
        {
            return filteredList[0];
        }
        do
        {
            Console.WriteLine("Select the valid index of the required contact:");
            isNumber = int.TryParse(Console.ReadLine(), out index);
            if (isNumber)
                isValidIndex = index <= filteredList.Count() ? true : false;


        } while (!isNumber || !isValidIndex);
        return filteredList.ElementAt(index - 1);

    }
}