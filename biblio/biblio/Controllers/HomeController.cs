using biblio.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace biblio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IActionResult Redirection()
        {
            // Code pour effectuer des opérations avant la redirection si nécessaire
            // ...

            // Redirection vers une autre action ou une autre page
            return RedirectToAction("Aceuille", "Home");
        }


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
