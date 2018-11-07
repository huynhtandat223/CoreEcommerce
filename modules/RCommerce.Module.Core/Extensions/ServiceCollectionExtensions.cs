using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RCommerce.Module.Core.Data;
using RCommerce.Module.Core.Entities;
using RCommerce.Module.Core.Modules;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace RCommerce.Module.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private static readonly IModuleConfigurationManager _modulesConfig = new ModuleConfigurationManager();
        public static IServiceCollection AddCustomizedDataStore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<RDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("RCommerce.AppHost")));
            return services;
        }
        public static IServiceCollection AddModules(this IServiceCollection services, string contentRootPath)
        {
            var modulesFolder = Path.Combine(contentRootPath, "Modules");
            foreach (var module in _modulesConfig.GetModules(modulesFolder))
            {
                GlobalConfiguration.Modules.Add(module);
                RegisterModuleInitializerServices(module, ref services);
            }

            return services;
        }

        private static void RegisterModuleInitializerServices(ModuleInfo module, ref IServiceCollection services)
        {
            var moduleInitializerType = module.Assembly.GetTypes()
                    .FirstOrDefault(t => typeof(IModuleInitializer).IsAssignableFrom(t));
            if ((moduleInitializerType != null) && (moduleInitializerType != typeof(IModuleInitializer)))
            {
                services.AddSingleton(typeof(IModuleInitializer), moduleInitializerType);
            }
        }
    }
}
