namespace Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>
            {
                new Circle(5),
                new Rectangle(4, 6),
                new Triangle(3, 4),
                null,
                new Circle(10)
            };

            foreach (var shape in shapes)
            {
                DisplayShapeDetails(shape);
            }
            Console.ReadLine();
        }

        static void DisplayShapeDetails(Shape shape)
        {
            switch (shape)
            {
                case Circle circle:
                    Console.WriteLine($"Circle: Radius = {circle.Radius}, Area = {circle.CalculateArea():F2}");
                    break;
                case Rectangle rectangle:
                    Console.WriteLine($"Rectangle: Width = {rectangle.Width}, Height = {rectangle.Height}, Area = {rectangle.CalculateArea():F2}");
                    break;
                case Triangle triangle:
                    Console.WriteLine($"Triangle: Base = {triangle.Base}, Height = {triangle.Height}, Area = {triangle.CalculateArea():F2}");
                    break;
                case null:
                    Console.WriteLine("Shape is null.");
                    break;
                default:
                    Console.WriteLine("Unknown shape.");
                    break;
            }
        }
    }

    /// <summary>
    /// Abstract class for all shapes
    /// </summary>
    public abstract class Shape
    {
        public abstract double CalculateArea();
    }

    /// <summary>
    /// Circle class
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Radius of circle
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Constructor to initialize values
        /// </summary>
        /// <param name="radius">Radius</param>
        public Circle(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Calculate the area
        /// </summary>
        /// <returns>Return area</returns>
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    /// <summary>
    /// Rectangle class
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// Width of the rectangle
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Height of the reactangle
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Constructor to initialize the value
        /// </summary>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Calculate the area
        /// </summary>
        /// <returns>Returns area</returns>
        public override double CalculateArea()
        {
            return Width * Height;
        }
    }

    /// <summary>
    /// Triangle class
    /// </summary>
    public class Triangle : Shape
    {
        /// <summary>
        /// Base of the triangle
        /// </summary>
        public double Base { get; set; }

        /// <summary>
        /// Height of the triangle
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Constructor to initialize values
        /// </summary>
        /// <param name="baseLength">Base</param>
        /// <param name="height">Height</param>

        public Triangle(double baseLength, double height)
        {
            Base = baseLength;
            Height = height;
        }

        /// <summary>
        /// Calculate the area
        /// </summary>
        /// <returns>Returns area</returns>
        public override double CalculateArea()
        {
            return 0.5 * Base * Height;
        }
    }
}