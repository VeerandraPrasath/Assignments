using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionAndGeneric.Task5.GenericClasses;

namespace CollectionAndGeneric.Task5.GenericCollectionImplementation
{
    public class GenericDictionaryUsingStringAndInteger
    {
        public GenericDictionaryImplementation<string, int> StudentDictionary { get; set; }
        public GenericDictionaryUsingStringAndInteger()
        {
            StudentDictionary = new GenericDictionaryImplementation<string, int>();
        }

        public void Run()
        {
            AddStudents();
            RemoveStudent();
            DisplayStudents();
        }

        public void AddStudents()
        {
            int numberOfStudents = 5;
            for (int i = 0; i < numberOfStudents; i++)
            {
                Console.Write("Enter the name of student " + (i + 1) + ": ");
                string name = Console.ReadLine();
                Console.Write("Enter the grade of student " + (i + 1) + ": ");
                int grade = int.Parse(Console.ReadLine());
                StudentDictionary.Add(name, grade);
            }
        }

        public void RemoveStudent()
        {
            Console.WriteLine("Enter the name of student to remove: ");
            string name = Console.ReadLine();
            if (StudentDictionary.Contains(name))
            {
                StudentDictionary.Remove(name);
                Console.WriteLine("Student removed.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void DisplayStudents()
        {
            Console.WriteLine("Students in the dictionary: ");
            StudentDictionary.DisplayAll();
        }
    }
}

