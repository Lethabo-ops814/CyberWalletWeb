using Microsoft.AspNetCore.Mvc;
using CyberWalletWeb.Models;
using CyberWalletWeb.Data;

namespace CyberWalletWeb.Controllers
{
    public class AccountController : Controller
    {
        // ============================
        // LOGIN
        // ============================

        [HttpGet]
        public IActionResult Login()
        {
            ViewData["Title"] = "Log In";

            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = UserRepository.ValidateUser(email, password);

            if (user == null)
            {
                ViewBag.Error = "Invalid email or password.";

                return View();
            }

            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("UserName", user.FullName);

            return RedirectToAction("Index", "Dashboard");
        }

        // ============================
        // REGISTER
        // ============================

        [HttpGet]
        public IActionResult Register()
        {
            ViewData["Title"] = "Register";

            return View();
        }

        [HttpPost]
        public IActionResult Register(string fullName,
                                      string email,
                                      string password,
                                      string confirmPassword)
        {
            if (password != confirmPassword)
            {
                ViewBag.Error = "Passwords do not match.";

                return View();
            }

            if (UserRepository.GetByEmail(email) != null)
            {
                ViewBag.Error = "An account with this email already exists.";

                return View();
            }

            UserRepository.Add(new User
            {
                FullName = fullName,
                Email = email,
                Password = password
            });

            return RedirectToAction("Login");
        }

        // ============================
        // LOGOUT
        // ============================

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}