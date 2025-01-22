using ContactManager.Model;

namespace ContactManager.UserInteraction
{

    /// <summary>
    /// <see cref="UserInteraction"/> implements <see cref="IUserInteraction"/>
    /// </summary>
    public class UserInteraction : IUserInteraction
    {


        public void DisplayContacts(IEnumerable<ContactInformation> contacts)
        {
            if (contacts.Count() == 0)
            {
                Console.WriteLine("There is no contacts !!");
            }
            else
            {
                List<ContactInformation> Sortedlist = contacts.OrderBy(a => a.Name).ToList();
                Console.WriteLine("The Contact names are listed :");

                for (int i = 0; i < Sortedlist.Count(); i++)
                {
                    Console.WriteLine($"{i + 1}.{Sortedlist.ElementAt(i).ToString()}");
                }
            }
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void DisplayOption()
        {
            Console.Write("\nSelect the bleow  option to perform the  operation");
            Console.WriteLine("\n [V]iew \n [A]dd \n [E]dit \n [D]elete \n [S]earch \n[CL]ear\n [C]lose \nSelect your option:");
        }
    }
}