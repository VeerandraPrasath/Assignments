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

    public abstract class Shape
    {
        public abstract double CalculateArea();
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }
    }

    public class Triangle : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }

        public Triangle(double baseLength, double height)
        {
            Base = baseLength;
            Height = height;
        }

        public override double CalculateArea()
        {
            return 0.5 * Base * Height;
        }
    }
}