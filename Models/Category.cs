using System.ComponentModel.DataAnnotations;

namespace  CyberWalletWeb.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }
    }
}