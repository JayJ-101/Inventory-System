using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Inventory_System.Models   
{
    public class LogInVM
    {
        [Required(ErrorMessage = "Please enter a username.")]
        [StringLength(100)]
        public string UserName { get; set; }   = string.Empty;

        [Required(ErrorMessage = "Please enter a password.")]
        [StringLength(100)]
        public string Password { get; set; } = string.Empty;

        public string ReturnUrl { get; set; } = string.Empty;

        //public bool RememberMe { get; set; }    
    }
}
