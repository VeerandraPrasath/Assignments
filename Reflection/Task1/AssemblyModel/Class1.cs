namespace AssemblyModel
{
    public class Class1
    {
        public int Field1;

        public string Property1 { get; set; }

        public event EventHandler SampleEvent;

        public void Method1()
        {
            Console.WriteLine("Method1 of Class1");
        }

        public int Method2(int value)
        {
            return value * 2;
        }
    }
}
