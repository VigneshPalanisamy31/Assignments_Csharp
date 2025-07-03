using ProjectE;
using DisplayApp;
namespace MathApp
{
    public class MathUtils : IMathHelper
    {
        public MathUtils()
        {
            Displayer displayer = new Displayer(this);
        }

        /// <summary>
        /// Calculates sum of two numbers
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number</param>
        /// <returns>Sum of given two numbers</returns>
        public float CalculateSum(float firstNumber, float secondNumber)
        {
            return firstNumber + secondNumber;
        }

        /// <summary>
        /// Calculates difference of two numbers
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number</param>
        /// <returns>Difference of given two numbers</returns>
        public float CalculateDifference(float firstNumber, float secondNumber)
        {
            return firstNumber - secondNumber;
        }

        /// <summary>
        /// Calculates product of two numbers
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number</param>
        /// <returns>product of given two numbers</returns>
        public float CalculateProduct(float firstNumber, float secondNumber)
        {
            return firstNumber * secondNumber;
        }

        /// <summary>
        /// Divides given two numbers
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number</param>
        /// <returns> Quotient after division</returns>
        public float? CalculateQuotient(float firstNumber, float secondNumber)
        {
            try
            {
                return firstNumber / secondNumber;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Execution interrupted !+\n{e.Message}");
                return null;
            }
        }
    }
}
