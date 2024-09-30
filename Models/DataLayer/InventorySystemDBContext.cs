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

        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CategoryConfig());

        }
    }
}
