using FinanceTracker.Utilities;
namespace FinanceTracker.View
{
    class TrackerUI
    {
        static void Main(string[] args)
        {
            Validator.CreateFileIfMissing();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("------------Welcome to Expense Tracker-----------");
                Helper.WriteInYellow("1.Register User\n2.Login\n3.Exit");
                UserMenu user = new UserMenu();
                int _choice = Validator.GetValidInteger("your choice");
                switch (_choice)
                {
                    case 1:
                        string name = Validator.GetValidString("name");
                        user.RegisterNewUser(name);
                        break;

                    case 2:
                        string oldname = Validator.GetValidString("name");
                        user.LoginExistingUser(oldname);
                        break;

                    case 3:
                        Helper.WriteInRed("Exiting...");
                        Thread.Sleep(1000);
                        exit = true;
                        break;

                    default:
                        Helper.WriteInRed("Invalid Choice");
                        Helper.WriteInYellow("Please enter a valid choice");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }
        }
    }
}