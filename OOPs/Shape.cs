using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPs
{
    public abstract class Shape
    {
         public string Color { get; set; }
         public float Area { get; set; }
         public abstract void  CalculateArea();
         public abstract void    PrintDetails();

    }
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
