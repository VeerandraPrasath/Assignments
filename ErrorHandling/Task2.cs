namespace ErrorHandling
{
    public class Task2
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
                Console.Write("Enter number of months to store expenditue : ");
                int months = Convert.ToInt32(Console.ReadLine());
                int[] expenditure = new int[months];
                Console.WriteLine("Enter the expenditure for each month : ");
                for (int i = 0; i < months; i++)
                {
                    expenditure[i] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("Enter the index to edit expenditure : ");
                int index = Convert.ToInt32(Console.ReadLine());
                if (index < 0 || index >= months)
                {
                    throw new IndexOutOfRangeException("Invalid index !.Index out of range exception");
                }
                Console.WriteLine("Enter the new expenditure : ");
                expenditure[index] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Expenditure updated successfully !");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Input days cannot be zero !.Divide by zero exception");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
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
