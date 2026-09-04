using Microsoft.AspNetCore.Mvc;
using CyberWalletWeb.Models;
using CyberWalletWeb.Data;
using System.Text.Json;

namespace CyberWalletWeb.Controllers
{
    public class DashboardController : Controller
    {
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