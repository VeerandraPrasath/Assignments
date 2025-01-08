namespace OOPs
{
    public class Circle:Shape
    {
        private readonly float _radius;
        public Circle(float radius,string color)
        {
            _radius = radius;
            base.Color = color;
            
        }
        public override void CalculateArea()
        {
            base.Area= _radius * _radius;
        }
        public override void PrintDetails()
        {
            Console.WriteLine($"\nShape : {nameof(Circle)} \n Color :{base.Color} \n Radius :{_radius} \n Area :{base.Area}");
        }



    }

}
