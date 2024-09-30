using System.ComponentModel.DataAnnotations;

namespace Inventory_System.Models   
{
    public class Category
    {
        
        public string CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; } = string.Empty;
    }
}
