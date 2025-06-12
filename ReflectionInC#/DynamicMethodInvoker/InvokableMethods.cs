namespace DynamicMethodInvoker
{
    internal class InvokableMethods
    {
        public void Greet()
        {
            Console.WriteLine("Hello from Class With Methods!");
        }

        public float Add(float number_1, float number_2)
        {
            return number_1 + number_2;
        }
    }
}
