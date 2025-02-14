using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionAndGeneric.Task5.GenericClasses;

namespace CollectionAndGeneric.Task5.GenericCollectionImplementation
{
    public class GenericListUsingString
    {

       
        public GenericListImplementation<string> _genericStringList;

        public GenericListUsingString()
        {
            _genericStringList = new GenericListImplementation<string>();
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
                _genericStringList.Add(Console.ReadLine());
            }
            Console.WriteLine("Titles added Successfully !");
        }

        public void Remove()
        {
            Console.WriteLine("Enter the Book title to remove :");
            string titleToRemove = Console.ReadLine();
            bool result = _genericStringList.Remove(titleToRemove);
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
            bool result = _genericStringList.Contains(titleTocheck);
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
            _genericStringList.DisplayAll();
        }
    }
}
