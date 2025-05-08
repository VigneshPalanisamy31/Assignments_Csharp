
using FinanceTracker;
class TrackerUI
{

    static void Main(string[] args)
    {
        string filepath = Path.Combine(Environment.CurrentDirectory, "FinanceTracker.xlsx");
        Validation.FileIntegrity(filepath);
        FinanceTransactions financer = new FinanceTransactions();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("------------Welcome to Expense Tracker-----------");
            Console.WriteLine("1.New User\n2.Existing User\n3.Exit");
            int _choice = Validation.GetValidInteger("your choice");
            switch (_choice)
            {
                case 1:
                    string name = Validation.GetValidString("name");
                    NewUser newuser = new NewUser(filepath);
                    newuser.NewUserFunctions(name, financer);
                    break;

                case 2:
                    string oldname = Validation.GetValidString("name");
                    ExistingUser user = new ExistingUser(filepath);
                    user.UserFunctions(oldname, financer);
                    break;

                case 3:
                    Console.WriteLine("Exiting...");
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Please enter a valid choice");
                    break;


            }
        }

        Console.ReadKey();

    }

}