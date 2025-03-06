using ValueAndReferenceLibrary;

namespace ValueAndReferenceTypes
{
    /// <summary>
    /// Used to implement the task2
    /// </summary>
    public class Task2
    {
        private ValueReferenceLibrary _valueReferenceLibrary;

        /// <summary>
        /// Constructor to initialize value
        /// </summary>
        public Task2()
        {
            _valueReferenceLibrary = new ValueReferenceLibrary();
        }
        /// <summary>
        /// ExecuteTask1 the task2
        /// </summary>
        public void ExecuteTask2()
        {
            //LargeNumberOfReferenceType();
            LargeNumberOfValueType();
        }

        /// <summary>
        /// Create large number of value type
        /// </summary>
        private void LargeNumberOfValueType()
        {
            for (int i = 0; i < 100000000; i++)
            {
                _valueReferenceLibrary.CreateValueType(i);
            }
        }

        /// <summary>
        /// Create large number of reference type
        /// </summary>
        private void LargeNumberOfReferenceType()
        {
            for (int i = 0; i < 1000000; i++)
            {
                _valueReferenceLibrary.CreateReferenceType(i);
            }
           
        }
    }
}
