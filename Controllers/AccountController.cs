using CyberWalletWeb.Data;
using CyberWalletWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json.Serialization;

namespace CyberWalletWeb.Controllers
{
    public class AccountController : Controller

    {

        private static readonly HttpClient client = new HttpClient();
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


            //string nodeUrl = "http://localhost:3000/api/restaurant/restaurant";


            //try
            //{
            //    // 1. Serialize the C# object into a JSON string
            //    //string jsonPayload = JsonConvert.SerializeObject(dataToSend);

            //    // 2. Wrap the payload in an StringContent envelope with JSON media type
            //    var content = new StringContent("test", Encoding.UTF8, "application/json");

            //    // 3. Post the data asynchronously to the Node.js server
            //    HttpResponseMessage response = await client.GetAsync(nodeUrl);
            //    //PostAsync(nodeUrl, content);

            //    if (response.IsSuccessStatusCode)
            //    {
            //        // Read response if necessary
            //        string responseResult = await response.Content.ReadAsStringAsync();
            //        ViewBag.Message = "Data successfully sent to Node.js!";
            //        return RedirectToAction("Login");
            //    }
            //    else
            //    {
            //        ViewBag.Message = $"Error: Server responded with status code {response.StatusCode}";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ViewBag.Message = $"Exception occurred: {ex.Message}";
            //    Console.WriteLine(ex.Message);
            //}



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

        [HttpGet]
        public async Task<ActionResult> RegisterUser(string fullName,
                                      string email,
                                      string password,
                                      string confirmPassword)
        {

            string nodeUrl = "http://localhost:3000/api/restaurant/restaurant";


            try
            {
                // 1. Serialize the C# object into a JSON string
                //string jsonPayload = JsonConvert.SerializeObject(dataToSend);

                // 2. Wrap the payload in an StringContent envelope with JSON media type
                var content = new StringContent("test", Encoding.UTF8, "application/json");

                // 3. Post the data asynchronously to the Node.js server
                HttpResponseMessage response = await client.GetAsync(nodeUrl);
                //PostAsync(nodeUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    // Read response if necessary
                    string responseResult = await response.Content.ReadAsStringAsync();
                    ViewBag.Message = "Data successfully sent to Node.js!";
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.Message = $"Error: Server responded with status code {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Exception occurred: {ex.Message}";
                Console.WriteLine(ex.Message);
            }

            //if (password != confirmPassword)
            //{
            //    ViewBag.Error = "Passwords do not match.";

            //    return View();
            //}

            //if (UserRepository.GetByEmail(email) != null)
            //{
            //    ViewBag.Error = "An account with this email already exists.";

            //    return View();
            //}

            //UserRepository.Add(new User
            //{
            //    FullName = fullName,
            //    Email = email,
            //    Password = password
            //});

            //return RedirectToAction("Login");
            return RedirectToAction("Index");
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