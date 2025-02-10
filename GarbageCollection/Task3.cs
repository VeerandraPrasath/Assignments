
namespace GarbageCollection
{
    public class Task3
    {
        public void GenerateLargeNumberOfObjects()
        {
            List<ReferenceObject> objectList = new List<ReferenceObject>();
            for (int i = 0; i < 100000; i++)
            {
                ReferenceObject obj=new ReferenceObject(i);
                objectList.Add(obj);
                if(i%2==0)
                {
                    objectList.Remove(obj);
                }
            }
            GC.Collect();
        }

    }
        public class ReferenceObject
        {
            public int Value { get; set; }
            public ReferenceObject(int value)
            {
                Value = value;
            }
        }
}
