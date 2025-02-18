using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionAndGeneric.Task5.GenericClasses;

namespace CollectionAndGeneric.Task5.GenericCollectionImplementation
{
    /// <summary>
    /// Class implement the GenericDictionary operations
    /// </summary>
    public class DictionaryImplementation
    {
        private GenericDictionary<string, int> _stringIntDictionary;
        private GenericDictionary<int, bool> _intBoolDictionary;

        public DictionaryImplementation()
        {
            _stringIntDictionary = new GenericDictionary<string, int>();
            _intBoolDictionary = new GenericDictionary<int, bool>();
        }

        /// <summary>
        /// Invoke all the methods
        /// </summary>
        public void Run()
        {
            Console.WriteLine("Generic Dictionary Implementation");
            Console.WriteLine("______________________");
            DictionaryImplementationUsingStringAndInt();
            DictionaryImplementationUsingIntAndBool();
        }
 
        /// <summary>
        /// Method perform all dictionary operations with string and int
        /// </summary>
        public void DictionaryImplementationUsingStringAndInt()
        {
            Console.WriteLine("Dictionary Implementation using String and Int \n");
            Console.WriteLine("______________________");
            _stringIntDictionary.Add("Prasath", 21);
            Console.WriteLine("Added Name : Prasath ,Age :21");
            _stringIntDictionary.Add("Arun", 20);
            Console.WriteLine("Added Name : Arun ,Age : 20");
            _stringIntDictionary.Add("Pirai", 19);
            Console.WriteLine("Added Name : Pirai ,Age : 19");
            _stringIntDictionary.Remove("Pirai");
            Console.WriteLine("Removed Pirai from Dictionary");
            Console.WriteLine($"Age of Arun is { _stringIntDictionary.GetValue("Arun")}");
            Console.WriteLine($"Is Prasath Contains in Dictionary ? {_stringIntDictionary.Contains("Prasath")}");
            Console.WriteLine("______________________");
        }

        /// <summary>
        /// Method perform all dictionary operations with int and bool
        /// </summary>
        public void DictionaryImplementationUsingIntAndBool()
        {
            Console.WriteLine("______________________");
            Console.WriteLine("Dictionary Implementation using Int and Bool \n");
            Console.WriteLine("______________________");
            _intBoolDictionary.Add(1, true);
            Console.WriteLine("Added Roll no : 1 ,Cleared all subjects :true");
            _intBoolDictionary.Add(2, true);
            Console.WriteLine("Added Roll no : 2 ,Cleared all subjects :true");
            _intBoolDictionary.Add(3, false);
            Console.WriteLine("Added Roll no: 3 ,Cleared all subjects : false");
            _intBoolDictionary.Remove(2);
            Console.WriteLine("Removed roll no 2 from Dictionary");
            Console.WriteLine($"Is roll no 1 passed in all subjects ? {_intBoolDictionary.GetValue(1)}");
            Console.WriteLine($"Is roll no 2 Contains in Dictionary ? {_intBoolDictionary.Contains(2)}");
            Console.WriteLine("______________________");
        }
    }
}

