using System;
using System.Collections.Generic;

namespace AdiPlus.Models
{
    public class Client
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public DateTime DateBirth { get; set; }
    }
}