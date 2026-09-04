namespace CyberWalletWeb.Models
{
    public class PlannerViewModel
    {
        public decimal MonthlyBudget { get; set; }

        public decimal SavingsGoal { get; set; }

        public decimal CurrentSpending { get; set; }

        public decimal CurrentSavings { get; set; }

        public int BudgetProgress { get; set; }

        public int SavingsProgress { get; set; }

        public decimal RemainingBudget { get; set; }

        public decimal RemainingSavings { get; set; }

        public string FinancialStatus { get; set; } = "";
    }
}