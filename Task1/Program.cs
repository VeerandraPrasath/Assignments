namespace Assignment16.Task1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Notifier notifier = new Notifier();
            notifier.OnAction += MessageHandler;
            notifier.PerformAction("Action performed successfully!");
            Console.ReadLine();
        }
        static void MessageHandler(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class Notifier
    {
        public delegate void Notify(string message);

        public event Notify OnAction;

        public void PerformAction(string actionMessage)
        {
            OnAction?.Invoke(actionMessage);
        }
    }

}