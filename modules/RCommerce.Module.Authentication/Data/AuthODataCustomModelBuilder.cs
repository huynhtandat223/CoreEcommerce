using Microsoft.AspNet.OData.Builder;
using RCommerce.Module.Core.Modules;
using RCommerce.Module.Customers.Models;

namespace RCommerce.Module.Authentication.Data
{
    public class AuthODataCustomModelBuilder : IODataCustomModelBuilder
    {
        public void RegistEntities(ODataModelBuilder builder)
        {
            builder.EntitySet<User>("Users");
        }
    }
}
