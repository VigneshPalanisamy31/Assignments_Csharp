using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal abstract class Shape
    {
        string _color;
        public string Color { get=>_color; set=>_color=value; }
        public abstract double CalculateArea();
        public abstract void PrintDetails();
    }
}
