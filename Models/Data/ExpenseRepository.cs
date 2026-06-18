using CyberWalletWeb.Models;


namespace CyberWalletWeb.Data
{
    public static class ExpenseRepository
    {
        public static List<Expense> Expenses = new()
        {
            new Expense
            {
                Id = 1,
                Category = "Food",
                Description = "KFC Lunch",
                Amount = 120,
                Date = DateTime.Today
            },

            new Expense
            {
                Id = 2,
                Category = "Transport",
                Description = "Taxi Fare",
                Amount = 80,
                Date = DateTime.Today.AddDays(-1)
            }
        };
    }
}