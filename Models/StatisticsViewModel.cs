namespace CyberWalletWeb.Models
{
    public class StatisticsViewModel
    {
        public decimal TotalIncome { get; set; }

        public decimal TotalExpenses { get; set; }

        public decimal Balance { get; set; }

        public int TransactionCount { get; set; }

        public Dictionary<string, decimal> ExpenseByCategory { get; set; } = new();

        public Dictionary<string, decimal> IncomeByCategory { get; set; } = new();
    }
}