

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
            DateTime date = Validation.GetValidDate();
            string category = Validation.GetValidString(sourceOrCategory);
            double amount = Validation.GetValidAmount();

            return new Transaction(date, name, category, amount);
        }

    }
}
