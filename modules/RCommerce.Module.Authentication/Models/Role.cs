using Infrastructures.RepositoryEntities.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace RCommerce.Module.Customers.Models
{
    public class Role : IdentityRole<int>
    {
        public IList<UserRole> Users { get; set; } = new List<UserRole>();
    }
}
