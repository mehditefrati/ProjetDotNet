using library.Models;
using library.Models;
using Microsoft.EntityFrameworkCore;

namespace library.Data;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("your_connection_string", builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });
            base.OnConfiguring(optionsBuilder);
        }*/
        public DbSet<Book> Books { get; set; }
        public DbSet<Adherent> Adherents { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Reservation> Reservations  { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
}

//add-migration AddUserToDatabase
//update-database

