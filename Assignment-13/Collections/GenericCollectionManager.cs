namespace Collections
{
    internal class GenericCollectionManager
    {
        /// <summary>
        /// Displays menu to choose the generic collection to work with
        /// </summary>
        public void GenericCollectionOperations()
        {
            while (true)
            {
                Console.WriteLine("Choose the generic collection :\n");
                Helper.WriteInColor("1.List\n2.Stack\n3.Queue\n4.Dictionary\n5.Exit\n", ConsoleColor.Yellow);
                int choice = Validator.GetValidInt("Enter the choice :");
                switch (choice)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Adding books to the list");
                        for (int i = 0; i < 3; i++)
                        {
                            Thread.Sleep(500);
                            Console.Write(".");
                        }
                        Console.ResetColor();
                        Console.WriteLine("\n");
                        GenericCollection<string> bookList = new GenericCollection<string>("list");
                        bookList.Add("Book_1");
                        bookList.Add("Book_2");
                        bookList.Add("Book_3");
                        bookList.Add("Book_4");
                        bookList.Add("Book_5");
                        Thread.Sleep(1000);
                        Helper.WriteInColor("\nDisplaying books:\n", ConsoleColor.Yellow);
                        bookList.Display();
                        Thread.Sleep(1000);
                        Helper.WriteInColor("\nRemoving books:\n", ConsoleColor.Yellow);
                        bookList.Remove();
                        break;

                    case 2:
                        Helper.WriteInColor("Adding characters to the stack", ConsoleColor.Green);
                        for (int i = 0; i < 3; i++)
                        {
                            Thread.Sleep(500);
                            Console.Write(".");
                        }
                        GenericCollection<char> characterStack = new GenericCollection<char>("stack");

                        characterStack.Add('G');
                        characterStack.Add('e');
                        characterStack.Add('n');
                        characterStack.Add('e');
                        characterStack.Add('r');
                        characterStack.Add('i');
                        characterStack.Add('c');
                        characterStack.Add('s');

                        Thread.Sleep(1000);
                        Helper.WriteInColor("\nDisplaying characters:\n", ConsoleColor.Yellow);
                        characterStack.Display();
                        Thread.Sleep(1000);
                        Helper.WriteInColor("\nRemoving books:\n", ConsoleColor.Yellow);
                        characterStack.Remove();
                        break;

                    case 3:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Adding people to the queue");
                        for (int i = 0; i < 3; i++)
                        {
                            Thread.Sleep(500);
                            Console.Write(".");
                        }
                        Console.ResetColor();
                        GenericCollection<string> peopleQueue = new GenericCollection<string>("queue");
                        peopleQueue.Add("Person_1");
                        peopleQueue.Add("Person_2");
                        peopleQueue.Add("Person_3");
                        peopleQueue.Add("Person_4");
                        peopleQueue.Add("Person_5");
                        Thread.Sleep(1000);
                        Helper.WriteInColor("\nDisplaying people in queue:\n", ConsoleColor.Yellow);
                        peopleQueue.Display();
                        Thread.Sleep(1000);
                        Helper.WriteInColor("\nDequeuing people:\n", ConsoleColor.Yellow);
                        peopleQueue.Remove();
                        break;

                    case 4:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Adding marks to the dictionary");
                        for (int i = 0; i < 3; i++)
                        {
                            Thread.Sleep(500);
                            Console.Write(".");
                        }
                        Console.ResetColor();
                        GenericDictionary<string, int> studentDictionary = new GenericDictionary<string, int>();
                        studentDictionary.Add("Student_1", 100);
                        studentDictionary.Add("Student_2", 99);
                        studentDictionary.Add("Student_3", 98);
                        studentDictionary.Add("Student_4", 97);
                        studentDictionary.Add("Student_5", 96);
                        Thread.Sleep(1000);
                        Helper.WriteInColor("\nDisplaying marks of students:\n", ConsoleColor.Yellow);
                        studentDictionary.Display();
                        Thread.Sleep(1000);
                        studentDictionary.Remove(Validator.GetValidString("Enter the student name to be removed :"));
                        studentDictionary.Search(Validator.GetValidString("Enter the student name to be searched :"));
                        break;

                    case 5: return;

                    default:
                        Helper.WriteInColor("\nInvalid choice", ConsoleColor.Red);
                        break;
                }
                Console.WriteLine("\n\nPress any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
