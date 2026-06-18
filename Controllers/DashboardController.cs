using Microsoft.AspNetCore.Mvc;
using CyberWalletWeb.Models;
using CyberWalletWeb.Data;

namespace CyberWalletWeb.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            decimal totalIncome =
                IncomeRepository.Incomes.Sum(i => i.Amount);

            decimal totaExpense =
                ExpenseRepository.Expenses.Sum(equals => equals.Amount);

            var dashboard = new DashboardViewModel
            {
                TotalIncome = totalIncome,
                TotalExpenses = totaExpense,
                TotalBalance = totalIncome - totaExpense,

                ExpenseCount =
                ExpenseRepository.Expenses.Count,

                IncomeCount =
                IncomeRepository.Incomes.Count,

            };
            return View(dashboard);
        }
    }
}