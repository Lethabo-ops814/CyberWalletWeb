using Microsoft.AspNetCore.Mvc;
using CyberWalletWeb.Models;
using CyberWalletWeb.Data;
using System.Text.Json;

namespace CyberWalletWeb.Controllers
{
    public class DashboardController : Controller
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
            decimal totalIncome =
                IncomeRepository.Incomes.Sum(i => i.Amount);

            decimal totalExpenses =
                ExpenseRepository.Expenses.Sum(e => e.Amount);

            var expenseBreakdown =
                ExpenseRepository.Expenses
                    .GroupBy(e => e.Category)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Sum(e => e.Amount)
                    );

            var dashboard = new DashboardViewModel
            {
                // Financial summary
                TotalIncome = totalIncome,
                TotalExpenses = totalExpenses,
                TotalBalance = totalIncome - totalExpenses,

                // Record counts
                ExpenseCount = ExpenseRepository.Expenses.Count,
                IncomeCount = IncomeRepository.Incomes.Count,
                TransactionCount = ExpenseRepository.Expenses.Count + IncomeRepository.Incomes.Count,
                BudgetCount = BudgetRepository.Budgets.Count,

                // Chart data
                ExpenseLabelsJson = JsonSerializer.Serialize(expenseBreakdown.Keys),
                ExpenseDataJson = JsonSerializer.Serialize(expenseBreakdown.Values)
            };

            return View(dashboard);
        }
    }
}