using ErrorHandling;

//Task1
Task1 task1 = new Task1();
task1.Run();

//Task2
Task2 task2 = new Task2();
task2.Run();

//Task3
Task3 task3 = new Task3();
task3.Run();


AppDomain currentDomain = AppDomain.CurrentDomain;
currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);

//Task4
Task4 task4 = new Task4();
task4.Run();

static void MyHandler(object sender, UnhandledExceptionEventArgs args)
{
    Exception e = (Exception)args.ExceptionObject;
    Console.WriteLine("Unhandled exception caught : " + e.Message);
}

//Task5
Task5 task5 =new Task5();
task5.Run();    