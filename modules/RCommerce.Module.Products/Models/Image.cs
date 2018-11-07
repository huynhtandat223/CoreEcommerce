using Infrastructures.RepositoryEntities.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCommerce.Module.Products.Models
{
    public class Image : EntityBase
    {
        [StringLength(350)]
        public string Name { set; get; }
        [StringLength(500)]
        public string Alt { set; get; }
        [StringLength(350)]
        public int Position { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        [StringLength(350)]
        public string SourceUrl { set; get; }
    }
}
