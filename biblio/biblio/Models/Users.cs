using System.ComponentModel.DataAnnotations;

namespace biblio.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public int UserAdNo { get; set; }
        public string UserPass { get; set; }
    }
}
