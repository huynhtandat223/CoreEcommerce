using Infrastructures.RepositoryEntities.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCommerce.Module.Products.Models
{
    public class Category : EntityBase
    {

        [StringLength(350), Required]
        public string Name { set; get; }
        public int ParentId { set; get; }
        [StringLength(350)]
        public string ParentName { set; get; }
        [StringLength(10)]
        public string SKUPrefix { set; get; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
