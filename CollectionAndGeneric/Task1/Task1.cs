namespace CollectionAndGeneric.Task1
{
    /// <summary>
    /// Class to implement task1
    /// </summary>
    public class Task1
    {
        /// <summary>
        /// List to store titles
        /// </summary>
        public List<string> TitleList { get; set; }

        /// <summary>
        /// Constructor to initialize values
        /// </summary>
        public Task1()
        {
            TitleList = new List<string>();
        }

        /// <summary>
        /// Invoke all the methods
        /// </summary>
        public void Run()
        {
            Console.WriteLine("List implementation");
            Console.WriteLine("______________________");
            Add();
            Remove();
            CheckBookTitle();
            DisplayAllTitle();
            Console.WriteLine("***********************");
        }

        /// <summary>
        /// Add titles to the _list
        /// </summary>
        public void Add()
        {
            int n = 5;
            Console.WriteLine("Enter five book titles to add :");
            for (int i = 0; i < n; i++)
            {
                TitleList.Add(Console.ReadLine());
            }
            Console.WriteLine("Titles added Successfully !");
            Console.WriteLine("______________________");
           
        }

        /// <summary>
        /// Remove title from the _list
        /// </summary>
        public void Remove()
        {
            Console.WriteLine("Enter the Book title to remove :");
            string titleToRemove = Console.ReadLine();
            bool result = TitleList.Remove(titleToRemove);
            if (result)
            {
                Console.WriteLine("Removed successfully !");
            }
            else
            {
                Console.WriteLine("Title not found to remove");
            }
            Console.WriteLine("______________________");
        }

        /// <summary>
        /// Check title exist
        /// </summary>
        public void CheckBookTitle()
        {
            Console.WriteLine("Enter the title to check :");
            string titleTocheck = Console.ReadLine();
            bool result = TitleList.Contains(titleTocheck);
            if (result)
            {
                Console.WriteLine($"Title {titleTocheck} present in the _list ");
            }
            else
            {
                Console.WriteLine("Title not found in the _list");
            }
            Console.WriteLine("______________________");
        }

        /// <summary>
        /// Display titles in the _list
        /// </summary>
        public void DisplayAllTitle()
        {
            Console.WriteLine("All Titles :");
            Console.WriteLine("______________________");
            foreach (var title in TitleList)
            {
                Console.WriteLine(title);
            }
            Console.WriteLine("______________________");
        }
    }
}
