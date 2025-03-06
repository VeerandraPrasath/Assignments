namespace ValueAndReferenceLibrary
{
    /// <summary>
    /// Library for Value and Reference types
    /// </summary>
    public class ValueReferenceLibrary
    {
        /// <summary>
        /// Create value type
        /// </summary>
        /// <param name="value"></param>
        public void CreateValueType(int value)
        {
            ValueType valueType = new ValueType(value);
        }

        /// <summary>
        /// Create reference type
        /// </summary>
        /// <param name="value"></param>
        public void CreateReferenceType(int value)
        {
            int[] referenceType = new int[value];
        }
    }

    /// <summary>
    /// Model for ValueType
    /// </summary>
    public struct ValueType
    {
        public int Value { get; set; }

        public ValueType(int value)
        {
            Value = value;
        }
    }

    /// <summary>
    /// Model for Referenec type
    /// </summary>
    public class ReferenceType
    {
        public int Value { get; set; }

        public ReferenceType(int value)
        {
            Value = value;
        }
    }
}
