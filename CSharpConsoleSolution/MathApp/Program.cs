namespace MathApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            new MathematicalCalculation().PerformMathematicalCalculation();
        }
    }
    public class MathematicalCalculation
    {
        public  void PerformMathematicalCalculation()
        {
            bool isExit = false;
            Console.Write("Enter number 1 :");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter number 2 :");
            int num2 = int.Parse(Console.ReadLine());
            while (!isExit)
            {
                int ans=0;
                Console.WriteLine("\n[1] Add\n[2] Subtract\n[3] Multiply\n[4] Divide\n[5] Exit\nEnter the choice :");
                string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                       ans=Add(num1, num2);
                        break;
                    case "2":
                       ans= Subtract(num1, num2);
                        break;
                    case "3":
                       ans= Multiply(num1, num2);
                        break;
                    case "4":
                       ans= Divide(num1, num2);
                        break;
                    case "5":
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice !");
                        break;
                }
                Console.WriteLine("Answer is "+ans);
            }
        }

        private int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        private int Subtract(int num1, int num2)
        {
            return num1 - num2;
        }

        private int Multiply(int num1, int num2)
        {
            return num1 * num2;
        }

        private int Divide(int num1, int num2)
        {
            return num1 / num2;
        }
    }
}
