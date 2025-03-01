using System;
using System.Reflection;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person
            {
                Name = "Prasath",
                Age = 30,
                Email = "prasath@gmail.com"
            };

            DynamicObjectInspector inspector = new DynamicObjectInspector();

            inspector.InspectObject(person);
        }
    }

    public class DynamicObjectInspector
    {
        public void InspectObject(object obj)
        {
            Type type = obj.GetType();
            Console.WriteLine($"Inspecting object of type: {type.FullName}\n");

            PropertyInfo[] properties = type.GetProperties();

            foreach (var property in properties)
            {
                object value = property.GetValue(obj);
                Console.WriteLine($"Property: {property.Name}, Value: {value}");
            }

            Console.WriteLine("\nEnter the property name to change or type 'exit' to quit):");
            string propertyName = Console.ReadLine();

            if(propertyName.ToLower() != "exit")
            {
                Console.WriteLine("Enter the new value:");
                string newValue = Console.ReadLine();
                SetPropertyValue(obj, propertyName, newValue);
                Console.WriteLine($"\nUpdated Property {propertyName} value to {newValue}:");
            }
        }

        private void SetPropertyValue(object obj, string propertyName, string newValue)
        {
            Type type = obj.GetType();
            PropertyInfo property = type.GetProperty(propertyName);

            if (property != null && property.CanWrite)
            {
                    object convertedValue = Convert.ChangeType(newValue, property.PropertyType);
                    property.SetValue(obj, convertedValue);
                    Console.WriteLine($"Property '{propertyName}' updated to: {convertedValue}");
            }
            else
            {
                Console.WriteLine($"Property '{propertyName}' not found.");
            }
        }
    }
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Email { get; set; }
        }
    }
