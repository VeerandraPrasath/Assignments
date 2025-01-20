namespace OOPs
{
    /// <summary>
    /// Class inherit from the shape class
    /// </summary>
    public class Circle : Shape
    {
        private readonly float _radius;

        /// <summary>
        /// Initialize the color and radius value
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="color"></param>
        public Circle(float radius, string color)
        {
            _radius = radius;
            base.color = color;

        }

        /// <summary>
        /// Calculate the area
        /// </summary>
        public override void CalculateArea()
        {
            base.Area = _radius * _radius;
        }

        /// <summary>
        /// Print the details of the shape Circle
        /// </summary>
        public override void PrintDetails()
        {
            Console.WriteLine($"\nShape : {nameof(Circle)} \n color :{base.color} \n Radius :{_radius} \n Area :{base.Area}");
        }



    }

}
