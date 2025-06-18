using Plugin;
namespace GreetingsPlugin
{
    public class GreetPlugin:IPlugin
    {
        public string Name => "GreetingsPlugin";
        /// <summary>
        /// Function that prints greeting message (Implementation of interface Iplugin
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("Welcome...\nHello from Greeting plugin!");
        }
    }
}
