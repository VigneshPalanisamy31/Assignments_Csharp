using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsManager;

namespace ContactManager
{
    internal class ContactManager
    {
        List<Contact> Contacts = new List<Contact>();

        public bool isEmpty()
        {
            if (Contacts.Count == 0)
            {
                Console.WriteLine("No contacts available...");
                return true;
            }
            return false;
        }

        /// <summary>
        /// Function to add new contacts.
        /// </summary>
        public void AddNewContact()
        {
            Console.WriteLine("Enter the Name :");
            string Name = Validator.ValidateName(Contacts, Console.ReadLine());
            Console.WriteLine("Enter the Phone Number :");
            string PhoneNumber = Validator.ValidatePhoneNumber(Console.ReadLine(),Contacts);
            Console.WriteLine("Enter the Mail id :");
            string Email = Validator.ValidateEmail(Console.ReadLine());
            Console.WriteLine("Add Some Notes :");
            string Notes = Console.ReadLine();
            Contacts.Add(new Contact(Name, PhoneNumber, Email, Notes));
            Contacts = Contacts.OrderBy(c => c.Name).ToList();
            Console.WriteLine("Contact Created Successfully.....");
        }

        /// <summary>
        /// Function to display contacts
        /// </summary>
        public void DisplayContacts()
        {
            if (!isEmpty())
            {
                foreach (Contact contact in Contacts)
                {
                    Console.WriteLine(contact.Name);
                }
            }
        }

        /// <summary>
        /// Function to search contacts
        /// </summary>
        /// <returns>An object of the matched contact</returns>
        public Contact SearchContacts()
        {
            if (!isEmpty())
            {
                Console.WriteLine("Enter the Details for Search :");
                string key = Console.ReadLine();
                foreach (Contact contact in Contacts)
                {
                    if (contact.Name.Equals(key) || contact.Email.Equals(key) || contact.PhoneNumber.Equals(key))
                    {
             
                        Console.WriteLine(contact);
                        return contact;
                    }
                }
            }
            if (Contacts.Count>0)
                Console.WriteLine("No Matching Results....");
            return null;
        }

        /// <summary>
        /// Function to edit contacts
        /// </summary>
        public void EditContact()
        {
            if (!isEmpty())
            {
                Contact toEdit = SearchContacts();
                bool stopEdit = false;
                if (toEdit != null)
                {
                    while (!stopEdit)
                    {
                        Console.WriteLine("Choose The Field To Edit :\n1.Name\n2.Phone Number\n3.Email\n4.Notes\n5.Exit");
                        bool isValidChoice = int.TryParse(Console.ReadLine(), out int _choice);
                        if (isValidChoice)
                        {
                            switch (_choice)
                            {

                                case 1:
                                    Console.WriteLine("Enter the new name :");
                                    string name = Console.ReadLine();
                                    name=toEdit.Name==name?name:Validator.ValidateName(Contacts,name);
                                    toEdit.Name = name;
                                    break;
                                case 2:
                                    Console.WriteLine("Enter the new Phone Number :");
                                    string phoneNumber = Validator.ValidatePhoneNumber(Console.ReadLine(), Contacts);
                                    toEdit.PhoneNumber = phoneNumber;
                                    break;
                                case 3:
                                    Console.WriteLine("Enter the new Mail Id :");
                                    string email = Console.ReadLine();
                                    toEdit.Email = email;
                                    break;
                                case 4:
                                    Console.WriteLine("Enter new notes :");
                                    toEdit.Notes = Console.ReadLine();
                                    break;
                                case 5: stopEdit = true; break;
                                default:
                                    Console.WriteLine("Please Choose A Valid Option");
                                    break;
                            }
                        }
                        else
                            Console.WriteLine("Please Choose A Valid Option");
                    }
                   
                }
            }
        }

        /// <summary>
        /// Function to delete contact
        /// </summary>
        public void DeleteContact()
        {
            if (!isEmpty())
            {
                Contact toDelete = SearchContacts();
                if (toDelete != null)
                {
                    Console.WriteLine("Are you sure you want to delete this contact ? [y/n]");
                    string ConfirmDelete = Console.ReadLine();
                    while (!ConfirmDelete.Equals("y") && !ConfirmDelete.Equals("n"))
                    {
                        Console.WriteLine("Please select from the options y/n");
                        ConfirmDelete = Console.ReadLine();
                    }
                    if (ConfirmDelete.Equals("y"))
                    {
                        Contacts.Remove(toDelete);
                        Console.WriteLine("Contact Deleted SuccessFully");
                    }
                    else
                        Console.WriteLine("Cancelling delete....");

                }
                else
                    Console.WriteLine("Contact not found....");
            }
        }
    }
}