# Title : Async And Await

## Description :
### Task 1
In this task, Used the 'async' and 'await' keywords to make the code working asynchronously.Also used 'HttpClient' class to get the data from the URl and display it on the console.

![18_task1](https://github.com/user-attachments/assets/652299d4-aee2-4292-a20c-9cca7bfb89d0)

## Task2
In this task,Used the TPL(Task Parallel Library) for iterating over the array asynchronously and display the square of the data on the console.

![18Task2_1](https://github.com/user-attachments/assets/2a74a2fa-6578-4481-94dd-d761ada75809)

![18Task2_2](https://github.com/user-attachments/assets/b282df79-c786-4f58-8b9e-78962facd547)


## Task3
Created separate thread classes for individual methods to run all the methods parallelly and display the results of the methods after all the execution of methods.

![18task3](https://github.com/user-attachments/assets/bb0f6301-ce6d-4060-aa74-5d8b987d2856)

## Task4
Created multiple async methods to achieve the multi-layered Async and Await operations .Each method gives the result which was used as an input of another and process it.

![18_task4](https://github.com/user-attachments/assets/2101da18-e427-4e3e-9d75-f33556cecd58)

## Task5
The given starter code has no dead lock situvation occured.So ,I have created a dead lock  code by own and it is given below<br><br>
```csharp
    public class StarterCode
    {
        AutoResetEvent event1 = new AutoResetEvent(false);

        public void Method1()
        {
            lock (this)
            {
                Console.WriteLine("Thread1 Entering method1");
                event1.WaitOne();
                Console.WriteLine("Released event1");
                Console.WriteLine("THREAD Exiting method1");
            }
        }

        public void Method2()
        {
            lock (this)
            {
                Console.WriteLine("Thread 2 Entering method2");
                Console.WriteLine("Thread Exiting method 2");
            }
        }
    }
```
In the above code, I have created a deadlock situation by using the lock keyword in the method1 and method2. When the thread1 enters the method1 and locks the object, it waits for the event1 to be released. But the thread2 enters the method2 and locks the object. Now the thread1 is waiting for the event1 to be released and the thread2 is waiting for the object to be released. So, this is a deadlock situation.

#### Resolve the deadlock situation
The dead lock can be resolve by releasing the event at some time,So that the thread1 comeplete the method1 and release the object .Then the thread2 can enter into the method2 and complete the execution .The resolved code is given below

```csharp
    public class ModifiedCode
    {
        AutoResetEvent event1 = new AutoResetEvent(false);
        System.Timers.Timer tmr;

        public ModifiedCode()
        {
            tmr = new System.Timers.Timer(3000);
            tmr.Elapsed += OnTmrElapsed;
            tmr.AutoReset = false;
        }

        private void OnTmrElapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            event1.Set();
            Console.WriteLine("Event realsed inside Elapsed method");
            tmr.Stop();
        }

        public void Method1()
        {
            lock (this)
            {
                tmr.Start();
                Console.WriteLine("Thread1 Entering method1 ");
                event1.WaitOne();
                Console.WriteLine("Released event1");
                Console.WriteLine("Thread exiting method1");
            }
        }

        public void Method2()
        {
            lock (this)
            {
                Console.WriteLine("Thread 2 Entering method2");
                Console.WriteLine("Thread Exiting method 2");
            }
        }
    }

```
In the above code, I have created a timer object and started the timer in the method1. After 3 seconds, the timer will be elapsed and the event1 will be released. So, the thread1 will complete the method1 and release the object. Then the thread2 can enter the method2 and complete the execution. So, the deadlock situation is resolved by using the timer.

![18task5](https://github.com/user-attachments/assets/4f3e9272-e966-45a4-ae31-13a92fcd9fdd)

### Task 6
In this task,Understand the difference between the "ConfigureAwait(true)" and "ConfigureAwait(false)" in the async and await operations .The ConfigureAwait(true) will continue on the captured context and ConfigureAwait(false) will not continue on the captured context.Also used "Thread.CurrentThread.ManagedThreadId" to get the thread id of the current thread.

![18Task6](https://github.com/user-attachments/assets/e799d9f5-d08e-4c7b-8a1a-b36c92aaea53)


### Task 7
In this task,Understand the pros and cons of returning the task and void.These methods throw an exception.During this time ,the method which return task will handle the exception but the method with void can't.This was used and understood  in this task.

![18_task71](https://github.com/user-attachments/assets/11bbc68c-f60d-411c-9d39-6171911af654)

![18_task_72](https://github.com/user-attachments/assets/1ae98db4-1ab7-4a94-96ed-c46c07001770)

