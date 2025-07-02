namespace Collections
{
    internal class Program
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
                            BookListManager bookManager = new BookListManager();
                            bookManager.WorkingWithLists();
                            break;

                        case 2:
                            CharacterStackManager characterManager = new CharacterStackManager();
                            characterManager.UsingStacks();
                            break;

                        case 3:
                            PeopleQueueManager peopleManager = new PeopleQueueManager();
                            peopleManager.WorkingWithQueues();
                            break;

                        case 4:
                            MarksDictionaryManager marksManager = new MarksDictionaryManager();
                            marksManager.UnderstandingDictionaries();
                            break;

                        case 5:
                            GenericCollectionManager genericsManager = new GenericCollectionManager();
                            genericsManager.GenericCollectionOperations();
                            break;

                        case 6:
                            Helper.WriteInColor("Testing sum of elements...\n", ConsoleColor.Yellow);
                            ReadOnlyDictionaryViewer.TestSumOfElements();
                            Thread.Sleep(2000);
                            Helper.WriteInColor("Generate Dictionary...\n", ConsoleColor.Yellow);
                            IReadOnlyDictionary<string, int> dict = ReadOnlyDictionaryViewer.GenerateDictionary();
                            Thread.Sleep(2000);
                            Helper.WriteInColor("Print Dictionary...\n", ConsoleColor.Yellow);
                            ReadOnlyDictionaryViewer.PrintDictionary(dict);
                            Thread.Sleep(2000);
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
