using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RCommerce.Module.Authentication.Data;
using RCommerce.Module.Customers.Models;

namespace RCommerce.Module.Authentication.Stores
{
    public class AuthenticationRoleStore : RoleStore<Role, AuthDbContext, int, UserRole, IdentityRoleClaim<int>>
    {
        public AuthenticationRoleStore(AuthDbContext context) : base(context)
        {
        }
    }
}
