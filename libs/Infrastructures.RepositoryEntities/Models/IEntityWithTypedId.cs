namespace Infrastructures.RepositoryEntities.Models
{
    public interface IEntityWithTypedId<TId>
    {
        TId Id { get; }
    }
}
