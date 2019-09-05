using System;
using System.Collections.Generic;
using System.Text;

namespace practice_3.Models
{
    class Contact
    {
        public string Name { get; set; }
        public string Number { get; set; }

        public Contact() { }
        public Contact(string name, string number)
        {
            this.Name = name;
            this.Number = number;
        }
    }
}
