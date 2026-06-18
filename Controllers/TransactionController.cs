using Microsoft.AspNetCore.Mvc;
using CyberWalletWeb.Data;
using CyberWalletWeb.Models;

namespace CyberWalletWeb.Controllers
{
    public class TransactionsController : Controller
    {
        public IActionResult Index()
        {
            var transactions = new List<TransactionViewModel>();

            // Expenses
            transactions.AddRange(
                ExpenseRepository.Expenses.Select(e => new TransactionViewModel
                {
                    Date = e.Date,
                    Type = "Expense",
                    Category = e.Category,
                    Description = e.Description,
                    Amount = -e.Amount
                })
            );

            // Income
            transactions.AddRange(
                IncomeRepository.Incomes.Select(i => new TransactionViewModel
                {
                    Date = i.Date,
                    Type = "Income",
                    Category = i.Source,
                    Description = i.Source,
                    Amount = i.Amount
                })
            );

            transactions = transactions
                .OrderByDescending(t => t.Date)
                .ToList();

            return View(transactions);
        }
    }
}