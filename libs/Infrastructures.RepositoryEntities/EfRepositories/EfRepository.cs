using Infrastructures.RepositoryEntities.Data;
using Infrastructures.RepositoryEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.RepositoryEntities.EfRepositories
{
    
    public class EfRepository<T> : EfRepositoryWithTypedId<T, int>, IRepository<T>
       where T : class, IEntityWithTypedId<int>
    {
        public EfRepository(DbContext context) : base(context)
        {
        }
    }
}
