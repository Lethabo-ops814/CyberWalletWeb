using Microsoft.AspNetCore.Mvc;
using CyberWalletWeb.Models;
using CyberWalletWeb.Data;

namespace CyberWalletWeb.Controllers
{
    public class CategoriesController : Controller
    {

        private static readonly HttpClient client = new HttpClient();

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


        public IActionResult Index()
        {
            return View(CategoryRepository.Categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            category.Id =
                CategoryRepository.Categories.Count + 1;

            CategoryRepository.Categories.Add(category);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category =
                CategoryRepository.Categories
                .FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category updatedCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedCategory);
            }

            var category =
                CategoryRepository.Categories
                .FirstOrDefault(c => c.Id == updatedCategory.Id);

            if (category == null)
            {
                return NotFound();
            }

            category.Name = updatedCategory.Name;
            category.Type = updatedCategory.Type;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category =
                CategoryRepository.Categories
                .FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var category =
                CategoryRepository.Categories
                .FirstOrDefault(c => c.Id == id);

            if (category != null)
            {
                CategoryRepository.Categories.Remove(category);
            }

            return RedirectToAction("Index");
        }
    }
}