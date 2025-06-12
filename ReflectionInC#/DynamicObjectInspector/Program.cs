namespace DynamicObjectInspector
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person
            {
                Name = "Alice",
                Age = 30,
                Email = "alice@example.com"
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
            Console.ReadKey();
        }
    }
    }
