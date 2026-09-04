using CyberWalletWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CyberWalletWeb.Data
{
    public static class CategoryRepository
    {
        public static List<Category> Categories = new()
        {
            new Category
            {
                Id = 1,
                Name = "Food",
                Type = "Expense"
            },

            new Category
            {
                Id = 2,
                Name = "Transport",
                Type = "Expense"
            },

            new Category
            {
                Id = 3,
                Name = "Shopping",
                Type = "Expense"
            },

            new Category
            {
                Id = 4,
                Name = "Salary",
                Type = "Income"
            },

            new Category
            {
                Id = 5,
                Name = "Freelance",
                Type = "Income"
            }
    };
    }
}