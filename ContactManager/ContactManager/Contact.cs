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
        {
            get { return _name; }
            set { _name = value; }
        }
        string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        string _notes;
        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        public Contact(string name, string phoneNumber, string email, string notes)
        {
            _name = name;
            _phoneNumber = phoneNumber;
            _email = email;
            _notes = notes;
        }
      
    }
}
