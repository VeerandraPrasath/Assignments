namespace userinteraction
{

    /// <summary>
    ///    used to implement the definiton of the IuserInteraction interface
    /// </summary>
    public class UserInteraction : IuserInteraction
    {

        /// <summary>
        ///    Used to display all the existing contact
        /// </summary>
        /// <param name="contacts"></param>
        public void displayContacts(IEnumerable<ContactInformation> contacts)
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


        /// <summary>
        /// Prints the message to console
        /// </summary>
        /// <param name="message"></param>
        public void displayMessage(string message)
        {
            Console.WriteLine(message);
        }


        /// <summary>
        /// Display the available options to perform
        /// </summary>
        public void displayOption()
        {
            Console.Write("\nSelect the bleow  option to perform the  operation");
            Console.WriteLine("\n [V]iew \n [A]dd \n [E]dit \n [D]elete \n [S]earch \n[CL]ear\n [C]lose \nSelect your option:");
        }
    }
}