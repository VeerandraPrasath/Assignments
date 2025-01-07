
public class UserInteraction : IuserInteraction
{
    public void displayContacts(IEnumerable<ContactInformation> contacts)
    {
        if (contacts.Count() == 0)
        {
            Console.WriteLine("There is no contacts !!");
        }
        else
        {
            List<ContactInformation> Sortedlist = contacts.OrderBy(a=>a.Name).ToList();
            Console.WriteLine("The Contact names are listed :");

            for (int i = 0; i < Sortedlist.Count(); i++)
            {
                Console.WriteLine($"{i + 1}.{Sortedlist.ElementAt(i).ToString()}");
            }
        }
    }

    public void displayMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void displayOption()
    {
        Console.Write("\nSelect the bleow  option to perform the  operation");
        Console.WriteLine("\n [V]iew \n [A]dd \n [E]dit \n [D]elete \n [S]earch \n [C]lose \nSelect your option:");
    }


}
