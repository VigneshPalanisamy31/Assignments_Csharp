using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker
{
    internal class UserInteract
    {
        public static Transaction GetUserInput(string name, string sourceOrCategory)
        {
            DateTime date = Validation.GetValidDate();
            string category = Validation.GetValidString(sourceOrCategory);
            double amount = Validation.GetValidAmount();

            return new Transaction(date, name, category, amount);
        }

    }
}
