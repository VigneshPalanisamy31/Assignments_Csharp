using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorHandling
{
    internal class CustomException
    {
        public static void AccessArrayElement(int[] array)
        {
            Console.WriteLine("Enter the index for search :");
            int.TryParse(Console.ReadLine(), out int index);
            if (index < 0 || index > array.Length)
                throw new IndexOutOfRangeException($"Custom Message : Index {index} is out of bounds for array of length {array.Length}");
            Console.WriteLine($"Element at index {index} : {array[index - 1]}");
        }

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

        public static int GetArraySize()
        {
            int.TryParse(Console.ReadLine(), out int arraySize);
            if(arraySize>=0)
            {
                return arraySize;
            }
            else
            {
                throw new InvalidUserInputException("Custom Message : Execution interupted due to an invalid array size \n(Array size must be greater than 0)");

            }
        }


    }
}
