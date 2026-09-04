namespace CyberWalletWeb.Models
{
    public class StatisticsViewModel
    {
        // Summary Cards
        public decimal TotalIncome { get; set; }

        public decimal TotalExpenses { get; set; }

        public decimal Balance { get; set; }

        public int TransactionCount { get; set; }

        // Tables
        public Dictionary<string, decimal> ExpenseByCategory { get; set; } = new();

        public Dictionary<string, decimal> IncomeByCategory { get; set; } = new();

        // Expense Pie Chart
        public string ExpenseLabelsJson { get; set; } = "";

        public string ExpenseDataJson { get; set; } = "";

        // Income Doughnut Chart
        public string IncomeLabelsJson { get; set; } = "";

        public string IncomeDataJson { get; set; } = "";

        // Income vs Expenses Bar Chart
        public string ComparisonLabelsJson { get; set; } = "";

        public string ComparisonDataJson { get; set; } = "";
    }
}