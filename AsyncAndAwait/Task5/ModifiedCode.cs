namespace Task5
{
    /// <summary>
    /// Modifed code
    /// </summary>
    public class ModifiedCode
    {
        AutoResetEvent event1 = new AutoResetEvent(false);
        System.Timers.Timer tmr;

        /// <summary>
        /// Constructor to initialzie value
        /// </summary>
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

        /// <summary>
        /// Method 1
        /// </summary>
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