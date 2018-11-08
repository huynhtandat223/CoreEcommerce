using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RCommerce.Module.Core;
using RCommerce.Module.Core.Extensions;
using System;
using System.IO;

namespace RCommerce.Module.Authentication.Data
{
    public class AuthDbContextFactory : IDesignTimeDbContextFactory<AuthDbContext>
    {
        
        public AuthDbContext CreateDbContext(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var contentRootPath = Directory.GetCurrentDirectory();

            var builder = new ConfigurationBuilder()
                            .SetBasePath(contentRootPath)
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                            .AddJsonFile($"appsettings.{environmentName}.json", true);

            //builder.AddUserSecrets(typeof(MigrationSimplDbContextFactory).Assembly, optional: true);
            builder.AddEnvironmentVariables();
            var _configuration = builder.Build();

            //setup DI
            IServiceCollection services = new ServiceCollection();
            GlobalConfiguration.ContentRootPath = contentRootPath;
            services.AddModules(contentRootPath);

            services.AddDbContextPool<AuthDbContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("AuthConnection"),
                    b => b.MigrationsAssembly("RCommerce.Module.Authentication")));

            var _serviceProvider = services.BuildServiceProvider();

            return _serviceProvider.GetRequiredService<AuthDbContext>();
        }
    }

}
