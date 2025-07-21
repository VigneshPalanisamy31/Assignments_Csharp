namespace Collections
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("1.Working with Lists\n2.Using Stacks\n3.Working with Queues\n4.Understanding Dictionaries" +
                                      "\n5.Generics \n6.IEnumerable & IReadOnlyDictionary\n7.Exit\n");
                    int choice = Validator.GetValidInteger("Enter the choice :");
                    switch (choice)
                    {
                        case 1:
                            BookManagerMenu bookManagerMenu = new BookManagerMenu(); 
                            bookManagerMenu.ManageBooks();
                            break;

                        case 2:
                            CharactersManager characterManager = new CharactersManager();
                            characterManager.ReverseUsingStacks();
                            break;

                        case 3:
                            PeopleManager peopleManager = new PeopleManager();
                            peopleManager.ManagePeopleQueue();
                            break;

                        case 4:
                            MarksManager marksManager = new MarksManager();
                            marksManager.ManageMarks();
                            break;

                        case 5:
                            GenericCollectionManager genericsManager = new GenericCollectionManager();
                            genericsManager.DisplayGenericCollectionOperations();
                            break;

                        case 6:
                            Helper.WriteInColor("Testing sum of elements...\n", ConsoleColor.Yellow);
                            ReadOnlyDictionaryViewer.TestSumOfElements();
                            Helper.WriteInColor("Generate Dictionary...\n", ConsoleColor.Yellow);
                            IReadOnlyDictionary<string, int> dict = ReadOnlyDictionaryViewer.GenerateDictionary();
                            Helper.WriteInColor("Print Dictionary...\n", ConsoleColor.Yellow);
                            ReadOnlyDictionaryViewer.PrintDictionary(dict);
                            ReadOnlyDictionaryViewer.ModifyDictionary(dict);
                            Console.ReadKey();
                            break;

                        case 7: return;

                        default:
                            Helper.WriteInColor("\nInvalid choice", ConsoleColor.Red);
                            break;
                    }
                    Console.Clear();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
        }
    }
}
