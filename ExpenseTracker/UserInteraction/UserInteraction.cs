using ExpenseTracker.Record;
using ExpenseTracker.UserData;

namespace ExpenseTracker.ConsoleInteraction
{
    /// <summary>
    /// Implements <see cref="IUserInteraction"/>
    /// </summary>
    public class UserInteraction : IUserInteraction
    {
        public string GetStringInput(string message)
        {
            string userInput;
            do
            {
                Console.Write($"Enter {message} :");
                userInput = Console.ReadLine();
                if (userInput == "" || userInput is null)
                {
                    Console.WriteLine("******Input should not be null ****");
                }
            } while (userInput == "" || userInput is null);

            return userInput;
        }

        public int GetIntInput(string message)
        {
            bool isValidDigit = false;
            int intValue;
            do
            {
                isValidDigit = int.TryParse(GetStringInput(message), out intValue);
                if (!isValidDigit)
                {
                    Console.WriteLine("Input should be number !");
                }
            } while (!isValidDigit);

            return intValue;
        }

        public DateTime GetDateInput(string message)
        {
            bool isValidDate = false;
            DateTime date;
            do
            {
                string userInput = GetStringInput($"date(format: yyyy - MM - dd) {message}");
                isValidDate = DateTime.TryParse(userInput, out date);
                if (!isValidDate)
                {
                    Console.WriteLine("Invalid date format. Please try again !.");
                }
            } while (!isValidDate);

            return date;
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void DisplayMainMenu()
        {
            Console.WriteLine("\n[1] View Records \n[2] Add Income Record \n[3] Add Expense Record \n[4] Log out\n");
        }

        public Income GetIncomeDetails()
        {
            int amount;
            do
            {
                amount = GetIntInput("amount");
                if (amount <= 0)
                {
                    Console.WriteLine("Amount should be greater than 0 !\n");
                }
            } while (amount <= 0);
            string category = GetStringInput("the category ");

            return new Income(amount, category);
        }

        public Expense GetExpenseDetails()
        {
            int amount;
            do
            {
                amount = GetIntInput("amount");
                if (amount <= 0)
                {
                    Console.WriteLine("Amount should be greater than 0 !\n");
                }
            } while (amount <= 0);
            string category = GetStringInput("the category ");

            return new Expense(amount, category);
        }

        public void DisplayAllRecords(List<Transaction> dates)
        {
            int count = 1;
            if (dates.Count == 0)
            {
                Console.WriteLine("\nNo Transactions !!!\n");

                return;
            }
            foreach (Transaction date in dates)
            {
                foreach (IRecord record in date.RecordList)
                {
                    Console.WriteLine($"{count}.{date.TransactionDate.ToString()} {record}");
                    count++;
                }
            }
        }

        public void DisplayRecordsByDate(Transaction date)
        {
            int count = 1;
            if (date.RecordList.Count == 0)
            {
                Console.WriteLine("\nNo Transactions !!!\n");

                return;
            }
            Console.WriteLine($"Transactions on {date.TransactionDate.ToString()}");
            Console.WriteLine("------------------------------------------------------\n");
            foreach (IRecord record in date.RecordList)
            {
                Console.WriteLine($"{count}.{date.TransactionDate.ToString()} {record}");
                count++;
            }
            Console.WriteLine("------------------------------------------------------\n");
        }
    }
}