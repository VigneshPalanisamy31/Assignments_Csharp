using Plugin;
namespace SendOffPlugin
{
    public class SendoffPlugin:IPlugin
    {
        public string Name => "SendoffPlugin";
        /// <summary>
        /// Prints send-off message (implementation of IPlugin interface)
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("Thank You.. from  Send-off plugin!");
        }
    }
}
