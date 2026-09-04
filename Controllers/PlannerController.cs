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