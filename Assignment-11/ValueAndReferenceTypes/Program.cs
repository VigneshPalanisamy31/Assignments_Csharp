﻿namespace ValueAndReferenceTypes
{
    public class Program
    {
        /// <summary>
        /// Modifies the value-type and reference-type inputs.
        /// </summary>
        /// <param name="valueType">A value type parameter(int)</param>
        /// <param name="referenceType">A reference type </param>
        public static void Modify(int valueType, ReferenceType referenceType)
        {
            valueType = 200;
            referenceType.Name = "Double Century";
        }

        /// <summary>
        /// Creates an array of integers.
        /// </summary>
        /// <param name="size">Size of an array</param>
        public static void CreateArray(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = i;
            }
        }

        /// <summary>
        /// Performs calculations with local value types.
        /// </summary>
        public static void PerformCalculations()
        {
            float num1 = 11, num2 = 22, num3 = 33, num4 = 44, num5 = 555, num6 = 66, num7 = 77, num8 = 88, num9 = 99, num10 = 111;
            float product = num1 * num2 * num3 * num4 * num5 * num6 * num7 * num8 * num9 * num10;
        }

        public static void Main(string[] args)
        {
            try
            {
                int valueType = 100;
                ReferenceType referenceType = new ReferenceType("Century");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Values of value type and reference type before modifying :\n");
                Console.ResetColor();
                Console.WriteLine($"ValueType (int) : {valueType}\nReferenceType (class) : {referenceType.Name}");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nModifying the values....\n");
                Console.ResetColor();
                Modify(valueType, referenceType);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Values of value type and reference type after modifying :\n");
                Console.ResetColor();
                Console.WriteLine($"ValueType (int) : {valueType}\nReferenceType (class) : {referenceType.Name}");
                CreateArray(1000000);
                PerformCalculations();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}
