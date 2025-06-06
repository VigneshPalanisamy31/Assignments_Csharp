using FinanceTracker.Utilities;
namespace FinanceTracker.View
{
    class UserInterface
    {
        static void Main(string[] args)
        {
            Validator.CreateFileIfMissing();
            bool isExit = false;
            while (!isExit)
            {
                Console.WriteLine("------------Welcome to Expense Tracker-----------");
                Helper.WriteInYellow("1.Register User\n2.Login\n3.Exit");
                UserService userService = new UserService();
                int choice = Validator.GetValidInteger("your choice");
                switch (choice)
                {
                    case 1:
                        string newUserName = Validator.GetValidString("name");
                        string newPassword = Validator.GetHashPassword(Validator.GetValidPassword());
                        userService.RegisterNewUser(newUserName, newPassword);
                        break;

                    case 2:
                        string userName = Validator.GetValidString("name");
                        string password = Validator.GetHashPassword(Validator.GetValidPassword());
                        userService.LoginExistingUser(userName, password);
                        break;

                    case 3:
                        Helper.WriteInRed("Exiting...");
                        Thread.Sleep(1000);
                        isExit = true;
                        break;

                    default:
                        Helper.WriteInRed("Invalid Choice");
                        Helper.WriteInYellow("Enter a valid choice");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }
        }
    }
}