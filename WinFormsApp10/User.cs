using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp10
{
    public class User
    {
        public User()
        {

        }

       
        public string? Name { get; set; }
        public string? Surname { get; set; }
      
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public User(string? name, string? surname, string? email, string? phoneNumber, DateTime birthdate)
        {
            Name = name;
            Surname = surname;
            Email = email;
            PhoneNumber = phoneNumber;
            Birthdate = birthdate;
        }
        public override string ToString()
        => $"{Name} - {Surname}-{Email}";
    }
}
