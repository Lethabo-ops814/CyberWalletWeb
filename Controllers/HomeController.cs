using System.Diagnostics;
using CyberWalletWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CyberWalletWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
