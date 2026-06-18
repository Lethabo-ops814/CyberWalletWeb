using Microsoft.AspNetCore.Mvc.Rendering;

namespace CyberWalletWeb.Models
{
    public class IncomeFormViewModel
    {
        public Income Income { get; set; } = new Income();

        public List<SelectListItem> Categories { get; set; } = new();
    }
}