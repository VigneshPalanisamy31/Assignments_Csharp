using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Circle : Shape
    {
        private double _radius;
        public double Radius { get=>_radius; set=>_radius=value; }
        public override double CalculateArea()
        {

            return 3.14 * Radius * Radius;
        }

        public override void PrintDetails()
        {
            Console.WriteLine($"This is a {Color} colored circle with area {CalculateArea()} sq.u");
        }
    }
}
