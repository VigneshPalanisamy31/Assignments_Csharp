using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ContactsManager;

namespace ContactManager
{
    internal class Validator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Contacts"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public string ValidateName(List<Contact> Contacts, string Name)
        {
            bool NameAvaialable = false;
            while (!NameAvaialable)
            {
                int Count = 0;
                foreach (Contact contact in Contacts)
                {
                    Count++;
                    if (contact.Name == Name)
                    {
                        Console.WriteLine($"\nContact With Same Name Already Exists \nPlease Enter a different name :");
                        Name = Console.ReadLine();
                        Count = 0;
                        break;

                    }
                }
                if (Count == Contacts.Count)
                    NameAvaialable = true;
            }
            return Name;

        }

        /// <summary>
        /// Function to validate user-entered phone number.
        /// </summary>
        /// <param name="phoneNumber">Contact  number.</param>
        /// <returns>Validated phone number .</returns>
        public string ValidatePhoneNumber(string phoneNumber)
        {
            string pattern = @"^\+*\d{0,3}[1-9]\d{9}";
            while (!Regex.IsMatch(phoneNumber, pattern))
            {
                Console.WriteLine("Please Enter A Valid Mobile Number");
                phoneNumber = Console.ReadLine();
            }
            return phoneNumber;

        }

    }
}
