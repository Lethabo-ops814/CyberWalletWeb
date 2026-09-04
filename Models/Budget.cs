using System.ComponentModel.DataAnnotations;

namespace CyberWalletWeb.Models
{
    public class Budget
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Budget Name")]
        public string Name { get; set; } = "";

        [Required]
        public string Category { get; set; } = "";

        [Required]
        [Range(1, 100000000)]
        [Display(Name = "Budget Amount")]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "Month")]
        public string Month { get; set; } = "";
    }
}