namespace Collections
{
    internal class CharacterStackManager
    {
        /// <summary>
        /// Reverses a string by using stack
        /// </summary>
        public void UsingStacks()
        {
            Console.WriteLine("Enter the string to be reversed :");
            string? inputString =Console.ReadLine();
            Stack<char> characters = new Stack<char>();
            Console.WriteLine("\nPushing characters onto the stack..");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach(char c in inputString)
            {
                characters.Push(c);
                Console.Write(c + " ");
                Thread.Sleep(200);
            }
            Console.ResetColor();
            Console.WriteLine("\nPopping characters from the stack..(reversing string)");
            Console.ForegroundColor = ConsoleColor.Green;
            while (characters.Count > 0) 
            {
                Console.Write(characters.Pop()+" ");
                Thread.Sleep(200);
            }
            Console.ResetColor();
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
