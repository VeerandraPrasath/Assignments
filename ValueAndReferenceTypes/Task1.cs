
using System;

namespace ValueAndReferenceTypes
{
    public class Task1
    {
        public void Run()
        {
            ValueType valueType = new ValueType(10);
            ReferenceType referenceType = new ReferenceType(10);
            Console.WriteLine($" Before value change for valueType :{valueType.Value}"); // 10
            Console.WriteLine($" Before value change for referenceType :{referenceType.Value}"); // 10
            changeValues(valueType, referenceType);
            Console.WriteLine($" After value changed for valueType :{valueType.Value}"); // 10
            Console.WriteLine($" After value changed for referenceType :{referenceType.Value}"); // 20

        }

        void changeValues(ValueType valueType, ReferenceType referenceType)
        {
            valueType.Value = 20;
            referenceType.Value = 20;
        }

    }
}
