using biblio.Models;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace biblio.data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book>? Books { get; set; }
        public DbSet<Adherent>? Adherents { get; set; }
        public DbSet<Reservation>? Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-AG3JV86P; Database=LibraryManagement; Integrated Security=true");
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public ApplicationDbContext()
        {
        }

        internal IEnumerable<Books> Categories { get; set; }


        //public DbSet<Books> Categories { get; set; }
        //public DbSet<Users> Categories { get; set; }
    }


}
