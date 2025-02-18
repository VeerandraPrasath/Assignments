using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAndGeneric.Task5.GenericClasses
{
    public class GenericDictionary<T1, T2>
    {
        private Dictionary<T1, T2> _dictionary;
        public GenericDictionary()
        {

            _dictionary = new Dictionary<T1, T2>();
        }

        public void Add(T1 key, T2 value)
        {
            _dictionary.Add(key, value);
        }

        public void Clear()
        {
            _dictionary.Clear();
        }

        public bool Contains(T1 key)
        {
            return _dictionary.ContainsKey(key);
        }

        public bool Remove(T1 key)
        {
            return _dictionary.Remove(key);

        }

        public T2 GetValue(T1 key)
        {
            return _dictionary[key];
        }

        public void DisplayAll()
        {
            foreach (var item in _dictionary)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
        }
    }

}
