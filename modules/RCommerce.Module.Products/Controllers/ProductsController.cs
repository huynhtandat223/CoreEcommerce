using Infrastructures.RepositoryEntities.Data;
using RCommerce.Module.Core.Controllers;
using RCommerce.Module.Products.Models;

namespace RCommerce.Module.Products.Controllers
{
    public class ProductsController : GenericController<Product>
    {
        public ProductsController(IRepository<Product> repo) : base(repo)
        {

        }
    }
}
