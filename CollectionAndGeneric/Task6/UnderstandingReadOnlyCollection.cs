namespace CollectionAndGeneric.Task6
{
    public class UnderstandingReadOnlyCollection
    {
        public void Run()
        {
            PrintDictionary(GenerateDictionary());
            ModifyDictionary();
        }

        public IReadOnlyDictionary<string, int> GenerateDictionary()
         {
            Dictionary<string,int> dictionary = new Dictionary<string,int>();
            dictionary.Add("Prasath", 21);
            dictionary.Add("Pirai", 20);

            return dictionary;
        }

        public void PrintDictionary(IReadOnlyDictionary<string, int> readonlyDictionary)
        {
            foreach (var key in readonlyDictionary)
            {
                Console.WriteLine($"Key :{key} Value : {key.Value} ");
            }
        }

        public void ModifyDictionary()
        {
            IReadOnlyDictionary<string, int> dictionary = GenerateDictionary();
            dictionary["Prasath"] = 10; //  Throw an error because IReadOnlyDictionary is immutable 
        }
    }
}
