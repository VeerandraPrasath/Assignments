namespace OOPs
{
    public class Rectangle : Shape
    {
        private readonly float _length, _width;
        public Rectangle(float length,float breath,string color)
        {
                  _length = length;
                    _width = breath;
                   base.Color = color;
        }
        public override void CalculateArea()
        {
            base.Area = _length * _width;
        }
        public override void PrintDetails()
        {
            Console.WriteLine($"\nShape : {nameof(Rectangle)} \n Color :{base.Color} \n Length:{_length}\n Width :{_width} \n Area :{base.Area}");

        }
    }

}
