namespace Infrastructures.RepositoryEntities.Models
{
    public abstract class EntityBaseWithTypedId<TId> :  IEntityWithTypedId<TId>
    {
        public virtual TId Id { get; set; }
    }
}
