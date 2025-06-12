using System.Reflection;
namespace DynamicMethodInvoker
{
    internal class MethodInvoker
    {
        public static void InvokeMethod(object obj, string methodName, params object[] parameters)
        {
            Type type = obj.GetType();
            MethodInfo? method = type.GetMethod(methodName);
            if (method == null)
            {
                Console.WriteLine($"Method '{methodName}' not found.");
                return;
            }
            try
            {
                object? result = method.Invoke(obj, parameters);
                if (method.ReturnType != typeof(void))
                {
                    Console.WriteLine($"Result: {result}");
                }
            }
            catch (TargetParameterCountException)
            {
                Console.WriteLine("Incorrect number of parameters.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error invoking method: {ex.Message}");
            }
        }
    }
}
