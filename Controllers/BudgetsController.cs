using Microsoft.AspNetCore.Mvc;
using CyberWalletWeb.Models;
using CyberWalletWeb.Data;

namespace CyberWalletWeb.Controllers
{
    public class BudgetsController : Controller
    {
        // Display all budgets
        public IActionResult Index()
        {
            return View(BudgetRepository.Budgets);
        }

        // Display the create budget form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Create a new budget
        [HttpPost]
        public IActionResult Create(Budget budget)
        {
            if (!ModelState.IsValid)
            {
                return View(budget);
            }

            budget.Id = BudgetRepository.Budgets.Count + 1;

            BudgetRepository.Budgets.Add(budget);

            return RedirectToAction(nameof(Index));
        }

        // Display the edit form
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var budget = BudgetRepository.Budgets
                .FirstOrDefault(b => b.Id == id);

            if (budget == null)
            {
                return NotFound();
            }

            return View(budget);
        }

        // Update an existing budget
        [HttpPost]
        public IActionResult Edit(Budget updatedBudget)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedBudget);
            }

            var budget = BudgetRepository.Budgets
                .FirstOrDefault(b => b.Id == updatedBudget.Id);

            if (budget == null)
            {
                return NotFound();
            }

            budget.Name = updatedBudget.Name;
            budget.Category = updatedBudget.Category;
            budget.Amount = updatedBudget.Amount;
            budget.Month = updatedBudget.Month;

            return RedirectToAction(nameof(Index));
        }

        // Display the delete confirmation page
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var budget = BudgetRepository.Budgets
                .FirstOrDefault(b => b.Id == id);

            if (budget == null)
            {
                return NotFound();
            }

            return View(budget);
        }

        // Delete the selected budget
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var budget = BudgetRepository.Budgets
                .FirstOrDefault(b => b.Id == id);

            if (budget != null)
            {
                BudgetRepository.Budgets.Remove(budget);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}