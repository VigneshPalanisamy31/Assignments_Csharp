using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorHandling
{
    internal class CustomException
    {
        /// <summary>
        /// Function to print index of an array element
        /// </summary>
        /// <param name="array"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public static void AccessArrayElement(int[] array)
        {
            Console.WriteLine("Enter the index for search :");
            int.TryParse(Console.ReadLine(), out int index);
            if (index < 0 || index > array.Length)
                throw new IndexOutOfRangeException($"Custom Message : Index {index} is out of bounds for array of length {array.Length}");
            Console.WriteLine($"Element at index {index} : {array[index - 1]}");
        }

        /// <summary>
        /// Function to get user input for array
        /// </summary>
        /// <returns>integer array or exceptions if any</returns>
        /// <exception cref="Exception"></exception>
        public static int[] GetArrayElements()
        {
            Console.WriteLine("Enter the size of array:");
            int size = GetArraySize();
            if (size == 0)
                throw new Exception("Created array cannot store elements");
            int []array=new int[size];
            Console.WriteLine("Enter the elements of array:");
            for (int i=0;i<size;i++)
                array[i]=int.Parse(Console.ReadLine());
            return array;
        }

        /// <summary>
        /// Function to get array size from user
        /// </summary>
        /// <returns>array size or exceptions if any</returns>
        /// <exception cref="InvalidUserInputException"></exception>
        public static int GetArraySize()
        {
            int.TryParse(Console.ReadLine(), out int arraySize);
            if(arraySize>=0)
            {
                return arraySize;
            }
            else
            {
                throw new InvalidUserInputException("Custom Message : Execution interrupted due to an invalid array size \n(Array size must be greater than 0)");

            }
        }


    }
}
