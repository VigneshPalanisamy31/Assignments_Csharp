using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Employee_Hierarchy
{
    internal class Developer : Employee
    {
        public override double CalculateBonus()
        {
            return Salary * .15;
        }

        public override void PrintDetails()
        {
            Console.WriteLine($"\nName : {Name}\nPosition : Developer\nSalary:{Salary}\nBonus Amount: {CalculateBonus()}");
        }
    }
}
