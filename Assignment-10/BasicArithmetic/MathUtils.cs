namespace BasicArithmetic
{
    internal class MathUtils
    {
        /// <summary>
        /// Function to return sum of two numbers.
        /// </summary>
        /// <param name="firstNumber">First number to perform calculation on</param>
        /// <param name="secondNumber">Second number to perform calculation on</param>
        /// <returns>Sum of two numbers</returns>
        public static float Add(float firstNumber, float secondNumber)
        {
            return firstNumber + secondNumber;
        }

        /// <summary>
        /// Function to return difference between two numbers.
        /// </summary>
        /// <param name="firstNumber">First number to perform calculation on</param>
        /// <param name="secondNumber">Second number to perform calculation on</param>
        /// <returns>Difference between two numbers</returns>
        public static float Subtract(float firstNumber, float secondNumber)
        {
            return firstNumber - secondNumber;
        }

        /// <summary>
        /// Function to return product of two numbers
        /// </summary>
        /// <param name="firstNumber">First number to perform calculation on</param>
        /// <param name="secondNumber">Second number to perform calculation on</param>
        /// <returns>Product of two numbers</returns>
        public static float Multiply(float firstNumber, float secondNumber) 
        { 
            return firstNumber * secondNumber;
        }

        /// <summary>
        /// Function to return quotient after division
        /// </summary>
        /// <param name="firstNumber">First number to perform calculation on</param>
        /// <param name="secondNumber">Second number to perform calculation on</param>
        /// <returns>Quotient when divided</returns>
        public static float Divide(float firstNumber, float secondNumber)
        {
            try
            {
                return firstNumber / secondNumber;
            }
            catch(Exception e)
            {
                Console.WriteLine($"Execution interrupted\n{e.Message}");
                throw e;
            }
        }
    }
}
