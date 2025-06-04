using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueAndReferenceTypes
{
    internal class Program
    {
        public static void Modify(int valueType,ReferenceType referenceType)
        {
            valueType = 200;
            referenceType.referenceString = "Double Century";
        }

        public static void CreateLargeArray(int size)
        {
            int []arrray=new int[size];
            for (int i = 0;i < size;i++)
                arrray[i]=i;
        }
        public static void PerformLargeCalculations()
        {
            int num1 = 11, num2 = 22, num3 = 33, num4 = 44, num5 = 555, num6 = 66, num7 = 77, num8 = 88, num9 = 99, num10=111;
            int product = num1 * num2 * num3 * num4 * num5 * num6 * num7 * num8 * num9 * num10;
        }
        public static void Main(string[] args)
        {
            int valueType = 100;
            ReferenceType referenceType = new ReferenceType("Century");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Values of value type and reference type before method call :\n");
            Console.ResetColor();
            Console.WriteLine($"ValueType (int) : {valueType}\n" +$"\nReferenceType (class) : {referenceType.referenceString}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCalling method to modify both....\n");
            Console.ResetColor();

            Modify(valueType, referenceType);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Values of value type and reference type before after call :\n");
            Console.ResetColor();
            Console.WriteLine($"ValueType (int) : {valueType}\n" + $"\nReferenceType (class) : {referenceType.referenceString}");

            CreateLargeArray(1000000);
            PerformLargeCalculations();


            Console.ReadKey();


        }
    }
}
