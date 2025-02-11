namespace ValueAndReferenceTypes
{
    /// <summary>
    /// Used to implement the task2
    /// </summary>
    public class Task2
    {
        /// <summary>
        /// Run the task2
        /// </summary>
        public void Run()
        {
            LargeNumberOfReferenceType();
            LargeNumberOfValueType();
        }

        /// <summary>
        /// Create large number of value type
        /// </summary>
        public void LargeNumberOfValueType()
        {
            for (int i = 0; i < 1000; i++)
            {
                ValueType valueType = new ValueType(i);
            }
        }

        /// <summary>
        /// Create large number of reference type
        /// </summary>
        public void LargeNumberOfReferenceType()
        {
            for (int i = 0; i < 1000; i++)
            {
                int[] referenceType = new int[i];
            }
        }
    }
}
