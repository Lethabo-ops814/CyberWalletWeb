using CyberWalletWeb.Models;

namespace CyberWalletWeb.Data
{
    public static class IncomeRepository
    {
        public static List<Income> Incomes = new()
        {
            new Income
            {
                Id = 1,
                Source = "Salary",
                Amount = 15000,
                Date = DateTime.Today
            },

            new Income
            {
                Id = 2,
                Source = "Freelance",
                Amount = 2500,
                Date = DateTime.Today.AddDays(-5)
            }
        };
    }
}