﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RCommerce.Module.Customers.Models;

namespace RCommerce.Module.Authentication.Data
{
    public class AuthDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>
        , IdentityUserToken<int>>
    {
        public AuthDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                           .ToTable("Auth_User");

            builder.Entity<Role>()
                .ToTable("Auth_Role");

            builder.Entity<IdentityUserClaim<int>>(b =>
            {
                b.HasKey(uc => uc.Id);
                b.ToTable("Auth_UserClaim");
            });

            builder.Entity<IdentityRoleClaim<int>>(b =>
            {
                b.HasKey(rc => rc.Id);
                b.ToTable("Auth_RoleClaim");
            });

            builder.Entity<UserRole>(b =>
            {
                b.HasKey(ur => new { ur.UserId, ur.RoleId });
                b.HasOne(ur => ur.Role).WithMany(x => x.Users).HasForeignKey(r => r.RoleId);
                b.HasOne(ur => ur.User).WithMany(x => x.Roles).HasForeignKey(u => u.UserId);
                b.ToTable("Auth_UserRole");
            });

            builder.Entity<IdentityUserLogin<int>>(b =>
            {
                b.ToTable("Auth_UserLogin");
            });

            builder.Entity<IdentityUserToken<int>>(b =>
            {
                b.ToTable("Auth_UserToken");
            });

        }
    }
}
