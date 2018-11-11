using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RCommerce.Module.Core.ActionFilters;
using RCommerce.Module.Core.Data;
using RCommerce.Module.Core.Entities;
using RCommerce.Module.Core.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            services.AddTransient<DbContext>(s => s.GetService<RDbContext>());
            return services;
        }
        public static IServiceCollection AddModules(this IServiceCollection services, string contentRootPath)
        {
            var modulesFolder = Path.Combine(contentRootPath, "Modules");
            IEnumerable<ModuleInfo> moduleInfos = null;
            if (!Directory.Exists(modulesFolder))
            {
                //add current assembly and core.
                var currentAssembly = System.Reflection.Assembly.GetEntryAssembly();
                var coreAssembly = System.Reflection.Assembly.Load("RCommerce.Module.Core");

                moduleInfos = new[] {
                    new ModuleInfo{ Assembly = coreAssembly, Name = coreAssembly.FullName, Version = Version.Parse("1.0")},
                    new ModuleInfo{ Assembly = currentAssembly, Name = currentAssembly.FullName, Version = Version.Parse("1.0")},
                };
            }
            else
                moduleInfos = _modulesConfig.GetModules(modulesFolder);

            foreach (var module in moduleInfos)
            {
                GlobalConfiguration.Modules.Add(module);
                RegisterModuleInitializerServices(module, ref services);
            }

            return services;
        }
        public static IServiceCollection AddCustomizedMvc(this IServiceCollection services, IList<ModuleInfo> modules)
        {
            services.AddOData();
            var mvcBuilder = services.AddMvc(options => {
                options.Filters.Add(typeof(ValidateModelAttribute));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            foreach (var module in modules)
            {
                mvcBuilder.AddApplicationPart(module.Assembly);
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

            var odataCustomModelBuilderType = module.Assembly.GetTypes().FirstOrDefault(x => typeof(IODataCustomModelBuilder).IsAssignableFrom(x));
            if ((odataCustomModelBuilderType != null) && (odataCustomModelBuilderType != typeof(IODataCustomModelBuilder)))
            {
                services.AddSingleton(typeof(IODataCustomModelBuilder), odataCustomModelBuilderType);
            }
        }
    }
}
