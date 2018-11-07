using RCommerce.Module.Products.Models;
using Microsoft.EntityFrameworkCore;

namespace RCommerce.Module.Products.Data
{
    public class ProductsSeedData
    {
        
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Category 1", ParentId = 0, SKUPrefix = "C1" },
                new Category { Id = 2, Name = "Category 2", ParentId = 0, SKUPrefix = "C2" },
                new Category { Id = 3, Name = "Category 3", ParentId = 1, SKUPrefix = "C3", ParentName = "Category 1" },
                new Category { Id = 4, Name = "Category 4", ParentId = 1, SKUPrefix = "C4", ParentName = "Category 1" },
                new Category { Id = 5, Name = "Category 5", ParentId = 2, SKUPrefix = "C5", ParentName = "Category 2" },
                new Category { Id = 6, Name = "Category 6", ParentId = 3, SKUPrefix = "C6", ParentName = "Category 3" }
                );
        }
    }
}
