using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace practice_3.Models
{
    class Person
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [Unique]
        public string Username { get; set; }
        
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
