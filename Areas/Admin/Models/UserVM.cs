using Microsoft.AspNetCore.Identity;

namespace Inventory_System.Models
{
    public class UserVM
    {
        public IEnumerable<User> Users { get; set; } = null!;
        public IEnumerable<IdentityRole>Roles { get; set; } = null!;
    }
}
