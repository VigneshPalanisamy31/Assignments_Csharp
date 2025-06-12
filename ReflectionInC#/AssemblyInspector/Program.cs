using System.Reflection;
namespace AssemblyInspector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Assembly Explorer ===\n");
            Console.ResetColor();
            Console.Write("Enter the full path of the assembly (.dll or .exe): ");
            string? assemblyPath = Console.ReadLine();
            //Assembly assembly = Assembly.LoadFile(Path.GetFullPath(assemblyPath));
            if (string.IsNullOrWhiteSpace(assemblyPath) || !File.Exists(assemblyPath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid path or file not found.");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }
            try
            {
                Assembly assembly = Assembly.LoadFile(Path.GetFullPath(assemblyPath));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nAssembly Loaded: {assembly.FullName}");
                Console.ResetColor();
                Console.WriteLine("\nInspecting types...\n");
                foreach (Type type in assembly.GetTypes())
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Type: {type.FullName}");
                    Console.ResetColor();
                    PrintMembers("Methods", type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly));
                    PrintMembers("Properties", type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly));
                    PrintMembers("Fields", type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly));
                    PrintMembers("Events", type.GetEvents(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly));
                    Console.WriteLine();
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError: {ex.Message}");
                Console.ResetColor();
                Console.ReadKey();
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== End of Assembly Inspection ===");
            Console.ResetColor();
            Console.ReadKey();
        }
        /// <summary>
        /// Function to print all members of a type along with their names.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="members"></param>
        static void PrintMembers(string label, MemberInfo[] members)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  {label}:");
            Console.ResetColor();
            if (members.Length == 0)
            {
                Console.WriteLine($"    - (none)");
                return;
            }

            foreach (var member in members)
            {
                Console.WriteLine($"    - {member.Name}");
            }
        }
    }
}
