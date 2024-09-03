using Domain.Entities.DataEntities;

namespace Domain.IReposetories.DataRepository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<ICollection<TEntity>> GetAll();
        Task<TEntity> Get(Guid id);
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task<ICollection<TEntity>> FilterBy(Func<TEntity, bool> filter);
    }
}
