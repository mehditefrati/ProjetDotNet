using biblio.data;
using biblio;
using biblio.Controllers;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;

namespace biblio.Controllers
{
    public class reserveController1 : Controller
    {

        
        private readonly ApplicationDbContext _db;
        public reserveController1(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Aceuille()
        {
            List<Book> books = new List<Book>();

            

            ViewBag.books = _db.Books.ToList();

            return View();
           // @model IEnumerable<Books>
        }
    }
}
