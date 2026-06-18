using Microsoft.AspNetCore.Mvc;
using CyberWalletWeb.Models;

namespace CyberWalletWeb.Controllers
{
    public class PlannerController : Controller
    {
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

            return View(planner);
        }
    }
}