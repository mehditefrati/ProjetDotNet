using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Adherent
    {
        public Adherent()
        {
        }
        public Adherent(string firstName, string lastName, string email, string phoneNumber, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Telephone = phoneNumber;
            Password = password;
        }
        public Adherent(int adherentID, string firstName, string lastName, string email, string phoneNumber, string password)
        {
            AdherentID = adherentID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Telephone = phoneNumber;
            Password = password;
        }
        public int? AdherentID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
        public string? Password { get; set; }
    }
}
