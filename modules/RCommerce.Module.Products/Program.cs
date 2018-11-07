using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace RCommerce.Module.Products
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<RCommerce.Module.Core.Startup>();
    }
}
