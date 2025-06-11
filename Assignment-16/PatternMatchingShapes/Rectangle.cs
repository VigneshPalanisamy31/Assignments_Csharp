using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatchingShapes
{
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height, string colour)
        {
            Width = width;
            Height = height;
            Colour = colour;
        }

        public override double CalculateArea() => Width * Height;
    }
}
