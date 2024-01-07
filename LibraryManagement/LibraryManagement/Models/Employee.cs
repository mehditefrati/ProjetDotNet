using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Employee
    {
        public Employee()
        {
        }

        public Employee(string? firstName, string? lastName, string? email, string? telephone)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Telephone = telephone;
        }

        public Employee(int? employeeID, string? firstName, string? lastName, string? email, string? telephone)
        {
            EmployeeID = employeeID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Telephone = telephone;
        }

        public int? EmployeeID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
    }
}
