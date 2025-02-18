namespace CollectionAndGeneric.Task1
{
    public class Task1
    {
        public List<string> TitleList { get; set; }

        public Task1()
        {
            TitleList = new List<string>();
        }

        public void Run()
        {
            Add();
            Remove();
            CheckBookTitle();
            DisplayAllTitle();
        }
        public void Add()
        {
            int n = 5;
            Console.WriteLine("Enter five book titles to add :");
            for (int i = 0; i < n; i++)
            {
                TitleList.Add(Console.ReadLine());
            }
            Console.WriteLine("Titles added Successfully !");
        }

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
        }

        public void CheckBookTitle()
        {
            Console.WriteLine("Enter the title to check :");
            string titleTocheck = Console.ReadLine();
            bool result = TitleList.Contains(titleTocheck);
            if (result)
            {
                Console.WriteLine($"Title {titleTocheck} present in the list ");
            }
            else
            {
                Console.WriteLine("Title not found in the list");
            }
        }

        public void DisplayAllTitle()
        {
            Console.WriteLine("All Titles :");
            foreach (var title in TitleList)
            {
                Console.WriteLine(title);
            }
        }
    }
}
