namespace DynamicObjectInspector
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Person person = new Person
                {
                    Name = "Vicky",
                    Age = 22,
                    Email = "Vicky@Solin.com"
                };
                Console.WriteLine("Original object:");
                ObjectInspector.Inspect(person);
                Console.WriteLine("\nEnter property to update:");
                string propName = Console.ReadLine()!;
                Console.WriteLine("Enter new value:");
                string newVal = Console.ReadLine()!;
                ObjectInspector.SetProperty(person, propName, newVal);
                Console.WriteLine("\nUpdated object:");
                ObjectInspector.Inspect(person);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
