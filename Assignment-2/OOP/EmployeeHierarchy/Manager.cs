using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Hierarchy
{
    internal class Manager : Employee
    {
        public override double CalculateBonus()
        {
            return Salary * .25;
        }

        public override void PrintDetails()
        {
            Console.WriteLine($"\nName : {Name}\nPosition : Manager\nSalary:{Salary}\nBonus Amount: {CalculateBonus()}");
        }
    }
}
