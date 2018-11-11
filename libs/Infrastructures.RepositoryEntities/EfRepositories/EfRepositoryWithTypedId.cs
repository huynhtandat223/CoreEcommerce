using Infrastructures.RepositoryEntities.Data;
using Infrastructures.RepositoryEntities.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructures.RepositoryEntities.EfRepositories
{
    public class EfRepositoryWithTypedId<T, TId> : IRepositoryWithTypedId<T, TId> where T : class, IEntityWithTypedId<TId>
    {
        public EfRepositoryWithTypedId(DbContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        protected DbContext Context { get; }

        protected DbSet<T> DbSet { get; }

        public T Add(T entity)
        {
            DbSet.Add(entity);
            Context.SaveChanges();
            return entity;
        }
        public IQueryable<T> Query()
        {
            return DbSet;
        }

        public T Remove(T entity)
        {
            DbSet.Remove(entity);
            Context.SaveChanges();
            return entity;
        }
        public T Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
            return entity;
        }
        public T GetById(TId id)
        {
            return DbSet.Find(id);
        }
    }
}
