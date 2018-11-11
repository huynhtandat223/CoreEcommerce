using AutoMapper;
using Infrastructures.RepositoryEntities.Data;
using Infrastructures.RepositoryEntities.EfRepositories;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using RCommerce.Module.Core.Extensions;
using RCommerce.Module.Core.Modules;

namespace RCommerce.Module.Core
{
    public class Startup
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            GlobalConfiguration.WebRootPath = _hostingEnvironment.WebRootPath;
            GlobalConfiguration.ContentRootPath = _hostingEnvironment.ContentRootPath;
            services.AddModules(_hostingEnvironment.ContentRootPath);
            
            services.AddCustomizedDataStore(_configuration);
            services.AddCors();
            services.AddAutoMapper();
            services.AddCustomizedMvc(GlobalConfiguration.Modules);

            services.AddTransient(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddTransient(typeof(IRepositoryWithTypedId<,>), typeof(EfRepositoryWithTypedId<,>));

            var sp = services.BuildServiceProvider();
            var moduleInitializers = sp.GetServices<IModuleInitializer>();
            foreach (var moduleInitializer in moduleInitializers)
            {
                moduleInitializer.ConfigureServices(services, _configuration);
            }

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod()
                        .AllowAnyOrigin().AllowCredentials());

            app.UseMvc(b =>
            {
                b.Select().Expand().Filter().OrderBy().MaxTop(100).Count();
                b.MapODataServiceRoute("odata", "odata", GetEdmModel(app));
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseHttpsRedirection();
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

            var moduleInitializers = app.ApplicationServices.GetServices<IModuleInitializer>();
            foreach (var moduleInitializer in moduleInitializers)
            {
                moduleInitializer.Configure(app, env);
            }
            
        }
        private static IEdmModel GetEdmModel(IApplicationBuilder app)
        {
            var builder = new ODataConventionModelBuilder();
            var odataCustomModelBuilders = app.ApplicationServices.GetServices<IODataCustomModelBuilder>();
            foreach (var item in odataCustomModelBuilders)
            {
                item.RegistEntities(builder);
            }
            return builder.GetEdmModel();
        }
    }
}
