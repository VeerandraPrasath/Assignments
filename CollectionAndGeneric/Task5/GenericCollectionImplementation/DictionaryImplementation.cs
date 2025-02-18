using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionAndGeneric.Task5.GenericClasses;

namespace CollectionAndGeneric.Task5.GenericCollectionImplementation
{
    public class DictionaryImplementation
    {
        public GenericDictionary<string, int> StringIntDictionary { get; set; }
        public GenericDictionary<int,bool>  IntBoolDictionary { get; set; }

        public DictionaryImplementation()
        {
            StringIntDictionary = new GenericDictionary<string, int>();
            IntBoolDictionary = new GenericDictionary<int, bool>();
        }

        public void Run()
        {
            DictionaryImplementationUsingStringAndInt();
            DictionaryImplementationUsingIntAndBool();
        }

        public void DictionaryImplementationUsingStringAndInt()
        {
            Console.WriteLine("Dictionary Implementation using String and Int \n");
            StringIntDictionary.Add("Prasath", 21);
            Console.WriteLine("Added Name : Prasath ,Age :21");
            StringIntDictionary.Add("Arun", 20);
            Console.WriteLine("Added Name : Arun ,Age : 20");
            StringIntDictionary.Add("Pirai", 19);
            Console.WriteLine("Added Name : Pirai ,Age : 19");
            StringIntDictionary.Remove("Pirai");
            Console.WriteLine("Removed Pirai from Dictionary");
            Console.WriteLine($"Age of Arun is { StringIntDictionary.GetValue("Arun")}");
            Console.WriteLine($"Is Prasath Contains in Dictionary ? {StringIntDictionary.Contains("Prasath")}");
        }

        public void DictionaryImplementationUsingIntAndBool()
        {
            Console.WriteLine("Dictionary Implementation using Int and Bool \n");
            IntBoolDictionary.Add(1, true);
            Console.WriteLine("Added Roll no : 1 ,Cleared all subjects :true");
            IntBoolDictionary.Add(2, true);
            Console.WriteLine("Added Roll no : 2 ,Cleared all subjects :true");
            IntBoolDictionary.Add(3, false);
            Console.WriteLine("Added Roll no: 3 ,Cleared all subjects : false");
            IntBoolDictionary.Remove(2);
            Console.WriteLine("Removed roll no 2 from Dictionary");
            Console.WriteLine($"Is roll no 1 passed in all subjects ? {IntBoolDictionary.GetValue(1)}");
            Console.WriteLine($"Is roll no 2 Contains in Dictionary ? {IntBoolDictionary.Contains(2)}");
        }
    }
}

