namespace ErrorHandling
{
    public class Task1
    {
        public void Run()
        {
            try
            {
                Console.Write("Enter the Salary : ");
                int salary = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the number of days worked : ");
                int days = Convert.ToInt32(Console.ReadLine());
                int dailySalary = salary / days;
                Console.WriteLine("Daily Salary : " + dailySalary);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Input days cannot be zero !.Divide by zero exception");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input !.Format exception");
            }
            finally
            {
                Console.WriteLine("Applicaton Executed Successfully !");
            }
        }
    }
}
