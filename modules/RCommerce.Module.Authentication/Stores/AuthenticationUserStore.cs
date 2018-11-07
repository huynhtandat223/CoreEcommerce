using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RCommerce.Module.Customers.Models;

namespace RCommerce.Module.Authentication.Stores
{

    public class AuthenticationUserStore : UserStore<User, Role, DbContext, int, IdentityUserClaim<int>, UserRole,
        IdentityUserLogin<int>, IdentityUserToken<int>, IdentityRoleClaim<int>>
    {
        public AuthenticationUserStore(DbContext context, IdentityErrorDescriber describer) : base(context, describer)
        {
        }
    }
}
