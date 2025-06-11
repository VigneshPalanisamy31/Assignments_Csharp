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
        class Program
        {
            static void Main(string[] args)
            {
                Notifier notifier = new Notifier();
                notifier.OnAction += DisplayMessage;
                notifier.PerformAction("Action performed! You have been notified.");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        /// <summary>
        /// Function to display notification messages
        /// </summary>
        /// <param name="message"></param>
            static void DisplayMessage(string message)
            {
                Console.WriteLine($"Notification: {message}");
            }
        }
}
