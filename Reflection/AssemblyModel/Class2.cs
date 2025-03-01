namespace AssemblyModel
{
    public class Class2
    {
        private string _field2;

        public string Property2 {  get; set; }  

        public event EventHandler AnotherEvent;

        public void Method3()
        {
            Console.WriteLine("Method3 of Class2");
        }


        //public void TriggerEvent()
        //{
        //    AnotherEvent?.Invoke(this, EventArgs.Empty);
        //}
    }
}
