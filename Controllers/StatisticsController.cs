using Microsoft.AspNetCore.Mvc;
using CyberWalletWeb.Data;
using CyberWalletWeb.Models;

namespace CyberWalletWeb.Controllers
{
    public class StatisticsController : Controller
    {
        public IActionResult Index()
        {
            var model = new StatisticsViewModel();

            //Summary Cards
            model.TotalIncome = IncomeRepository.Incomes.Sum(i => i.Amount);

            model.TotalExpenses = ExpenseRepository.Expenses.Sum(e => e.Amount);

            model.Balance = model.TotalIncome - model.TotalExpenses;

            model.TransactionCount = 
                IncomeRepository.Incomes.Count + ExpenseRepository.Expenses.Count;

            //Expense breakdown
            model.ExpenseByCategory =
                ExpenseRepository.Expenses
                .GroupBy(e => e.Category)
                .ToDictionary(
                    g => g.Key,
                    g => g.Sum(e => e.Amount)
                );

            // Income Breakdown
            model.IncomeByCategory =
                IncomeRepository.Incomes
                .GroupBy(i => i.Source)
                .ToDictionary(
                    g => g.Key,
                    g => g.Sum(i => i.Amount)
                );

            return View(model);
        }
    }
    
}