using Infrastructures.RepositoryEntities.Data;
using Infrastructures.RepositoryEntities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCommerce.Module.Products.Models
{
    public class Product : EntityBase, IAuditable
    {
        public Product()
        {
            ProductCategories = new HashSet<ProductCategory>();
            ProductImages = new HashSet<ProductImage>();
            ProductOptionValues = new HashSet<ProductOptionValue>();
        }

        [StringLength(500), Required]
        public string Name { set; get; }
        [StringLength(50)]
        public string SKU { set; get; }
        public ICollection<ProductCategory> ProductCategories { set; get; }
        public ICollection<ProductImage> ProductImages { set; get; }
        public ICollection<ProductOptionValue> ProductOptionValues { get; set; }
        public double? RegularPrice { set; get; }
        public DateTime? CreatedDate { set; get; }
        public DateTime? UpdatedDate { set; get; }
        public bool IsDeleted { get; set; }
        public int? QtyOnHand { set; get; }
        public double? OriginalPrice { set; get; }
        public bool? IsInStock { get; set; }
        [StringLength(1000)]
        public string OriginalUrl { set; get; }
        public string ProductNote { set; get; }
        public int Weight { get; set; }
        public string UpdatedUser { set; get; }
        public string CreatedUser { set; get; }
    }
}
