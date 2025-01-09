
using System.Reflection;
using System.Text.RegularExpressions;
using userinteraction;

/// <summary>
/// implements the IrepositoryInteraction to define the method definitions
/// </summary>
public class RepositoryInteraction : IrepositoryInteraction
{
    
    private readonly IuserInteraction _IuserInteraction;

    public RepositoryInteraction(IuserInteraction IuserInteraction)
    {
        _IuserInteraction = IuserInteraction;
    }
    /// <summary>
    /// get contact details from user and add as new contact
    /// </summary>
    /// <returns></returns>
    public ContactInformation addNewContact()
    {
        Console.WriteLine("Provide the below details:");
       
        String name;
        do
        {
            Console.WriteLine("Enter Name :");
            name = Console.ReadLine();
         if(name is null || name.Equals(""))
            {
                Console.WriteLine("Name should not be null !!!");
            }

        }while(name.Equals(""));


        bool isValidEmail = false;
        string email;
        do
        {
            Console.WriteLine("Enter valid Email :");
            email = Console.ReadLine();
            if (email.Equals(""))
            {
                Console.WriteLine("Email should not be null !!!");
                continue;
            }
            if(!Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
             {
                     Console.WriteLine("Invalid Email !!");

            }
            else
            {
                isValidEmail = true;
            }

        } while (email.Equals("") || !isValidEmail);

        
       
        String phoneNo;
        bool isValidPhNo = false;
        do
        {
            Console.WriteLine("Enter Ph no :");
            phoneNo = Console.ReadLine();
            if (phoneNo is null || phoneNo.Equals(""))
            {
                Console.WriteLine("Phone number should not be null !!!");
            }
           else  if (phoneNo.Length != 10 || !phoneNo.All(char.IsDigit))
            {
                Console.WriteLine("Invalid phone number !");
            }
            else
            {
                isValidPhNo = true;
            }


        } while (phoneNo.Equals("") || !isValidPhNo);

        Console.WriteLine("Notes :");
        var address = Console.ReadLine();
        return new ContactInformation(name!, email!, phoneNo!, address!);
    }
    /// <summary>
    ///  delete the already existing contact from the contact list
    /// </summary>
    /// <param name="contact"></param>
    /// <param name="contacts"></param>

    public void deleteExisitingContact(ContactInformation contact, List<ContactInformation> contacts)
    {

        contacts.Remove(contact);
        var message = "Contact  details deleted successfully";
        _IuserInteraction.displayMessage(message);


    }
    /// <summary>
    /// edit the name,email,phone no and notes of the exisiting contact  
    /// </summary>
    /// <param name="contact"></param>
    public void editExisitingContact(ContactInformation contact)
    {
        bool isContinue = true;
        while (isContinue)
        {

            var displayEditOption = "Select which info need to change \n [N]name \n [E]mail \n [P]hone no \n[NO]tes \nEnter option:";
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
                case "NO":
                case "no":
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

    /// <summary>
    /// filters the contacts which matches the given information
    /// </summary>
    /// <param name="anyInfo"></param>
    /// <param name="contacts"></param>
    /// <returns></returns>
    public List<ContactInformation> FilterContacts(string anyInfo, List<ContactInformation> contacts)
    {

        return contacts.Where(contact => contact.Name.Contains(anyInfo) || contact.Email.Contains(anyInfo) || contact.Phone.Contains(anyInfo) || contact.Notes.Contains(anyInfo)).OrderBy(a=>a.Name).ToList();


    }

    /// <summary>
    /// select the specific contact based on the index of the contact
    /// </summary>
    /// <param name="filteredList"></param>
    /// <returns></returns>
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