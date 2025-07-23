using System.Reflection;
namespace AssemblyInspector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Helper.WriteInColor("=== Assembly Explorer ===\n",ConsoleColor.Yellow);
            Console.Write("Enter the full path of the assembly (.dll or .exe): ");
            string? assemblyPath = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(assemblyPath) || !File.Exists(assemblyPath))
            {
                Helper.WriteInColor("\nInvalid path or file not found.",ConsoleColor.Red);
                Console.ReadKey();
                return;
            }
            try
            {
                Assembly assembly = Assembly.LoadFile(Path.GetFullPath(assemblyPath));
                Helper.WriteInColor($"\nAssembly Loaded: {assembly.FullName}",ConsoleColor.Green);
                Console.WriteLine("\nInspecting types...\n");
                foreach (Type type in assembly.GetTypes())
                {
                    Helper.WriteInColor($"Type: {type.FullName}", ConsoleColor.Yellow);
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
                Helper.WriteInColor($"\nError: {ex.Message}", ConsoleColor.Red);
                Console.ReadKey();
            }
            Helper.WriteInColor("\n=== End of Assembly Inspection ===", ConsoleColor.Yellow);
            Console.ReadKey();
        }
        /// <summary>
        /// Prints all members of a type along with their names.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="members"></param>
        static void PrintMembers(string label, MemberInfo[] members)
        {
            Helper.WriteInColor($"  {label}:", ConsoleColor.Yellow);
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
