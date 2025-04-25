using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using ContactsManager;

namespace ContactManager
{
    internal class Validator
    {
        /// <summary>
        /// Function to check if the name already exists in the contacts
        /// </summary>
        /// <param name="Contacts"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static string ValidateName(List<Contact> Contacts, string Name)
        {
            bool NameAvaialable = false;
           
            while (!NameAvaialable)
            {
                while (string.IsNullOrWhiteSpace(Name)|| !Regex.IsMatch(Name, @"^\D+$"))
                {
                    Console.WriteLine("Invalid name...\nPlease enter a valid name: ");
                    Name = Console.ReadLine();

                }
            
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
        public static string ValidatePhoneNumber(string phoneNumber,List<Contact> Contacts)
        {
            string pattern = @"^[1-9]\d{9}$";
          
            while (!Regex.IsMatch(phoneNumber, pattern))
            {
                Console.WriteLine("Please Enter A Valid Mobile Number");
                phoneNumber = Console.ReadLine();
              
            }
            foreach (Contact contact in Contacts)
            {

                if (contact.PhoneNumber == phoneNumber)
                {
                    Console.WriteLine($"\nContact With Same Number Already Exists \nPlease Enter a different number :");
                    return ValidatePhoneNumber(Console.ReadLine(), Contacts);
                    break;

                }
            }
            return phoneNumber;

        }

        /// <summary>
        /// Function to validate user-entered mail ID
        /// </summary>
        /// <param name="email">Mail ID of the contact</param>
        /// <returns>Validated mailID</returns>
        public static string ValidateEmail(string email)
        {
            string pattern = "[^@]+@[^@.]+.[^@.]+";
            while (!Regex.IsMatch(email, pattern))
            {
                Console.WriteLine("Please Enter A Valid Email Id");
                email = Console.ReadLine();
            }
            return email;

        }

    }
}