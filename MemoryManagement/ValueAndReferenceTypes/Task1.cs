namespace ValueAndReferenceTypes
{
    /// <summary>
    /// Used to implement the task1
    /// </summary>
    public class Task1
    {
        /// <summary>
        /// ExecuteTask1 the task1
        /// </summary>
        public void ExecuteTask1()
        {
            ValueType valueType = new ValueType(10);
            ReferenceType referenceType = new ReferenceType(10);
            Console.WriteLine($" Before value change for valueType :{valueType.Value}");
            Console.WriteLine($" Before value change for referenceType :{referenceType.Value}");
            changeValues(valueType, referenceType);
            Console.WriteLine($" After value changed for valueType :{valueType.Value}");
            Console.WriteLine($" After value changed for referenceType :{referenceType.Value}"); 
        }

        /// <summary>
        /// Change the values of value type and reference type
        /// </summary>
        /// <param name="valueType">struct as value type</param>
        /// <param name="referenceType">class as reference type</param>
        private void changeValues(ValueType valueType, ReferenceType referenceType)
        {
            valueType.Value = 20;
            referenceType.Value = 20;
        }
    }
}
