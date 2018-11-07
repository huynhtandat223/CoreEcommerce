using Infrastructures.RepositoryEntities.Models;

namespace RCommerce.Module.Products.Models
{
    public class ProductOptionValueDefault : EntityBase
    {
        public ProductOption Option { set; get; }
        public int OptionId { set; get; }
        public string Value { set; get; }
        public int SortOrder { set; get; }
    }
}
