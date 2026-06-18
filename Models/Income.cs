using System.ComponentModel.DataAnnotations;

namespace CyberWalletWeb.Models
{
    public class Income
    {
        public int Id { get; set; }

        [Required]
        public string Source { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}