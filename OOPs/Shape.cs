using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPs
{
    public abstract class Shape
    {
         protected string Color { get; set; }
         public float Area { get; set; }
         public abstract void  CalculateArea();
         public abstract void    PrintDetails();

    }

}
