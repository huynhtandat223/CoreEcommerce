using Infrastructures.RepositoryEntities.Models;
using System.Linq;

namespace Infrastructures.RepositoryEntities.Data
{
    public interface IRepositoryWithTypedId<T, TId> where T : IEntityWithTypedId<TId>
    {
        T GetById(TId id);
        IQueryable<T> Query();
        T Add(T entity);
        T Remove(T entity);
        T Update(T entity);
    }
}
