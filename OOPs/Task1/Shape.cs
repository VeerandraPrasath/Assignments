using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPs.Task1
{
    /// <summary>
    /// Stores shape features
    /// </summary>
    public abstract class Shape
    {
        protected string color { get; set; }

        protected double area { get; set; }

        /// <summary>
        /// Calculate the area
        /// </summary>
        public abstract void CalculateArea();

        /// <summary>
        /// Display Shape details
        /// </summary>
        public virtual void PrintDetails()
        {
            Console.WriteLine($"Color : {color}  Area : {area}");
        }

    }

}
