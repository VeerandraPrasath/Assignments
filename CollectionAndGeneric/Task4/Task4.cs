using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAndGeneric.Task4
{
    public class Task4
    {
        public Dictionary<string, int> StudentDictionary { get; set; }
        public Task4()
        {
            StudentDictionary = new Dictionary<string, int>();
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
            if (StudentDictionary.ContainsKey(name))
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
            foreach (KeyValuePair<string, int> student in StudentDictionary)
            {
                Console.WriteLine(student.Key + " - " + student.Value);
            }
        }
    }
}
