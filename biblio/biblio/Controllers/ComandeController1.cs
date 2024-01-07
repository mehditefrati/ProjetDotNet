using Microsoft.AspNetCore.Mvc;
using biblio.Controllers;
using LibraryManagement.Models;
using biblio.data;

namespace biblio.Controllers
{
    public class ComandeController1 : Controller
    {
        public IActionResult Commande()
        {
            List<Book> books = new List<Book>();

            using(var db = new ApplicationDbContext())
            {
                books = db.Books.ToList();
            }

            ViewBag.books = books;

            return View();
        }
    }
}
