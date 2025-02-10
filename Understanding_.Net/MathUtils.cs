namespace Understanding_.Net
{
    /// <summary>
    /// Perform basic arithmetic operations
    /// </summary>
    public class MathUtils
    {
        /// <summary>
        /// First number
        /// </summary>
        public int A { get; set; }

        /// <summary>
        /// Second number
        /// </summary>
        public int B { get; set; }

        /// <summary>
        /// Constructor to initialize A and B
        /// </summary>
        /// <param name="a">Frst number</param>
        /// <param name="b">Second Number</param>
        public MathUtils(int a, int b)
        {
            A = a;
            B = b;
        }

        /// <summary>
        /// Initialize all the methods
        /// </summary>
        public void Run()
        {
            Add(A, B);
            Subtract(A, B);
            Multiply(A, B);
            Divide(A, B);
        }

        /// <summary>
        /// Add two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        public void Add(int a, int b)
        {
            Console.WriteLine($"Addition of {a} and {b} is {a + b}");
        }

        /// <summary>
        /// Subtract two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        public void Subtract(int a, int b)
        {
            Console.WriteLine($"Subtraction of {a} and {b} is {a - b}");
        }

        /// <summary>
        /// Multiply two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        public void Multiply(int a, int b)
        {
            Console.WriteLine($"Multiplication of {a} and {b} is {a * b}");
        }

        /// <summary>
        /// Divide two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
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
