namespace OOPs.Task1
{
    /// <summary>
    /// Inherits Shape class
    /// </summary>
    public class Circle : Shape
    {
        private readonly double _radius;

        /// <summary>
        /// Initialize values
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="color"></param>
        public Circle(double radius, string color)
        {
            _radius = radius;
            base.color = color;

        }

        /// <summary>
        /// Calculate the area
        /// </summary>
        public override void CalculateArea()
        {
            area = Math.PI*_radius * _radius;
            
        }

        /// <summary>
        /// Display Shape details
        /// </summary>
        public override void PrintDetails()
        {
            Console.WriteLine($"\nShape : {nameof(Circle)} \n color :{color} \n Radius :{_radius} \n area :{area}");
        }



    }

}
