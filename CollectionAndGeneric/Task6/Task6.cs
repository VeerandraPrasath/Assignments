namespace CollectionAndGeneric.Task6
{
    /// <summary>
    /// Class implements task6
    /// </summary>
    public class Task6
    {
        private UnderstandIEnumerable _understandIEnumerable;
        private UnderstandingReadOnlyCollection _understandReadOnlyCollection;

        /// <summary>
        /// Constructor initialize value
        /// </summary>
        public Task6()
        {
            _understandIEnumerable = new UnderstandIEnumerable();
            _understandReadOnlyCollection = new UnderstandingReadOnlyCollection();
        }

        /// <summary>
        /// Invoke all methods
        /// </summary>
        public void Run()
        {
            _understandIEnumerable.Run();
            _understandReadOnlyCollection.Run();
        }
    }
}
