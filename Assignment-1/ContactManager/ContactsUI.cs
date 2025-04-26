using System;

namespace ContactManager
{
    internal class ContactsUI
    {

        public static void Main(String[] args)
        {
            ContactManager ContactsHandler = new ContactManager();
            Console.WriteLine("------------ContactsManager-----------");
            bool exit = false;
            do
            {
                Console.WriteLine("\n1.Add New Contact");
                Console.WriteLine("2.Edit Contact");
                Console.WriteLine("3.View Contacts");
                Console.WriteLine("4.Search Contact");
                Console.WriteLine("5.Delete Contact");
                Console.WriteLine("6.Exit");

                bool isValidChoice = int.TryParse(Console.ReadLine(), out int _choice);
                if (isValidChoice)
                {
                    switch (_choice)
                    {
                        case 1:
                            ContactsHandler.AddNewContact();
                            break;
                        case 2:
                            ContactsHandler.EditContact();
                            break;
                        case 3:
                            ContactsHandler.DisplayContacts();
                            break;
                        case 4:
                            ContactsHandler.SearchSimilarContacts();
                            break;
                        case 5:
                            ContactsHandler.DeleteContact();
                            break;
                        case 6: exit = true; break;
                        default:
                            Console.WriteLine("Please Enter A Valid Choice");
                            break;
                    }
                }
                else
                    Console.WriteLine("Please Enter A Valid Choice");


            } while (!exit);

            Console.ReadKey();

        }

    }
}
