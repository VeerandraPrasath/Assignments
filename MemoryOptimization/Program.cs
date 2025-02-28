using MemoryOptimization.Task1;
using MemoryOptimization.Task2;

MemoryEater task1 = new MemoryEater();
task1.Allocate();

using (Task2 task2 = new Task2())
{
    task2.GetValuesFromUser();
    task2.Allocate();
}
Console.ReadKey();
