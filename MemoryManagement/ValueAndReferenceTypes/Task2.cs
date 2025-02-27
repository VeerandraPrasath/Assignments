namespace ValueAndReferenceTypes
{
    /// <summary>
    /// Used to implement the task2
    /// </summary>
    public class Task2
    {
        /// <summary>
        /// ExecuteTask1 the task2
        /// </summary>
        public void ExecuteTask2()
        {
            LargeNumberOfReferenceType();
            LargeNumberOfValueType();
        }

        /// <summary>
        /// Create large number of value type
        /// </summary>
        private void LargeNumberOfValueType()
        {
            for (int i = 0; i < 1000; i++)
            {
                ValueType valueType = new ValueType(i);
            }
        }

        /// <summary>
        /// Create large number of reference type
        /// </summary>
        private void LargeNumberOfReferenceType()
        {
            for (int i = 0; i < 1000; i++)
            {
                int[] referenceType = new int[i];
            }
        }
    }
}
