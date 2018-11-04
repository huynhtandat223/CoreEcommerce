using EfCoreInfrastructures.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EfCoreInfrastructures.DbContexts
{
    public class CoreDbContext : DbContext
    {
        public override int SaveChanges()
        {
            TrackChanges();
            return base.SaveChanges();
        }
        private Func<DateTime> TimestampProvider { get; set; } = () => DateTime.UtcNow;
        private void TrackChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                if (entry.Entity is Auditable)
                {
                    var auditable = entry.Entity as Auditable;
                    if (entry.State == EntityState.Added)
                    {
                        auditable.CreatedDate = TimestampProvider();
                    }
                    else
                    {
                        auditable.ModifiedDate = TimestampProvider();
                    }
                }
            }
        }
    }
}
