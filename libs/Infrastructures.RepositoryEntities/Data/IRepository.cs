using Infrastructures.RepositoryEntities.Models;

namespace Infrastructures.RepositoryEntities.Data
{
    public interface IRepository<T> : IRepositoryWithTypedId<T, int> where T : IEntityWithTypedId<int>
    {
    }
}
