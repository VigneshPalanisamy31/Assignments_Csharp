namespace DynamicMethodInvoker
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                InvokableMethods methodToInvoke = new();
                MethodInvoker.InvokeMethod(methodToInvoke, "reet");
                MethodInvoker.InvokeMethod(methodToInvoke, "Greet");
                MethodInvoker.InvokeMethod(methodToInvoke, "Add", 10, 20);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
