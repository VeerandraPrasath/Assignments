namespace ErrorHandling
{
    public class Task4
    {
        public void Run()
        {
            try
            {
                Console.Write("Enter the Salary : ");
                if (!int.TryParse(Console.ReadLine(), out int salary))
                {
                    throw new InvalidUserInputException("Salary should be a number !");
                }
                Console.Write("Enter the number of days worked : ");
                if (!int.TryParse(Console.ReadLine(), out int days))
                {
                    throw new InvalidUserInputException("Days should be a number !");
                }
                int dailySalary = CalculateDailySalary(salary, days);
                Console.WriteLine("Daily Salary : " + dailySalary);
                Console.Write("Enter number of months to store expenditue : ");
                if (!int.TryParse(Console.ReadLine(), out int months))
                {
                    throw new InvalidUserInputException("Months should be a number !");
                }
                int[] expenditure = new int[months];
                Console.WriteLine("Enter the expenditure for each month : ");
                for (int i = 0; i < months; i++)
                {
                    if (!int.TryParse(Console.ReadLine(), out int expense))
                    {
                        throw new InvalidUserInputException("Expense should be a number !");
                    }
                    expenditure[i] = expense;
                }
                Console.WriteLine("Enter the index to edit expenditure : ");
                if (!int.TryParse(Console.ReadLine(), out int index))
                {
                    throw new InvalidUserInputException("Days should be a number !");
                }
                if (index < 0 || index >= months)
                {
                    throw new IndexOutOfRangeException("Invalid index !.Index out of range exception");
                }
                Console.WriteLine("Enter the new expenditure : ");
                if (!int.TryParse(Console.ReadLine(), out int updateExpense))
                {
                    throw new InvalidUserInputException("Expense should be a number !");
                }
                expenditure[index] = updateExpense;
                Console.WriteLine("Expenditure updated successfully !");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidUserInputException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public int CalculateDailySalary(int salary, int days)
        {
            return salary / days;
        }
    }
}
