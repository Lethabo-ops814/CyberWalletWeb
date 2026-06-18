using System.ComponentModel.DataAnnotations;

namespace CyberWalletWeb.Models
{
        public class Expense
        {
            public int Id { get; set; }

            [Required]
            public string Category { get; set; }

            [Required]
            public string Description { get; set; }

            [Required]
            public decimal Amount { get; set; }

            [Required]
            public DateTime Date { get; set; }
        }
    }