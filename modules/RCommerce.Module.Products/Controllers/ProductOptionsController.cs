using Infrastructures.RepositoryEntities.Data;
using RCommerce.Module.Core.Controllers;
using RCommerce.Module.Products.Models;

namespace RCommerce.Module.Products.Controllers
{
    public class ProductOptionsController : GenericController<ProductOption>
    {
        public ProductOptionsController(IRepository<ProductOption> repo): base(repo) { }
    }
}
