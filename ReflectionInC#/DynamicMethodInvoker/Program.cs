namespace DynamicMethodInvoker
{
    internal class Program
    {
       static void Main(string[] args)
       {
                InvokableMethods methodToInvoke = new();
                MethodInvoker.InvokeMethod(methodToInvoke, "reet");
                MethodInvoker.InvokeMethod(methodToInvoke, "Add", 10, 20);

                Console.ReadKey();
       }
    }
}
