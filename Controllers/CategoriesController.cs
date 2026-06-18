using Microsoft.AspNetCore.Mvc;
using CyberWalletWeb.Models;
using CyberWalletWeb.Data;

namespace CyberWalletWeb.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View(CategoryRepository.Categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            category.Id =
                CategoryRepository.Categories.Count + 1;

            CategoryRepository.Categories.Add(category);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category =
                CategoryRepository.Categories
                .FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category updatedCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedCategory);
            }

            var category =
                CategoryRepository.Categories
                .FirstOrDefault(c => c.Id == updatedCategory.Id);

            if (category == null)
            {
                return NotFound();
            }

            category.Name = updatedCategory.Name;
            category.Type = updatedCategory.Type;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category =
                CategoryRepository.Categories
                .FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var category =
                CategoryRepository.Categories
                .FirstOrDefault(c => c.Id == id);

            if (category != null)
            {
                CategoryRepository.Categories.Remove(category);
            }

            return RedirectToAction("Index");
        }
    }
}