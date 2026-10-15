using Microsoft.AspNetCore.Mvc;
using CyberWalletWeb.Models;

namespace CyberWalletWeb.Controllers
{
    public class PlannerController : Controller
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
            var planner = new PlannerViewModel
            {
                MonthlyBudget = 10000,

                SavingsGoal = 5000,

                CurrentSpending = 7000,

                CurrentSavings = 3500,

                BudgetProgress = 70,

                SavingsProgress = 70
            };

            // Financial Overview

            planner.RemainingBudget =
                planner.MonthlyBudget - planner.CurrentSpending;

            planner.RemainingSavings =
                planner.SavingsGoal - planner.CurrentSavings;

            planner.FinancialStatus =
                planner.CurrentSpending <= planner.MonthlyBudget
                ? "On Track"
                : "Over Budget";

            return View(planner);
        }
    }
}