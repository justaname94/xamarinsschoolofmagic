using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace practice_3.Models
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Company { get; set; }
        public string Number { get; set; }

        public string Email { get; set; }

        public Contact() { }
        public Contact(string firstName, string number)
        {
            this.FirstName = firstName;
            this.Number = number;
        }
    }
}
