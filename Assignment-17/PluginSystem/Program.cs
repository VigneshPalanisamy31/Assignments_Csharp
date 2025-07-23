using Plugin;
using System.Reflection;
namespace PluginSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            string pluginFolder = Path.Combine(Directory.GetCurrentDirectory(), "Plugins");
            foreach (string dll in Directory.GetFiles(pluginFolder, "*.dll"))
            {
                try
                {
                    Assembly pluginAssembly = Assembly.LoadFrom(dll);
                    foreach (Type type in pluginAssembly.GetTypes())
                    {
                        if (typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                        {
                            IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                            Console.WriteLine($"\nPlugin: {plugin.Name}");
                            plugin.Execute();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to load {dll}: {ex.Message}");
                }
            }
            Console.ReadKey();
        }
    }
}
