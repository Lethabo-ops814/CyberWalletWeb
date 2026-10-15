using Microsoft.AspNetCore.Mvc;
using CyberWalletWeb.Models;
using CyberWalletWeb.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CyberWalletWeb.Controllers
{
    public class IncomeController : Controller
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
            return View(IncomeRepository.Incomes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new IncomeFormViewModel
            {
                Categories = CategoryRepository.Categories
                    .Where(c => c.Type == "Income")
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
        public IActionResult Create(IncomeFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = CategoryRepository.Categories
                    .Where(c => c.Type == "Income")
                    .Select(c => new SelectListItem
                    {
                        Value = c.Name,
                        Text = c.Name
                    })
                    .ToList();

                return View(viewModel);
            }

            viewModel.Income.Id = IncomeRepository.Incomes.Count + 1;

            IncomeRepository.Incomes.Add(viewModel.Income);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var income = IncomeRepository.Incomes
                .FirstOrDefault(i => i.Id == id);

            if (income == null)
            {
                return NotFound();
            }

            var viewModel = new IncomeFormViewModel
            {
                Income = income,

                Categories = CategoryRepository.Categories
                    .Where(c => c.Type == "Income")
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
        public IActionResult Edit(IncomeFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = CategoryRepository.Categories
                    .Where(c => c.Type == "Income")
                    .Select(c => new SelectListItem
                    {
                        Value = c.Name,
                        Text = c.Name
                    })
                    .ToList();

                return View(viewModel);
            }

            var income = IncomeRepository.Incomes
                .FirstOrDefault(i => i.Id == viewModel.Income.Id);

            if (income == null)
            {
                return NotFound();
            }

            income.Source = viewModel.Income.Source;
            income.Amount = viewModel.Income.Amount;
            income.Date = viewModel.Income.Date;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var income =
                IncomeRepository.Incomes
                .FirstOrDefault(i => i.Id == id);

            if (income == null)
            {
                return NotFound();
            }

            return View(income);
        }
    }
}