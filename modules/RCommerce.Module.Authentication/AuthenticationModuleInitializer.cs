using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RCommerce.Module.Authentication.Data;
using RCommerce.Module.Authentication.Services;
using RCommerce.Module.Authentication.Stores;
using RCommerce.Module.Core;
using RCommerce.Module.Customers.Models;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RCommerce.Module.Authentication
{
    public class AuthenticationModuleInitializer : IModuleInitializer
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
        }

        public IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();

            services.AddDbContextPool<AuthDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AuthConnection"),
                    b => b.MigrationsAssembly("RCommerce.Module.Authentication")));

            services
                .AddIdentity<User, Role>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 4;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequiredUniqueChars = 0;
                })
                .AddRoleStore<AuthenticationRoleStore>()
                .AddUserStore<AuthenticationUserStore>()
                .AddDefaultTokenProviders();

            // configure jwt authentication
            var key = Encoding.ASCII.GetBytes("thisisrecretthisisrecret");
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }
        
    }
}
