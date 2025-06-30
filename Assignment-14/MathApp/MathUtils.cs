using ProjectE;
using DisplayApp;
namespace MathApp
{
    public class MathUtils:IMathHelper
    {
        public MathUtils()
        {
            Displayer displayer = new Displayer(this);
        }

        /// <summary>
        /// Function to calculate sum of two numbers
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number</param>
        /// <returns>Sum of given two numbers</returns>
        public float CalculateSum(float firstNumber, float secondNumber)
        {
            return firstNumber + secondNumber;
        }

        /// <summary>
        /// Function to calculate difference of two numbers
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number</param>
        /// <returns>Difference of given two numbers</returns>
        public float CalculateDifference(float firstNumber, float secondNumber)
        {
            return firstNumber - secondNumber;
        }

        /// <summary>
        /// Function to calculate product of two numbers
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number</param>
        /// <returns>product of given two numbers</returns>
        public float CalculateProduct(float firstNumber, float secondNumber)
        {
            return firstNumber * secondNumber;
        }

        /// <summary>
        /// Function to divide given two numbers
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number</param>
        /// <returns> Quotient after division</returns>
        public float CalculateQuotient(float firstNumber, float secondNumber)
        {
            try
            {
                return firstNumber / secondNumber;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Execution interrupted !+\n{e.Message}");
                return 0;
            }
        }
    }
}
