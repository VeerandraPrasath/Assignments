using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAndGeneric.Task5.GenericClasses
{
    /// <summary>
    /// Generic dictionary implementation
    /// </summary>
    /// <typeparam name="T1">Type1</typeparam>
    /// <typeparam name="T2">Type2</typeparam>
    public class GenericDictionary<T1, T2>
    {
        /// <summary>
        /// Dictionary to store key value
        /// </summary>
        private Dictionary<T1, T2> _dictionary;

        /// <summary>
        /// Constructor to initialize value
        /// </summary>
        public GenericDictionary()
        {
            _dictionary = new Dictionary<T1, T2>();
        }

        /// <summary>
        /// Add value to dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(T1 key, T2 value)
        {
            _dictionary.Add(key, value);
        }

        /// <summary>
        /// Clear all the elements
        /// </summary>
        public void Clear()
        {
            _dictionary.Clear();
        }

        /// <summary>
        /// Check key present in the dictionary
        /// </summary>
        /// <param name="key">key to search</param>
        /// <returns>returns true if present else false</returns>
        public bool Contains(T1 key)
        {
            return _dictionary.ContainsKey(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(T1 key)
        {
            return _dictionary.Remove(key);
        }

        /// <summary>
        /// Get the value of the key
        /// </summary>
        /// <param name="key">key value</param>
        /// <returns>returns the value of the key</returns>
        public T2 GetValue(T1 key)
        {
            return _dictionary[key];
        }

        /// <summary>
        /// Dispay all the key values in the dictionary
        /// </summary>
        public void DisplayAll()
        {
            foreach (var item in _dictionary)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
        }
    }
}
