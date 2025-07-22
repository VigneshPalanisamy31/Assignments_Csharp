namespace DebuggingDeadlock
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            try
            {
                MethodHandler handler= new MethodHandler();
                handler.DeadlockMethod();
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }
    }
}
