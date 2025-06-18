using Plugin;
namespace SendOffPlugin
{
    public class SenodoffPlugin:IPlugin
    {
        public string Name => "SendoffPlugin";
        /// <summary>
        /// Function that prints sendoff message (implementation of IPlugin interface
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("Thank You.. from  Sendoff plugin!");
        }
    }
}
