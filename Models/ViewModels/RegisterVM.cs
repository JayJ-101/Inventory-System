using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Inventory_System.Models   
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Please enter username.")]
        [StringLength(100)]
        [Remote("Check", "Validation", ErrorMessage = "User Already exist.")]
        public string UserName { get; set; } = string.Empty;


        [Required(ErrorMessage = "Please enter a last name.")]
        [StringLength(255)]
        public string FirstName { get; set; } = string.Empty;


        [Required(ErrorMessage = "Please enter a last name.")]
        [StringLength(255)]
        public string LastName { get; set; } = string.Empty;

        // from IdentityUser class
        [Required(ErrorMessage = "Please enter an email address.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a password.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
