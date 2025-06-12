namespace AssemblyForInspection
{
    public class Program
    {
        public static string UserName { get; set; }
        public static float Age { get; set; }
        public static string Address {  get; set; }
        public static string Email {  get; set; }
        public static void GetUserDetails()
        {
            Console.WriteLine("Enter Your Name:");
            UserName = Console.ReadLine();
            Console.WriteLine("Enter Your Age:");
            Age = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your Address:");
            Address = Console.ReadLine();
            Console.WriteLine("Enter Your Email:");
            Email = Console.ReadLine();

        }
        public static void PrintUserDetails()
        {
            Console.WriteLine($"Name: {UserName}\nAge: {Age}\nAddress: {Address}\nEmail:{Email}");
        }
        public static void Main(string[] args)
        {
            GetUserDetails();
            PrintUserDetails();
            Console.ReadKey();
        }
    }
}
