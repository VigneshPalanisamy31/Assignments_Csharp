

namespace FinanceTracker
{
    internal class UserInteract
    {
        /// <summary>
        /// Function to get required details from the user .
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sourceOrCategory"></param>
        /// <returns>A transaction object with user details</returns>
        public static Transaction GetUserInput(string name, string sourceOrCategory)
        {
            Console.WriteLine("Enter the date (dd-MM-yyyy):\n(press -1 to exit)");
            string userInput = Console.ReadLine();
            if (userInput.Equals("-1"))
                return null;
            DateTime date = Validation.GetValidDate(userInput);
            string category = Validation.GetValidString(sourceOrCategory);
            double amount = Validation.GetValidAmount();

            return new Transaction(date, name, category, amount);
        }

    }
}
