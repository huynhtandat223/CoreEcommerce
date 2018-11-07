using Infrastructures.RepositoryEntities.Data;
using RCommerce.Module.Core.Controllers;
using RCommerce.Module.Products.Models;

namespace RCommerce.Module.Products.Controllers
{

    public class ProductOptionValueDefaultsController : GenericController<ProductOptionValueDefault>
    {
        public ProductOptionValueDefaultsController(IRepository<ProductOptionValueDefault> repo) : base(repo) { }
    }
}
