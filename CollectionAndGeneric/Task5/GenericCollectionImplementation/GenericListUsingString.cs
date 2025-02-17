﻿using CollectionAndGeneric.Task5.GenericClasses;

namespace CollectionAndGeneric.Task5.GenericCollectionImplementation
{
    public class GenericListUsingString
    {


        public GenericListImplementation<string> _genericStringList;
        public GenericListImplementation<int> _genericIntList;

        public GenericListUsingString()
        {
            _genericStringList = new GenericListImplementation<string>();
            _genericIntList = new GenericListImplementation<int>();
        }

        public void Run()
        {
            ListImplementationUsingString();
            ListImplementationUsingInteger();
        }

        public void ListImplementationUsingString()
        {
            Console.WriteLine("List Implementation using strings\n");
            _genericStringList.Add("Atomic Habits");
            Console.WriteLine("ADDED : Atomic Habits");
            _genericStringList.Add("Psychology of money");
            Console.WriteLine("ADDED : Psychology of money");
            _genericStringList.Add("Rich Dad poor Dad");
            Console.WriteLine(" ADDED : Rich Dad poor Dad");
            Console.WriteLine($"Atomic Habits Removed : {_genericStringList.Remove("Atomic Habits")}");
            Console.WriteLine($"Is Atomic Habits present in List : {_genericStringList.Contains("Atomic Habits")}");
            Console.WriteLine($"Is Rich Dad poor Dad present in List : {_genericStringList.Contains("Rich Dad poor Dad")}");
            _genericStringList.DisplayAll();
        }

        public void ListImplementationUsingInteger()
        {
            Console.WriteLine("List Implementation using integer\n");
            _genericIntList.Add(1);
            Console.WriteLine("ADDED : 1");
            _genericIntList.Add(2);
            Console.WriteLine("ADDED : 2");
            _genericIntList.Add(3);
            Console.WriteLine("ADDED : 3");
            Console.WriteLine($"1 Removed : {_genericIntList.Remove(1)}");
            Console.WriteLine($"Is 1 in List : {_genericStringList.Contains(1)}");
            Console.WriteLine($"Is 2 present in List : {_genericIntList.Contains(2)}");
            _genericIntList.DisplayAll();
        }

    }
}
