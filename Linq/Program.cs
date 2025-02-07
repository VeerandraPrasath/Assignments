using Linq;

bool Exit = false;
while(!Exit)
{
    Console.WriteLine("\n[1] Task1\n[2] Task2\n[3] Task3\n[4] Task4\n[5] Task5 \n[6] Exit");
    Console.Write("Enter your choice :");
    string userOption = Console.ReadLine();
    switch (userOption)
    {
        case "1":
            Task1 task = new Task1();
            task.Run();
            break;
        case "2":
            Task2 task2 = new Task2();
            task2.Run();
            break;
        case "3":
            Task3 task3 = new Task3();
            task3.Run();
            break;
        case "4":
            Task4 task4 = new Task4();
            task4.Run();
            break;
        case "5":
            Task5 task5 = new Task5();
            task5.Run();
            break;
        case "6":
            Exit = true;
            break;
        default:
            Console.WriteLine("Invalid Option");
            break;
    }
}
