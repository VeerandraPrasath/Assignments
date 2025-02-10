
using System.Runtime.InteropServices;

namespace ValueAndReferenceTypes
{
    public class Task2
    {
        public void Run()
        {
            LargeNumberOfReferenceType();
            LargeNumberOfValueType();
        }
        public void LargeNumberOfValueType()
        {
          
            for (int i = 0; i < 1000; i++)
            {
               ValueType valueType = new ValueType(i);
            }
        }

        public void LargeNumberOfReferenceType()
        {
            for (int i = 0; i < 1000; i++)
            {
                int[] referenceType = new int[i];  
            }
        }
    }
}
