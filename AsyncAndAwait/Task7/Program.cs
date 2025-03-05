using System.Runtime.CompilerServices;

namespace Task7
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                 VoidMethod();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
               await TaskMethod();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("End of Main");
        }
        
        private static async void VoidMethod()
        {
            throw new NotImplementedException("Error thrown by VoidMethod");
        }

        private static async Task TaskMethod()
        {
            throw new NotImplementedException("Error thrown by TaskMethod");
        }
    }
}
