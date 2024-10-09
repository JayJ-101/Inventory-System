using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Inventory_System.Models   
{
    public class Category
    {
        [MaxLength(10)]
        [Required(ErrorMessage ="Please enter a genre id.")]
        [Remote("CheckCategory","Validation","Admin")]
        public string CategoryId { get; set; } = string.Empty;
        [Required]
        public string CategoryName { get; set; } = string.Empty;
    }
}
