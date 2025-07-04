namespace BasicArithmetic
{
    public class Program
    {
        /// <summary>
        ///  Gets a valid integer from the user.
        /// </summary>
        /// <returns>valid integer</returns>
        public static float GetValidNumber()
        {
            string input= Console.ReadLine();
            float validNumber;
            while (!float.TryParse(input, out validNumber))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid Number ");
                Console.ResetColor();
                Console.WriteLine("Enter a number :");
                input = Console.ReadLine();
            }
            return validNumber;

        }

        /// <summary>
        /// Gets the valid choice from user
        /// </summary>
        /// <returns>Valid choice</returns>
        public static int GetValidChoice()
        {
            string input=Console.ReadLine();
            int validNumber;
            while (!int.TryParse(input, out validNumber))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid integer ");
                Console.ResetColor();
                Console.WriteLine("Enter a number :");
                input = Console.ReadLine();
            }
            return validNumber;
        }

        public static void Main(string[] args)
        {
            try
            {
                bool canExit = false;
                float firstNumber;
                float secondNumber;
                while (!canExit)
                {
                    Console.WriteLine("========Basic ArithMetics========");
                    Console.WriteLine("\n\n1.Add\n2.Subtract\n3.Multiply\n4.Divide\n5.Exit\n");
                    Console.WriteLine("Enter your choice:");
                    int choice = GetValidChoice();
                    if (choice > 0 && choice < 5)
                    {
                        Console.WriteLine("\n\nEnter Number 1: ");
                        firstNumber = GetValidNumber();
                        Console.WriteLine("\nEnter Number 2: ");
                        secondNumber = GetValidNumber();
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
                                Console.WriteLine($"The quotient of {firstNumber} and {secondNumber} is {MathUtils.Divide(firstNumber, secondNumber)}");
                                break;
                        }
                    }
                    else if(choice==5)
                    {
                        canExit = true;
                        Console.WriteLine("Exiting ....");
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid choice\n");
                    }
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
        }
    }
}
