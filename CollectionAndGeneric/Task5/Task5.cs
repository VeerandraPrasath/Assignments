
using CollectionAndGeneric.Task5.GenericCollectionImplementation;

namespace CollectionAndGeneric.Task5
{
    public class Task5
    {
        public Task5()
        {
            
        }

        public void Run()
        {
            Console.WriteLine("Generic List operations");
            new GenericListUsingString().Run();
            Console.WriteLine("Generic Stack operations");
            new GenericStackUsingChar().Run();
            Console.WriteLine("Generic Queue operations");
            new GenericQueueUsingString().Run();
            Console.WriteLine("Generic Dictionary operations");
            new GenericDictionaryUsingStringAndInteger().Run();
        }

    }


}



