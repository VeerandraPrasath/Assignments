namespace CollectionAndGeneric.Task5.GenericClasses
{
    /// <summary>
    /// Class to implement generic _list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericList<T>
    {
        private List<T> _list;

        /// <summary>
        /// Constructor to initialize value
        /// </summary>
        public GenericList()
        {
            _list = new List<T>();
        }

        /// <summary>
        /// Add element to _list
        /// </summary>
        /// <param name="item">element to add</param>
        public void Add(T item)
        {
            _list.Add(item);
        }

        /// <summary>
        /// Remove the element
        /// </summary>
        /// <param name="item">item to remove</param>
        /// <returns>returns true if removed else false</returns>
        public bool Remove(T item)
        {
            return _list.Remove(item);
        }

        /// <summary>
        /// Checks element present in the _list
        /// </summary>
        /// <param name="item">item to search</param>
        /// <returns>returns true if present else false</returns>
        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        /// <summary>
        /// Display all the elements in the _list
        /// </summary>
        public void DisplayAll()
        {
            foreach (var item in _list)
            {
                Console.WriteLine(item);
            }
        }
    }
}



