using Microsoft.AspNetCore.Mvc;
using CyberWalletWeb.Models;
using CyberWalletWeb.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CyberWalletWeb.Controllers
{
    public class IncomeController : Controller
    {
        public IActionResult Index()
        {
            return View(IncomeRepository.Incomes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new IncomeFormViewModel
            {
                Categories = CategoryRepository.Categories
                    .Where(c => c.Type == "Income")
                    .Select(c => new SelectListItem
                    {
                        Value = c.Name,
                        Text = c.Name
                    })
                    .ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(IncomeFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = CategoryRepository.Categories
                    .Where(c => c.Type == "Income")
                    .Select(c => new SelectListItem
                    {
                        Value = c.Name,
                        Text = c.Name
                    })
                    .ToList();

                return View(viewModel);
            }

            viewModel.Income.Id = IncomeRepository.Incomes.Count + 1;

            IncomeRepository.Incomes.Add(viewModel.Income);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var income = IncomeRepository.Incomes
                .FirstOrDefault(i => i.Id == id);

            if (income == null)
            {
                return NotFound();
            }

            var viewModel = new IncomeFormViewModel
            {
                Income = income,

                Categories = CategoryRepository.Categories
                    .Where(c => c.Type == "Income")
                    .Select(c => new SelectListItem
                    {
                        Value = c.Name,
                        Text = c.Name
                    })
                    .ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(IncomeFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = CategoryRepository.Categories
                    .Where(c => c.Type == "Income")
                    .Select(c => new SelectListItem
                    {
                        Value = c.Name,
                        Text = c.Name
                    })
                    .ToList();

                return View(viewModel);
            }

            var income = IncomeRepository.Incomes
                .FirstOrDefault(i => i.Id == viewModel.Income.Id);

            if (income == null)
            {
                return NotFound();
            }

            income.Source = viewModel.Income.Source;
            income.Amount = viewModel.Income.Amount;
            income.Date = viewModel.Income.Date;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var income =
                IncomeRepository.Incomes
                .FirstOrDefault(i => i.Id == id);

            if (income == null)
            {
                return NotFound();
            }

            return View(income);
        }
    }
}