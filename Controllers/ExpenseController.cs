using Microsoft.AspNetCore.Mvc;
using CyberWalletWeb.Models;
using CyberWalletWeb.Data;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace CyberWalletWeb.Controllers
{
    public class ExpensesController : Controller
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
            return View(ExpenseRepository.Expenses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new ExpenseFormViewModel
            {
                Categories = CategoryRepository.Categories
                    .Where(c => c.Type == "Expense")
                    .Select(c => new SelectListItem
                    {
                        Value = c.Name,
                        Text = c.Name
                    })
                    .ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(ExpenseFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = CategoryRepository.Categories
                    .Where(c => c.Type == "Expense")
                    .Select(c => new SelectListItem
                    {
                        Value = c.Name,
                        Text = c.Name
                    })
                    .ToList();

                return View(viewModel);
            }

            viewModel.Expense.Id = ExpenseRepository.Expenses.Count + 1;

            ExpenseRepository.Expenses.Add(viewModel.Expense);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var expense = ExpenseRepository.Expenses
                .FirstOrDefault(e => e.Id == id);

            if (expense == null)
            {
                return NotFound();
            }

            var viewModel = new ExpenseFormViewModel
            {
                Expense = expense,

                Categories = CategoryRepository.Categories
                    .Where(c => c.Type == "Expense")
                    .Select(c => new SelectListItem
                    {
                        Value = c.Name,
                        Text = c.Name
                    })
                    .ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(ExpenseFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = CategoryRepository.Categories
                    .Where(c => c.Type == "Expense")
                    .Select(c => new SelectListItem
                    {
                        Value = c.Name,
                        Text = c.Name
                    })
                    .ToList();

                return View(viewModel);
            }

            var expense = ExpenseRepository.Expenses
                .FirstOrDefault(e => e.Id == viewModel.Expense.Id);

            if (expense == null)
            {
                return NotFound();
            }

            expense.Category = viewModel.Expense.Category;
            expense.Description = viewModel.Expense.Description;
            expense.Amount = viewModel.Expense.Amount;
            expense.Date = viewModel.Expense.Date;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var expense =
                ExpenseRepository.Expenses
                .FirstOrDefault(e => e.Id == id);

            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var expense =
                ExpenseRepository.Expenses
                .FirstOrDefault(e => e.Id == id);

            if (expense != null)
            {
                ExpenseRepository.Expenses.Remove(expense);
            }

            return RedirectToAction("Index");
        }
    }
}