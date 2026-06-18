namespace CyberWalletWeb.Models
{
    public class DashboardViewModel
    {
        public decimal TotalBalance { get; set; }

        public decimal TotalIncome { get; set; }

        public decimal TotalExpenses { get; set; }

        public int ExpenseCount { get; set; }

        public int IncomeCount { get; set; }
    }
}