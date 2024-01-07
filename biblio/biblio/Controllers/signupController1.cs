using biblio.data;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace biblio.Controllers
{
    public class signupController1 : Controller
    {
        private readonly ApplicationDbContext _db;
        public signupController1(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Book> books = new List<Book>();



            ViewBag.books = _db.Books.ToList();

            return View();
        }
    }
}
