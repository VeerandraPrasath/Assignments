using ValueAndReferenceTypes;

Task1 task1 = new Task1();
task1.ExecuteTask1();
Task2 task2 = new Task2();
task2.ExecuteTask2();
Console.ReadKey();

public struct ValueType
{
    public int Value { get; set; }

    public ValueType(int value)
    {
        Value = value;
    }
}

public class ReferenceType
{
    public int Value { get; set; }

    public ReferenceType(int value)
    {
        Value = value;
    }
}