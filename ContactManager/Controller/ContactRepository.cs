using System.Text.RegularExpressions;
using ContactManager.UserInteraction;
using ContactManager.Model;

namespace ContactManager.Controller
{
    /// <summary>
    /// Implements <see cref="IContactRepository"/>
    /// </summary>
    public class ContactRepository : IContactRepository
    {
        private readonly IUserInteraction _userInteraction;

        /// <summary>
        /// Injects <see cref="IUserInteraction"/>
        /// </summary>
        /// <param name="userInteraction">User Interaction Interface</param>
        public ContactRepository(IUserInteraction userInteraction)
        {
            _userInteraction = userInteraction;
        }

        public ContactInformation AddNewContact()
        {
            bool isValidInput = false;
            string name, inputPhoneNum, email;
            Console.WriteLine("Provide the below details:");
            do
            {
                Console.WriteLine("Enter Name :");
                name = Console.ReadLine();
                if (name is null || name.Equals(""))
                {
                    Console.WriteLine("Name should not be null !!!");
                }

            } while (name.Equals(""));

            isValidInput = false;
            do
            {
                Console.WriteLine("Enter valid Email :");
                email = Console.ReadLine();
                if (email.Equals(""))
                {
                    Console.WriteLine("Email should not be null !!!");
                    continue;
                }
                if (!Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
                {
                    Console.WriteLine("Invalid Email !!");
                }
                else
                {
                    isValidInput = true;
                }

            } while (email.Equals("") || !isValidInput);

            isValidInput = false;
            do
            {
                Console.WriteLine("Enter Ph no :");
                inputPhoneNum = Console.ReadLine();
                if (inputPhoneNum.StartsWith("+91"))
                {
                    inputPhoneNum = inputPhoneNum.Remove(0, 3);
                }
                if (inputPhoneNum.Equals(""))
                {
                    Console.WriteLine("Phone number should not be null !!!");
                }
                else if (inputPhoneNum.Length != 10 || !inputPhoneNum.All(char.IsDigit))
                {
                    Console.WriteLine("Invalid phone number !");
                }
                else
                {
                    isValidInput = true;
                }
            } while (inputPhoneNum.Equals("") || !isValidInput);

            Console.WriteLine("Notes :");
            var address = Console.ReadLine();
            return new ContactInformation(name!, email!, inputPhoneNum!, address!);
        }

        public void DeleteExisitingContact(ContactInformation contact, List<ContactInformation> contactList)
        {
            contactList.Remove(contact);
            var message = "Contact  details deleted successfully";
            _userInteraction.DisplayMessage(message);
        }

        public void EditExisitingContact(ContactInformation contact)
        {
            bool isContinue = true;
            while (isContinue)
            {
                var displayEditOption = "Select which info need to change \n [N]name \n [E]mail \n [P]hone no \n[NO]tes \nEnter option:";
                _userInteraction.DisplayMessage(displayEditOption);
                var userOption = Console.ReadLine();
                switch (userOption.ToLower())
                {
                    case "n":
                        {
                            Console.WriteLine("Enter new Name :");
                            contact.Name = Console.ReadLine()!;
                            break;
                        }
                    case "e":
                        {
                            Console.WriteLine("Enter new Email :");
                            contact.Email = Console.ReadLine()!;
                            break;
                        }
                    case "p":
                        {
                            Console.WriteLine("Enter new Phone number :");
                            contact.Phone = Console.ReadLine()!;
                            break;
                        }
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
                string userOptionToContinueEdit = Console.ReadLine()!;

                isContinue = userOptionToContinueEdit != "Y" && userOptionToContinueEdit != "y" ? false : true;
            }
            var message = "Contact details are successfully updated !!";
            _userInteraction.DisplayMessage(message);
        }

        public List<ContactInformation> FilteredContacts(string contactDetail, List<ContactInformation> contactList)
        {
            return contactList.Where(contact => contact.Name.Contains(contactDetail) || contact.Email.Contains(contactDetail) || contact.Phone.Contains(contactDetail) || contact.Notes.Contains(contactDetail)).OrderBy(a => a.Name).ToList();
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
                    isValidIndex = index <= filteredList.Count() && index > 0 ? true : false;
            } while (!isNumber || !isValidIndex);
            return filteredList.ElementAt(index - 1);
        }
    }
}