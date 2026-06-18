using Microsoft.AspNetCore.Mvc.Rendering;

namespace CyberWalletWeb.Models
{
    public class ExpenseFormViewModel
    {
        public Expense Expense { get; set; } = new();

        public List<SelectListItem> Categories { get; set; } = new();
    }
}

