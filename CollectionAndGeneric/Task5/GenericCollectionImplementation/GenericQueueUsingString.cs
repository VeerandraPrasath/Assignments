using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionAndGeneric.Task5.GenericClasses;

namespace CollectionAndGeneric.Task5.GenericCollectionImplementation
{
    public class GenericQueueUsingString
    {
        public GenericQueueImplementation<string> PeopleQueue { get; set; }

        public GenericQueueUsingString()
        {
            PeopleQueue = new GenericQueueImplementation<string>();
        }

        public void Run()
        {
            AddPeopleToQueue();
            ServePeople();
            DisplayPeopleInQueue();
        }

        public void AddPeopleToQueue()
        {
            Console.WriteLine("Enter the number of people to add to the queue: ");
            int numberOfPeople = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPeople; i++)
            {
                Console.Write("Enter the name of person " + (i + 1) + ": ");
                string name = Console.ReadLine();
                PeopleQueue.Enqueue(name);
            }
        }

        public void ServePeople()
        {
            if (PeopleQueue.Count == 0)
            {
                Console.WriteLine("No people in the queue.");
                return;
            }
            else
            {
                Console.WriteLine("Enter the number of people to serve: ");
                int numberOfPeople = int.Parse(Console.ReadLine());
                for (int i = 0; i < numberOfPeople; i++)
                {
                    Console.WriteLine($"Served {PeopleQueue.Dequeue()} in the queue: ");
                }
            }
        }

        public void DisplayPeopleInQueue()
        {
            Console.WriteLine("People in the queue: ");
            PeopleQueue.DisplayAll();
        }
    }
}
