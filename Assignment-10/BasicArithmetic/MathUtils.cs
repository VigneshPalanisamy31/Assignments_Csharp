namespace BasicArithmetic
{
    internal class MathUtils
    {
        /// <summary>
        /// Function to return sum of two numbers.
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns>Sunm of two numbers</returns>
        public static float Add(float firstNumber, float secondNumber)
        {
            return firstNumber + secondNumber;
        }

        /// <summary>
        /// Function to return difference between two numbers.
        /// </summary>
        /// <param name="secondNumber"></param>
        /// <param name="firstNumber"></param>
        /// <returns></returns>
        public static float Subtract(float secondNumber, float firstNumber)
        {
            return firstNumber - firstNumber;
        }

        /// <summary>
        /// Function to return product of two numbers
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns></returns>
        public static float Multiply(float firstNumber, float secondNumber) 
        { 
            return firstNumber * secondNumber;
        }

        /// <summary>
        /// Function to return quotient after division
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns></returns>
        public static float Divide(float firstNumber, float secondNumber)
        {
            try
            {
                return firstNumber / secondNumber;
            }
            catch(Exception e)
            {
                Console.WriteLine("Execution interrupted due to an attempt to divide by 0 ");
                return 0;
            }
        }
    }
}
