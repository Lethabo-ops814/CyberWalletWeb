using Microsoft.AspNetCore.Mvc;
using CyberWalletWeb.Data;
using CyberWalletWeb.Models;
using System.Text.Json;

namespace CyberWalletWeb.Controllers
{
    public class StatisticsController : Controller
    {
        public IActionResult Index()
        {
            var model = new StatisticsViewModel();

            // SUMMARY CARDS
            model.TotalIncome =
                IncomeRepository.Incomes.Sum(i => i.Amount);

            model.TotalExpenses =
                ExpenseRepository.Expenses.Sum(e => e.Amount);

            model.Balance =
                model.TotalIncome - model.TotalExpenses;

            model.TransactionCount =
                IncomeRepository.Incomes.Count +
                ExpenseRepository.Expenses.Count;

            
            // EXPENSE BREAKDOWN
            model.ExpenseByCategory =
                ExpenseRepository.Expenses
                .GroupBy(e => e.Category)
                .ToDictionary(
                    g => g.Key,
                    g => g.Sum(e => e.Amount)
                );

            model.ExpenseLabelsJson =
                JsonSerializer.Serialize(model.ExpenseByCategory.Keys);

            model.ExpenseDataJson =
                JsonSerializer.Serialize(model.ExpenseByCategory.Values);

            // INCOME BREAKDOWN
            model.IncomeByCategory =
                IncomeRepository.Incomes
                .GroupBy(i => i.Source)
                .ToDictionary(
                    g => g.Key,
                    g => g.Sum(i => i.Amount)
                );

            model.IncomeLabelsJson =
                JsonSerializer.Serialize(model.IncomeByCategory.Keys);

            model.IncomeDataJson =
                JsonSerializer.Serialize(model.IncomeByCategory.Values);

            
            // INCOME vs EXPENSES
            model.ComparisonLabelsJson =
                JsonSerializer.Serialize(new[]
                {
                    "Income",
                    "Expenses"
                });

            model.ComparisonDataJson =
                JsonSerializer.Serialize(new[]
                {
                    model.TotalIncome,
                    model.TotalExpenses
                });

            return View(model);
        }
    }
}