namespace OOPs.Task1
{
    /// <summary>
    /// Inherits Shape class
    /// </summary>
    public class Rectangle : Shape
    {
        private readonly double _length, _width;

        /// <summary>
        /// Constructor initialize value
        /// </summary>
        /// <param name="length">Length</param>
        /// <param name="breath">Breath</param>
        /// <param name="color">Color</param>
        public Rectangle(float length, float breath, string color)
        {
            _length = length;
            _width = breath;
            base.color = color;
        }

        /// <summary>
        /// Calculate area
        /// </summary>
        public override void CalculateArea()
        {
            area = _length * _width;
        }

        /// <summary>
        /// Display Shape details
        /// </summary>
        public override void PrintDetails()
        {
            Console.WriteLine($"\nShape : {nameof(Rectangle)} \n color :{color} \n Length:{_length}\n Width :{_width} \n area :{area}");
        }
    }
}
