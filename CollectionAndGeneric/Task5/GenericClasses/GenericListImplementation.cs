namespace CollectionAndGeneric.Task5.GenericClasses
{
    public class GenericListImplementation<T>
    {
        private List<T> _list;
        public GenericListImplementation()
        {
            _list = new List<T>();
        }
        public void Add(T item)
        {
            _list.Add(item);
        }
        public bool Remove(T item)
        {
            return _list.Remove(item);
        }
        public bool Contains(T item)
        {
            return _list.Contains(item);
        }
        public void DisplayAll()
        {
            foreach (var item in _list)
            {
                Console.WriteLine(item);
            }
        }
    }
}



