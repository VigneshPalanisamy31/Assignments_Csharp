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
                Helper.WriteinYellow("1.List\n2.Stack\n3.Queue\n4.Dictionary\n5.Exit\n");
                int choice = Validator.GetValidInt("choice");
                switch (choice)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Adding books to the generic list");
                        for(int i=0;i<3;i++)
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
                        Helper.WriteinYellow("\nDisplaying books:\n");
                        bookList.Display();
                        Thread.Sleep(1000);
                        Helper.WriteinYellow("\nRemoving books:\n");
                        bookList.Remove();
                        break;

                    case 2:
                        Helper.WriteinGreen("Adding characters to the generic stack");
                        for (int i = 0; i < 3; i++)
                        {
                            Thread.Sleep(500);
                            Console.Write(".");
                        }
                        GenericCollection<char> characterStack = new GenericCollection<char>("stack");
                        characterStack.Add('G'); characterStack.Add('e'); characterStack.Add('n'); characterStack.Add('e'); characterStack.Add('r'); characterStack.Add('i'); characterStack.Add('c'); characterStack.Add('s');
                        Thread.Sleep(1000);
                        Helper.WriteinYellow("\nDisplaying characters:\n");
                        characterStack.Display();
                        Thread.Sleep(1000);
                        Helper.WriteinYellow("\nRemoving books:\n");
                        characterStack.Remove();
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Adding people to the generic queue");
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
                        Helper.WriteinYellow("\nDisplaying people in queue:\n");
                        peopleQueue.Display();
                        Thread.Sleep(1000);
                        Helper.WriteinYellow("\nDequeuing people:\n");
                        peopleQueue.Remove();
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Adding marks to the generic dictionary");
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
                        Helper.WriteinYellow("\nDisplaying marks of students:\n");
                        studentDictionary.Display();
                        Thread.Sleep(1000);
                        studentDictionary.Remove(Validator.GetValidString("student name to be removed.."));
                        studentDictionary.Search(Validator.GetValidString("student name to be searched.."));
                        break;
                    case 5:return;
                    default:
                        Helper.WriteinRed("\nInvalid choice");
                        break;
                }
                Console.WriteLine("\n\nPress any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
