using library.Data;
using library.Models;
using library.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace library.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AccountController(
            ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {

            var user = _context.Adherents.FirstOrDefault(a => a.Email == loginViewModel.EmailAddress); 

            if (user != null)
            {
                //User is found, check password
                if (user.Password == loginViewModel.Password)
                {
                    HttpContext.Session.SetString("id", user.AdherentID.ToString());
                    return RedirectToAction("Index", "Home");
                }
                //Password is incorrect
                TempData["Error"] = "Wrong credentials. Please try again";
                return View(loginViewModel);
            }
            //User not found
            TempData["Error"] = "Wrong credentials. Please try again";
            return View(loginViewModel);
        }

        public IActionResult Signup()
        {
            var response = new SignupViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Signup(SignupViewModel signupViewModel)
        {
            if (!ModelState.IsValid) return View(signupViewModel);

            var user = _context.Adherents.FirstOrDefault(a => a.Email == signupViewModel.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(signupViewModel);
            }

            var newUser = new Adherent()
            {
                Email = signupViewModel.EmailAddress,
                Password = signupViewModel.Password
            };
            var newUserResponse = _context.Adherents.Add(newUser);

            var userr = _context.Adherents.FirstOrDefault(a => a.Email == signupViewModel.EmailAddress);
            HttpContext.Session.SetString("id", userr.AdherentID.ToString());

            return RedirectToAction("Index", "Home");
        }


    }
}
