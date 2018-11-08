using Microsoft.EntityFrameworkCore;
using RCommerce.Module.Core.Models;

namespace RCommerce.Module.Core.Data
{
    public class CoreCustomModelBulder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppSetting>().ToTable("Core_AppSetting");
        }
    }
}
