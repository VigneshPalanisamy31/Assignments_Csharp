using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager
{
    internal class Contact
    {
        string _name;
        public string Name
        { get; set; }
        string _phoneNumber;
        public string PhoneNumber
        { get; set; }
        string _email;
        public string Email
        { get; set; }
        string _notes;
        public string Notes
        { get; set; }

        public Contact(string name, string phoneNumber, string email, string notes)
        {
            _name = name;
            _phoneNumber = phoneNumber;
            _email = email;
            _notes = notes;
        }
        /// <summary>
        /// Fucntion to return object in desired format
        /// </summary>
        /// <returns>Contact-details</returns>
        public override string ToString()
        {
            return $"Name : {_name}\nPhone Number : {_phoneNumber}\nEmail : {_email} \nNotes : {_notes}";
        }

    }
}
