using Understanding_.Net;

Console.Write("Enter value of a");
int a = GetValidInt();
Console.Write("Enter value of b");
int b = GetValidInt();
MathUtils mathUtils = new MathUtils(a, b);
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
            Console.WriteLine("Please enter a valid integer");
        }
    } while (!isInt);
    return a;
}