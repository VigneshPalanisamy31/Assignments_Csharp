using Plugin;
namespace GreetingsPlugin
{
    public class GreetPlugin:IPlugin
    {
        public string Name => "GreetingsPlugin";
        /// <summary>
        /// Prints greeting message (Implementation of interface Iplugin
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("Welcome...\nHello from Greeting plugin!");
        }
    }
}
