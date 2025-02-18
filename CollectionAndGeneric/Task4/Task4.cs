namespace CollectionAndGeneric.Task4
{
    /// <summary>
    /// Class to implement task4
    /// </summary>
    public class Task4
    {
        /// <summary>
        /// Dictionary to store string ,int as key value pair
        /// </summary>
        public Dictionary<string, int> StudentDictionary { get; set; }

        /// <summary>
        /// Constructor to initialize values
        /// </summary>
        public Task4()
        {
            StudentDictionary = new Dictionary<string, int>();
        }

        /// <summary>
        /// Invoke all the methods
        /// </summary>
        public void Run()
        {
            Console.WriteLine("Dictionary implementation");
            Console.WriteLine("______________________");
            AddStudents();
            RemoveStudent();
            DisplayStudents();
            Console.WriteLine("***********************");
        }

        /// <summary>
        /// Add student detail to the dictionary
        /// </summary>
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
                Console.WriteLine("______________________");
            }
        }

        /// <summary>
        /// Remove student from the dictionary
        /// </summary>
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
            Console.WriteLine("______________________");
        }

        /// <summary>
        /// Display students in the dictionary
        /// </summary>
        public void DisplayStudents()
        {
            Console.WriteLine("Students in the dictionary: ");
            Console.WriteLine("______________________");
            foreach (KeyValuePair<string, int> student in StudentDictionary)
            {
                Console.WriteLine(student.Key + " - " + student.Value);
            }
            Console.WriteLine("______________________");
        }
    }
}
