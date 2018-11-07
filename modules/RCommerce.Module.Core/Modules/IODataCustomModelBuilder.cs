using Microsoft.AspNet.OData.Builder;

namespace RCommerce.Module.Core.Modules
{
    public interface IODataCustomModelBuilder
    {
        void RegistEntities(ODataModelBuilder builder);
    }
}
