namespace Understanding_.Net
{
    public class MathUtils
    {
        public int A { get; set; }

        public int B { get; set; }

        public MathUtils(int a, int b)
        {
            A = a;
            B = b;
        }

        public void run()
        {
            Add(A, B);
            Subtract(A, B);
            Multiply(A, B);
            Divide(A, B);
        }

        public void Add(int a, int b)
        {
            Console.WriteLine($"Addition of {a} and {b} is {a + b}");
        }

        public void Subtract(int a, int b)
        {
            Console.WriteLine($"Subtraction of {a} and {b} is {a - b}");
        }

        public void Multiply(int a, int b)
        {
            Console.WriteLine($"Multiplication of {a} and {b} is {a * b}");
        }

        public void Divide(int a, int b)
        {
            try
            {
                if (b == 0)
                {
                    throw new DivideByZeroException("Cannot divide by zero !");
                }
                Console.WriteLine($"Division of {a} and {b} is {a / b}");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);

            }
        }
    }
}
