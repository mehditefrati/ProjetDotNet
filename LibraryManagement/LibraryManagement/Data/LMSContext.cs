using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    internal class LMSContext : DbContext
    {
        public DbSet<Admin>? Admins { get; set; }
        public DbSet<Book>? Books { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Adherent>? Adherents { get; set; }
        public DbSet<Reservation>? Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-AG3JV86P; Database=LibraryManagement; Integrated Security=true");
        }
    }
}
