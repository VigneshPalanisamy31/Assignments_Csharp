namespace MathApp
{
    public class MathUtils
    {
        /// <summary>
        /// Function to calculate sum of two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Sum of given two numbers</returns>
        public static float CalculateSum(float a, float b)
        {
            return a + b;
        }
        /// <summary>
        /// Function to calculate difference of two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Difference of given two numbers</returns>
        public static float CalculateDifference(float a, float b)
        {
            return a - b;
        }
        /// <summary>
        /// Function to calculate product of two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>product of given two numbers</returns>
        public static float CalculateProduct(float a, float b)
        {
            return a * b;
        }
        /// <summary>
        /// Function to divide given two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns> Quotient after division</returns>
        public static float CalculateQuotient(float a, float b)
        {
            try
            {
                return a / b;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Execution interrupted due to an attempt to divide by 0 +\n{e.Message}");
                return 0;
            }
        }
    }
}
