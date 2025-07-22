namespace EventsAndDelegates
{
    public delegate void Notify(string message);
    internal class Notifier
    {
        public event Notify OnAction;
        public void PerformAction(string actionMessage)
        {
            OnAction?.Invoke(actionMessage);
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Notifier notifier = new Notifier();
                notifier.OnAction += DisplayMessage;
                notifier.PerformAction("Action performed! You have been notified.");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
        /// <summary>
        /// Displays notification messages
        /// </summary>
        /// <param name="message">Display message</param>
        private static void DisplayMessage(string message)
        {
            Console.WriteLine($"Notification: {message}");
        }
    }
}
