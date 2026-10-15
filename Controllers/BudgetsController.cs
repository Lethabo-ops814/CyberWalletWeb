using CyberWalletWeb.Data;
using CyberWalletWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CyberWalletWeb.Controllers
{
    public class BudgetsController : Controller
    {


        private static readonly HttpClient client = new HttpClient();

        // Display all budgets
        public IActionResult Index()
        {
            return View(BudgetRepository.Budgets);
        }

        // Display the create budget form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Create a new budget
        [HttpPost]
        public IActionResult Create(Budget budget)
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




            if (!ModelState.IsValid)
            {
                return View(budget);
            }

            budget.Id = BudgetRepository.Budgets.Count + 1;

            BudgetRepository.Budgets.Add(budget);

            return RedirectToAction(nameof(Index));
        }

        // Display the edit form
        [HttpGet]
        public IActionResult Edit(int id)
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





            var budget = BudgetRepository.Budgets
                .FirstOrDefault(b => b.Id == id);

            if (budget == null)
            {
                return NotFound();
            }

            return View(budget);
        }

        // Update an existing budget
        [HttpPost]
        public IActionResult Edit(Budget updatedBudget)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedBudget);
            }

            var budget = BudgetRepository.Budgets
                .FirstOrDefault(b => b.Id == updatedBudget.Id);

            if (budget == null)
            {
                return NotFound();
            }

            budget.Name = updatedBudget.Name;
            budget.Category = updatedBudget.Category;
            budget.Amount = updatedBudget.Amount;
            budget.Month = updatedBudget.Month;

            return RedirectToAction(nameof(Index));
        }

        // Display the delete confirmation page
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var budget = BudgetRepository.Budgets
                .FirstOrDefault(b => b.Id == id);

            if (budget == null)
            {
                return NotFound();
            }

            return View(budget);
        }

        // Delete the selected budget
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var budget = BudgetRepository.Budgets
                .FirstOrDefault(b => b.Id == id);

            if (budget != null)
            {
                BudgetRepository.Budgets.Remove(budget);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}