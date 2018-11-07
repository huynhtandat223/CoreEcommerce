using RCommerce.Module.Products.Models;
using Microsoft.EntityFrameworkCore;
using RCommerce.Module.Core;

namespace RCommerce.Module.Products.Data
{
    public class ProductCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProductCategory>()
                .HasKey(bc => new { bc.ProductId, bc.CategoryId });

            modelBuilder.Entity<ProductCategory>()
                .HasOne(bc => bc.Product)
                .WithMany(b => b.ProductCategories)
                .HasForeignKey(bc => bc.ProductId);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(bc => bc.CategoryId);


            modelBuilder.Entity<ProductImage>()
                .HasKey(bc => new { bc.ProductId, bc.ImageId });

            modelBuilder.Entity<ProductImage>()
                .HasOne(bc => bc.Product)
                .WithMany(b => b.ProductImages)
                .HasForeignKey(bc => bc.ProductId);

            modelBuilder.Entity<ProductImage>()
                .HasOne(bc => bc.Image)
                .WithMany(c => c.ProductImages)
                .HasForeignKey(bc => bc.ImageId);

            modelBuilder.Entity<ProductOptionValue>()
                .HasKey(bc => new { bc.ProductId, bc.OptionId, bc.ProductOptionValudeDefaultId });

            ProductsSeedData.SeedData(modelBuilder);

        }
    }
}
