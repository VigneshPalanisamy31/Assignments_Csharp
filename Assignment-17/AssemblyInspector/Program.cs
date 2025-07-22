using System.Reflection;
namespace AssemblyInspector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Helper.WriteInYellow("=== Assembly Explorer ===\n");
            Console.Write("Enter the full path of the assembly (.dll or .exe): ");
            string? assemblyPath = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(assemblyPath) || !File.Exists(assemblyPath))
            {
                Helper.WriteInRed("\nInvalid path or file not found.");
                Console.ReadKey();
                return;
            }
            try
            {
                Assembly assembly = Assembly.LoadFile(Path.GetFullPath(assemblyPath));
                Helper.WriteInGreen($"\nAssembly Loaded: {assembly.FullName}");
                Console.WriteLine("\nInspecting types...\n");
                foreach (Type type in assembly.GetTypes())
                {
                    Helper.WriteInYellow($"Type: {type.FullName}");
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
                Helper.WriteInRed($"\nError: {ex.Message}");
                Console.ReadKey();
            }
            Helper.WriteInYellow("\n=== End of Assembly Inspection ===");
            Console.ReadKey();
        }
        /// <summary>
        /// Prints all members of a type along with their names.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="members"></param>
        static void PrintMembers(string label, MemberInfo[] members)
        {
            Helper.WriteInYellow($"  {label}:");
            if (members.Length == 0)
            {
                Console.WriteLine($"    - (none)");
                return;
            }
            foreach (MemberInfo member in members)
            {
                Console.WriteLine($"    - {member.Name}");
            }
        }
    }
}
