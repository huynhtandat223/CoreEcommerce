using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RCommerce.Module.Authentication.Data;
using RCommerce.Module.Customers.Models;

namespace RCommerce.Module.Authentication.Stores
{

    public class AuthenticationUserStore : UserStore<User, Role, AuthDbContext, int, IdentityUserClaim<int>, UserRole,
        IdentityUserLogin<int>, IdentityUserToken<int>, IdentityRoleClaim<int>>
    {
        public AuthenticationUserStore(AuthDbContext context, IdentityErrorDescriber describer) : base(context, describer)
        {
        }
    }
}
