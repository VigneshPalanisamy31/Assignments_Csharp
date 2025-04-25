using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Employee_Hierarchy
{
    internal abstract class Employee
    {
        string _name;
        public string Name { get=>_name; set=>_name=value; }
        double _salary;
        public double Salary { get=>_salary; set=>_salary=value; }
        public abstract double CalculateBonus();
        public abstract void PrintDetails();

    }
}
