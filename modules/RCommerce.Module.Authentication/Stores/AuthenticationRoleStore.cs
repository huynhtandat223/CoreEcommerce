using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RCommerce.Module.Customers.Models;

namespace RCommerce.Module.Authentication.Stores
{
    public class AuthenticationRoleStore : RoleStore<Role, DbContext, int, UserRole, IdentityRoleClaim<int>>
    {
        public AuthenticationRoleStore(DbContext context) : base(context)
        {
        }
    }
}
