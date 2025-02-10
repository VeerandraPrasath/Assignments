using Understanding_.Net;

Console.Write("Enter number 1 :");
int number1 = GetValidInt();
Console.Write("Enter number 2 :");
int number2 = GetValidInt();
MathUtils mathUtils = new MathUtils(number1, number2);
mathUtils.Run();
Console.ReadKey();

int GetValidInt()
{
    bool isInt = false;
    int a;
    do
    {
        isInt = int.TryParse(Console.ReadLine(), out a);
        if (!isInt)
        {
            Console.WriteLine("Please enter number1 valid integer");
        }
    } while (!isInt);
    return a;
}