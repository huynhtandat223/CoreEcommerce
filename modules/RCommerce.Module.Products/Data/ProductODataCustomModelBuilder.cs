using RCommerce.Module.Products.Models;
using Microsoft.AspNet.OData.Builder;
using RCommerce.Module.Core.Modules;
using RCommerce.Module.Core.Dtos;

namespace RCommerce.Module.Products.Data
{
    public class ProductODataCustomModelBuilder : IODataCustomModelBuilder
    {
        public void RegistEntities(ODataModelBuilder builder)
        {
            builder.EntitySet<Category>("Categories");
            builder.EntitySet<ProductOption>("ProductOptions");
            builder.EntitySet<ProductOptionValueDefault>("ProductOptionValueDefaults");
            builder.EntitySet<Product>("Products");
            builder.EntitySet<ProductCategory>("ProductCategories").EntityType.HasKey(t => new { t.CategoryId, t.ProductId});
            builder.ComplexType<CategoryWrapperDto>()
                .CollectionProperty(i => i.Grouped);
              
            builder.Namespace = "CategoryService";
            builder.EntityType<Category>().Collection
                .Function("Grouped")
                .Returns<CategoryWrapperDto>();

        }

    }
}
