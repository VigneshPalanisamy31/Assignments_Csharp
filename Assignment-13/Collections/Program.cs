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
                    int choice = Validator.GetValidInt("Enter the choice :");
                    switch (choice)
                    {
                        case 1:
                            BookManagerMenu bookManagerMenu = new BookManagerMenu(); 
                            bookManagerMenu.WorkingWithLists();
                            break;

                        case 2:
                            CharactersManager characterManager = new CharactersManager();
                            characterManager.ReverseUsingStacks();
                            break;

                        case 3:
                            PeopleManager peopleManager = new PeopleManager();
                            peopleManager.WorkingWithQueues();
                            break;

                        case 4:
                            MarksManager marksManager = new MarksManager();
                            marksManager.UnderstandingDictionaries();
                            break;

                        case 5:
                            GenericCollectionManager genericsManager = new GenericCollectionManager();
                            genericsManager.GenericCollectionOperations();
                            break;

                        case 6:
                            Helper.WriteInColor("Testing sum of elements...\n", ConsoleColor.Yellow);
                            ReadOnlyDictionaryViewer.TestSumOfElements();
                            Helper.WriteInColor("Generate Dictionary...\n", ConsoleColor.Yellow);
                            IReadOnlyDictionary<string, int> dict = ReadOnlyDictionaryViewer.GenerateDictionary();
                            Helper.WriteInColor("Print Dictionary...\n", ConsoleColor.Yellow);
                            ReadOnlyDictionaryViewer.PrintDictionary(dict);
                            ReadOnlyDictionaryViewer.AttemptToModifyDictionary(dict);
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
