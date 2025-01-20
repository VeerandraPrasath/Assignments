using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPs
{
    /// <summary>
    /// Abstract class contains the common features of Shape
    /// </summary>
    public abstract class Shape
    {
        protected string color { get; set; }
        public float Area { get; set; }

        /// <summary>
        /// Abstract method that calculate the Area
        /// </summary>
        public abstract void CalculateArea();

        /// <summary>
        /// Abstract method that prints the details of the Shape
        /// </summary>
        public abstract void PrintDetails();

    }

}
