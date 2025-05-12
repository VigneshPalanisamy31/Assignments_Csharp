using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Rectangle : Shape
    {
        private double _length;
        private double _breadth;
        public double Length { get=>_length; set=>_length=value; }
        public double Breadth { get=>_breadth; set=>_breadth=value; }

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
