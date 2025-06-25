namespace BasicArithmetic
{
    internal class Program
    {
        /// <summary>
        /// Function to return a valid integer from the user-end.
        /// </summary>
        /// <param name="displayMessage">Message to be displayed in the console</param>
        /// <returns>validated integer</returns>
        public static float GetValidatedNumber(string? displayMessage) 
        {
            float validNumber;
            while(!float.TryParse(displayMessage, out validNumber))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid Number ");
                Console.ResetColor();
                Console.WriteLine("Enter a number :");
                displayMessage= Console.ReadLine();
            }
            return validNumber; 
        
        }
        /// <summary>
        /// Gets the valid choice from user
        /// </summary>
        /// <param name="displayMessage">Message to be displayed in the console</param>
        /// <returns>Valid choice from user</returns>
        public static int GetValidChoice(string? displayMessage)
        {
            int validNumber;
            while (!int.TryParse(displayMessage, out validNumber))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid integer ");
                Console.ResetColor();
                Console.WriteLine("Enter a number :");
                displayMessage = Console.ReadLine();
            }
            return validNumber;
        }
        public static void Main(string[] args)
        {
            try {
                bool isExit = false;
                while (!isExit)
                {
                    Console.WriteLine("========Basic ArithMetics========");
                    Console.WriteLine("\n\nEnter Number 1: ");
                    float firstNumber = GetValidatedNumber(Console.ReadLine());
                    Console.WriteLine("\nEnter Number 2: ");
                    float secondNumber = GetValidatedNumber(Console.ReadLine());
                    Console.WriteLine("\n\n1.Add\n2.Subtract\n3.Multiply\n4.Divide\n5.Exit\n");
                    Console.WriteLine("Enter your choice:");
                    int choice = GetValidChoice(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine($"The sum of {firstNumber} and {secondNumber} is {MathUtils.Add(firstNumber, secondNumber)}");
                            break;

                        case 2:
                            Console.WriteLine($"The difference between {firstNumber} and {secondNumber} is {MathUtils.Subtract(firstNumber, secondNumber)}");
                            break;

                        case 3:
                            Console.WriteLine($"The product of {firstNumber} and {secondNumber} is {MathUtils.Multiply(firstNumber, secondNumber)}");
                            break;

                        case 4:
                            if (MathUtils.Divide(firstNumber, secondNumber) != 0)
                                Console.WriteLine($"The quotient of {firstNumber} and {secondNumber} is {MathUtils.Divide(firstNumber, secondNumber)}");
                            break;

                        case 5:
                            isExit = true;
                            Console.WriteLine("Exiting ....");
                            break;
                        default:
                            Console.WriteLine("Please enter a valid choice\n");
                            break;
                    }
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }catch(Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
        }
    }
}
