using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace RCommerce.Module.Core
{
    public class CoreModuleInitializer : IModuleInitializer
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
        }

        public IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSpaStaticFiles(config =>
            {
                config.RootPath = "ClientApp/dist";
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            return services;
        }
    }
}
