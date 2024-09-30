using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory_System.Models   
{
    internal class CategoryConfig: IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasData(
                
                new Category { CategoryId ="electronics", CategoryName = "Electronics"},
                new Category { CategoryId ="groceries", CategoryName = "Groceries" },
                new Category { CategoryId ="clothes", CategoryName = "Clothing" }
                );
        }
    }
}
