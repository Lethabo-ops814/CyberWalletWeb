namespace CyberWalletWeb.Models
{
    public class DashboardViewModel
    {
        // Summary cards
        public decimal TotalBalance { get; set; }

        public decimal TotalIncome { get; set; }

        public decimal TotalExpenses { get; set; }

        public int ExpenseCount { get; set; }

        public int IncomeCount { get; set; }

        public int TransactionCount { get; set; }

        public int BudgetCount { get; set; }

        // Chart data
        public string ExpenseLabelsJson { get; set; } = string.Empty;

        public string ExpenseDataJson { get; set; } = string.Empty;
    }
}