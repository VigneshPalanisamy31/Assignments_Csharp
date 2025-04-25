using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Rectangle : Shape
    {
        double _length;
        double _breadth;
        public double Length { get; set; }
        public double Breadth { get; set; }

        public override double CalculateArea()
        {
            return Length * Breadth;
        }

        public override void PrintDetails()
        {
            Console.WriteLine($"This is a {Color} colored rectangle with area {CalculateArea()} sq.u");
        }
    }
}
