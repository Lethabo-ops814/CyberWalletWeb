using CyberWalletWeb.Models;

namespace CyberWalletWeb.Data
{
    public static class BudgetRepository
    {
        public static List<Budget> Budgets { get; set; } = new()
        {
            new Budget
            {
                Id = 1,
                Name = "Monthly Food Budget",
                Category = "Food",
                Amount = 5000,
                Month = "July"
            },

            new Budget
            {
                Id = 2,
                Name = "Transport Budget",
                Category = "Transport",
                Amount = 2500,
                Month = "July"
            }
        };
    }
}