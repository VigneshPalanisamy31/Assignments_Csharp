using UtilityApp;
using ProjectE;
namespace DisplayApp
{
    public class Displayer
    {
        public IMathHelper mathUtilHelper;
        public Displayer(IMathHelper mathHelper)
        {
            mathUtilHelper = mathHelper;
            ConsoleDisplay();
        }
        /// <summary>
        /// Displays menu to the user and calls the user requested functions
        /// </summary>
        public void ConsoleDisplay()
        {
            bool canExit = false;
            float firstNumber;
            float secondNumber;
            while (!canExit)
            { 
                Console.WriteLine("========Basic ArithMetics========");
                Console.WriteLine("\n\n1.Add\n2.Subtract\n3.Multiply\n4.Divide\n5.Exit\n");
                Console.WriteLine("Enter your choice:");
                int choice = Helper.GetValidChoice(Console.ReadLine());
                if (choice > 0 && choice < 5)
                {
                    Console.WriteLine("\n\nEnter Number 1: ");
                    firstNumber = Helper.GetValidNumber(Console.ReadLine());
                    Console.WriteLine("\nEnter Number 2: ");
                    secondNumber = Helper.GetValidNumber(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine($"The sum of {firstNumber} and {secondNumber} is {mathUtilHelper.CalculateSum(firstNumber, secondNumber)}");
                            break;

                        case 2:
                            Console.WriteLine($"The difference between {firstNumber} and {secondNumber} is {mathUtilHelper.CalculateDifference(firstNumber, secondNumber)}");
                            break;

                        case 3:
                            Console.WriteLine($"The product of {firstNumber} and {secondNumber} is {mathUtilHelper.CalculateProduct(firstNumber, secondNumber)}");
                            break;

                        case 4:
                            if (mathUtilHelper.CalculateQuotient(firstNumber, secondNumber) != 0)
                                Console.WriteLine($"The quotient of {firstNumber} and {secondNumber} is {mathUtilHelper.CalculateQuotient(firstNumber, secondNumber)}");
                            break;
                    }
                }
                else if(choice==5)
                   canExit = true;
                else
                   Console.WriteLine("Please enter a valid choice\n");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
