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
        Validator isValid = new Validator();
        /// <summary>
        /// Function to add new contacts.
        /// </summary>
        public void AddNewContact()
        {
            Console.WriteLine("Enter the Name :");
            string Name = isValid.ValidateName(Contacts, Console.ReadLine());
            Console.WriteLine("Enter the Phone Number :");
            string PhoneNumber = isValid.ValidatePhoneNumber(Console.ReadLine());
            Console.WriteLine("Enter the Mail id :");
            string Email = isValid.ValidateEmail(Console.ReadLine());
            Console.WriteLine("Add Some Notes :");
            string Notes = Console.ReadLine();
            Contacts.Add(new Contact(Name, PhoneNumber, Email, Notes));
            Contacts = Contacts.OrderBy(c => c.Name).ToList();
            Console.WriteLine("Contact Created Successfully.....");
        }

    }
}
