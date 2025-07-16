namespace Collections
{
    internal class BookManagerMenu
    {
        /// <summary>
        /// Displays menu to work with lists
        /// </summary>
        public void ManageBooks()
        {
            BooksManager booksManager = new BooksManager();
            bool canExit = false;
            while (!canExit)
            {
                Console.Clear();
                Helper.WriteInColor("============List of Books============", ConsoleColor.Yellow);
                Helper.WriteInColor("\n1.Add\n2.Remove\n3.Search\n4.Display\n5.Exit", ConsoleColor.Yellow);
                int choice = Validator.GetValidInt("Enter the choice :");
                switch (choice)
                {
                    case 1:
                        booksManager.AddBooks();
                        break;

                    case 2:
                       booksManager.RemoveBook();
                        break;

                    case 3:
                        booksManager.SearchBook();
                        break;

                    case 4:
                        booksManager.DisplayBooks();
                        break;

                    case 5:
                        canExit = true;
                        Console.WriteLine("Exiting");
                        break;

                    default:
                        Helper.WriteInColor("\nInvalid choice", ConsoleColor.Red);
                        break;
                }
                Console.WriteLine("\nPress any key to continue..");
                Console.ReadKey();
            }
        }
    }
}
