namespace Assignment16.Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var number = 10;
            Console.WriteLine($" [ Using var ]  Value: {number}, Type: {number.GetType()}");
            //number = "String value"; Error because once we initialize var with a type ,then we are not able to change the type

            dynamic dynamicValue = 20;
            Console.WriteLine($" [ Using dynamic ] Value: {dynamicValue}, Type: {dynamicValue.GetType()}");

            dynamicValue = "String value"; // No error because in dynamic we can able to change the type after it is initialized
            Console.WriteLine($" [ Using dynamic ] Value: {dynamicValue}, Type: {dynamicValue.GetType()}");
            Console.ReadLine();
        }
    }
}