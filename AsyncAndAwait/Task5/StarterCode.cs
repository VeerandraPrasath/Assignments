namespace Task5
{
    /// <summary>
    /// Given starter code
    /// </summary>
    public class StarterCode
    {
        AutoResetEvent event1 = new AutoResetEvent(false);

        /// <summary>
        /// Method 1
        /// </summary>
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

        /// <summary>
        /// Method 2
        /// </summary>
        public void Method2()
        {
            lock (this)
            {
                Console.WriteLine("Thread 2 Entering method2");
                Console.WriteLine("Thread Exiting method 2");
            }
        }
    }
}