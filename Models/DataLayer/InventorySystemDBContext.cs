using Inventory_System.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Inventory_System.Models   
{
    public class InventorySystemDBContext : IdentityDbContext<User>
    {

        public InventorySystemDBContext(DbContextOptions<InventorySystemDBContext> options)
       : base(options)
        {
        }
    }
}
