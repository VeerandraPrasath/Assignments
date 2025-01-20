namespace OOPs
{
    /// <summary>
    /// Class inherit the features of the Shape class
    /// </summary>
    public class Rectangle : Shape
    {
        private readonly float _length, _width;

        /// <summary>
        /// Constructor initialize the color,length and breath
        /// </summary>
        /// <param name="length"></param>
        /// <param name="breath"></param>
        /// <param name="color"></param>
        public Rectangle(float length, float breath, string color)
        {
            _length = length;
            _width = breath;
            base.color = color;
        }

        /// <summary>
        /// Method calculate the area of Rectangle
        /// </summary>
        public override void CalculateArea()
        {
            base.Area = _length * _width;
        }

        /// <summary>
        /// Method prints the Details of Rectabgle
        /// </summary>
        public override void PrintDetails()
        {
            Console.WriteLine($"\nShape : {nameof(Rectangle)} \n color :{base.color} \n Length:{_length}\n Width :{_width} \n Area :{base.Area}");

        }
    }

}
