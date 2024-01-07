using System.ComponentModel.DataAnnotations;
using biblio;
using biblio.Models;
namespace biblio.Models
{
    public class Books
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public string ISBN { get; set; }
        public int Copies { get; set; }
    }
}

namespace biblio
{
    class Books
    {
    }
}